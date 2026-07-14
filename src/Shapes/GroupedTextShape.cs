using ShapeCrawler.Drawing;
using ShapeCrawler.Groups;
using P = DocumentFormat.OpenXml.Presentation;

namespace ShapeCrawler.Shapes;

public sealed class GroupedTextShape(P.Shape pShape, DrawingTextBox textBox, GroupedShape groupedShape)
    : TextShape(pShape, textBox)
{
    public override double X
    {
        get => groupedShape.X;
        set => groupedShape.X = value;
    }

    public override double Y
    {
        get => groupedShape.Y;
        set => groupedShape.Y = value;
    }

    public override double Width
    {
        get => groupedShape.Width;
        set => groupedShape.Width = value;
    }

    public override double Height
    {
        get => groupedShape.Height;
        set => groupedShape.Height = value;
    }
}