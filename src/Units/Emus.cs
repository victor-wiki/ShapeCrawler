using System;

namespace ShapeCrawler.Units;

public readonly ref struct Emus(long emus)
{
    public decimal AsPoints() => Math.Round(emus / 12700m, 2);

    public decimal AsPixels() => Math.Round(emus / 9525m, 2);
}