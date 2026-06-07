using P = DocumentFormat.OpenXml.Presentation;
using Position = ShapeCrawler.Positions.Position;

namespace ShapeCrawler.Shapes;

public sealed class LineShape : DrawingShape
{
    public LineShape(
        Position position,
        ShapeSize shapeSize,
        ShapeId shapeId,
        P.ConnectionShape pConnectionShape)
        : base(position, shapeSize, shapeId, pConnectionShape)
    {
        this.Line = new Line(pConnectionShape, this);
    }

    public override ILine? Line { get; }
}