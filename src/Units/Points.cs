using System;

namespace ShapeCrawler.Units;

public readonly ref struct Points(double points)
{
    internal long AsEmus() => (long)(points * 12700);

    internal int AsHundredPoints() => (int)(points * 100);

    public double AsPixels()
    {
        const double pointsPerInch = 72d;
        const double pixelsPerInch = 96d;

        return Math.Round(points * pixelsPerInch / pointsPerInch, 2);
    }
}