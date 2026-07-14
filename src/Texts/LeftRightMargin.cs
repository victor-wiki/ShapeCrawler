using DocumentFormat.OpenXml;
using ShapeCrawler.Units;

namespace ShapeCrawler.Texts;

internal readonly ref struct LeftRightMargin(Int32Value? emus)
{
    private const double DefaultLeftAndRightMarginPoints = 7.09d; // ~0.25 cm

    public double Value => emus is null ? DefaultLeftAndRightMarginPoints : new Emus(emus).AsPoints();
}