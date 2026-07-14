namespace ShapeCrawler.Presentations;

/// <summary>
///     Represents a draft indentation for fluent API.
/// </summary>
public sealed class DraftIndentation
{
    /// <summary>
    ///    Gets indentation before text in points.
    /// </summary>
    internal double? BeforeTextPoints { get; private set; }

    /// <summary>
    ///     Sets indentation before text in points.
    /// </summary>
    public DraftIndentation BeforeText(double points)
    {
        this.BeforeTextPoints = points;
        return this;
    }
}