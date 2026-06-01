using DocumentFormat.OpenXml;
using ShapeCrawler.Shapes;
using Position = ShapeCrawler.Positions.Position;

namespace ShapeCrawler.SmartArts;

public sealed class SmartArtShape : DrawingShape
{
    public SmartArtShape(Position position, ShapeSize shapeSize, ShapeId shapeId, OpenXmlElement pShapeTreeElement)
        : base(position, shapeSize, shapeId, pShapeTreeElement)
    {
        this.SmartArt = new SmartArt(new SmartArtNodeCollection());
    }

    public override ISmartArt? SmartArt { get; }

    public override ShapeContentType ContentType => ShapeContentType.SmartArt;
}