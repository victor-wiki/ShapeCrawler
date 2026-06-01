using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace ShapeCrawler.Slides;

/// <summary>
///     Represents properties for the new shapes.
/// </summary>
public sealed class NewShapeProperties(IUserSlideShapeCollection shapes)
{
    /// <summary>
    ///     Generates ID for the next new shape.
    /// </summary>
    public int Id()
    {
        if (shapes.Any())
        {
            return shapes.Select(shape => shape.Id).Prepend(0).Max() + 1;
        }

        return 1;
    }

    /// <summary>
    ///     Generates name for the next new shape.
    /// </summary>
    public string Name() => $"Shape {this.Id()}";

    /// <summary>
    ///     Generates name for the next new table shape.
    /// </summary>
    public string TableName()
    {
        var maxOrder = 0;
        foreach (var shape in shapes)
        {
            var matchOrder = Regex.Match(shape.Name, "(?!Table )\\d+", RegexOptions.None, TimeSpan.FromSeconds(100));
            if (!matchOrder.Success)
            {
                continue;
            }

            var order = int.Parse(matchOrder.Value);
            if (order > maxOrder)
            {
                maxOrder = order;
            }
        }

        return $"Table {maxOrder + 1}";
    }
}