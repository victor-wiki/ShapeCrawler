namespace ShapeCrawler.Units;

public readonly ref struct Emus(long emus)
{
    public decimal AsPoints() => emus / 12700m;

    public decimal AsPixels() => emus / 9525m;
}