namespace ShapeCrawler.Presentations;

/// <summary>
///     Represents a draft stroke.
/// </summary>
public sealed class DraftStroke
{
    internal double? DraftWidthPoints { get; private set; }

    /// <summary>
    ///     Sets stroke width in points.
    /// </summary>
    public DraftStroke Width(double points)
    {
        this.DraftWidthPoints = points;
        return this;
    }
}