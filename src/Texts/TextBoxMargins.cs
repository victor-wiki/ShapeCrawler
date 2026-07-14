using DocumentFormat.OpenXml;
using ShapeCrawler.Tables;
using ShapeCrawler.Units;
using A = DocumentFormat.OpenXml.Drawing;

namespace ShapeCrawler.Texts;

public sealed class TextBoxMargins(OpenXmlElement textBody)
{
    internal double Left
    {
        get
        {
            return new LeftRightMargin(textBody.GetFirstChild<A.BodyProperties>()!.LeftInset).Value;
        }

        set
        {
            var bodyProperties = textBody.GetFirstChild<A.BodyProperties>()!;
            var emu = new Points(value).AsEmus();
            bodyProperties.LeftInset = new Int32Value((int)emu);
        }
    }

    internal double Right
    {
        get => new LeftRightMargin(textBody.GetFirstChild<A.BodyProperties>()!.RightInset).Value;
        set
        {
            var bodyProperties = textBody.GetFirstChild<A.BodyProperties>()!;
            var emu = new Points(value).AsEmus();
            bodyProperties.RightInset = new Int32Value((int)emu);
        }
    }

    internal double Top
    {
        get => new TopBottomMargin(textBody.GetFirstChild<A.BodyProperties>()!.TopInset).Value;
        set
        {
            var bodyProperties = textBody.GetFirstChild<A.BodyProperties>()!;
            var emu = new Points(value).AsEmus();
            bodyProperties.TopInset = new Int32Value((int)emu);
        }
    }

    internal double Bottom
    {
        get => new TopBottomMargin(textBody.GetFirstChild<A.BodyProperties>()!.BottomInset).Value;
        set
        {
            var bodyProperties = textBody.GetFirstChild<A.BodyProperties>()!;
            var emu = new Points(value).AsEmus();
            bodyProperties.BottomInset = new Int32Value((int)emu);
        }
    }
}