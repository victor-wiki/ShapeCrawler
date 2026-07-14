using System;

namespace ShapeCrawler.Units;

public readonly ref struct Emus(long emus)
{
    public double AsPoints() => Math.Round(emus / 12700d, 2);

    public double AsPixels() => Math.Round(emus / 9525d, 2);
}