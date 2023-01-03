using System;

namespace Meas2D.FixPos
{
    class FixPos2DFactory
    {
        public static FixPos2DBaseModel CreateFixPos(EFixPos2DType type)
        {
            switch (type)
            {
                case EFixPos2DType.CIRCLES:
                    return new CirclesFixPos2DModel();
                case EFixPos2DType.CIRCLELINE:
                    return new CircleLineFixPos2DModel();
                case EFixPos2DType.LINES:
                    return new LinesFixPos2DModel();
                case EFixPos2DType.MODELMATCH:
                    return new ModelMatchFixPos2DModel();
                default:
                    throw new Exception($"ToolBaseModel not implemented for {type}");
            }
        }
    }
}