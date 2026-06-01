using System.Linq;
using System.Xml.Linq;
using DocumentFormat.OpenXml.Packaging;
using A = DocumentFormat.OpenXml.Drawing;

namespace ShapeCrawler.SlideMasters;

internal sealed class BackgroundSolidFill(SlideLayoutPart slideLayoutPart) : ISolidFill
{
    public string Color
    {
        get
        {
            var pCommonSlideData = slideLayoutPart.SlideLayout!.CommonSlideData;
            var pBackground = pCommonSlideData?.GetFirstChild<DocumentFormat.OpenXml.Presentation.Background>();
            var pBackgroundProperties = pBackground?.GetFirstChild<DocumentFormat.OpenXml.Presentation.BackgroundProperties>();

            var aSolidFill = pBackgroundProperties?.GetFirstChild<DocumentFormat.OpenXml.Drawing.SolidFill>();

            var aRgbColorModelHex = aSolidFill?.RgbColorModelHex;

            string color = aRgbColorModelHex != null ? aRgbColorModelHex.Val!.ToString()! : string.Empty;

            if (string.IsNullOrEmpty(color))
            {
                return this.ColorHexOrNullOf(slideLayoutPart, aSolidFill?.SchemeColor?.Val!) ?? string.Empty;
            }

            return string.Empty;
        }
    }

    public double Alpha
    {
        get
        {
            var pCommonSlideData = slideLayoutPart.SlideLayout!.CommonSlideData;
            var pBackground = pCommonSlideData?.GetFirstChild<DocumentFormat.OpenXml.Presentation.Background>();
            var pBackgroundProperties = pBackground?.GetFirstChild<DocumentFormat.OpenXml.Presentation.BackgroundProperties>();

            if (pBackgroundProperties != null)
            {
                string xml = pBackgroundProperties.OuterXml;

                XElement element = XElement.Parse(xml);

                var alphaElement = element.Elements().FirstOrDefault(item => item.Name.LocalName == "solidFill")?.Elements().FirstOrDefault(item => item.Name.LocalName == "schemeClr")?.Elements()?.FirstOrDefault(item => item.Name.LocalName == "alpha");

                if (alphaElement != null)
                {
                    string? value = alphaElement.Attributes("val")?.FirstOrDefault()?.Value;

                    if (value != null)
                    {
                        if (int.TryParse(value, out _))
                        {
                            return int.Parse(value) / 1000;
                        }
                    }
                }
            }

            return 100;
        }
    }

    private string? ColorHexOrNullOf(SlideLayoutPart slideLayoutPart, string schemeColor)
    {
        var openXmlPart = slideLayoutPart as OpenXmlPart;
        var aColorScheme = GetColorScheme(openXmlPart);

        var aColor2Type = aColorScheme.Elements<A.Color2Type>().FirstOrDefault(c => c.LocalName == schemeColor);
        return aColor2Type?.RgbColorModelHex?.Val?.Value
               ?? aColor2Type?.SystemColor?.LastColor?.Value;
    }

    private static A.ColorScheme GetColorScheme(OpenXmlPart openXmlPart)
    {
        return openXmlPart switch
        {
            SlidePart sdkSlidePart => sdkSlidePart.SlideLayoutPart!.SlideMasterPart!.ThemePart!.Theme!.ThemeElements!
                .ColorScheme!,
            SlideLayoutPart sdkSlideLayoutPart => sdkSlideLayoutPart!.SlideMasterPart!.ThemePart!.Theme!.ThemeElements!
                .ColorScheme!,
            _ => ((SlideMasterPart)openXmlPart).ThemePart!.Theme!.ThemeElements!.ColorScheme!
        };
    }
}