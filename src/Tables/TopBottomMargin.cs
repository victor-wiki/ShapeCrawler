using DocumentFormat.OpenXml;
using ShapeCrawler.Units;

namespace ShapeCrawler.Tables;

internal readonly ref struct TopBottomMargin(Int32Value? emus)
{
    private const double DefaultTopAndBottomMargin = 3.69d; // ~0.13 cm

    public double Value => emus is null ? DefaultTopAndBottomMargin : new Emus(emus).AsPoints();
}