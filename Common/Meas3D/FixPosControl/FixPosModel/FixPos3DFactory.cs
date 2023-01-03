using System;

namespace Meas3D.FixPos
{
    class FixPos3DFactory
    {
        public static FixPos3DBaseModel CreateFixPos(EFixPos3DType type)
        {
            switch (type)
            {
                case EFixPos3DType.CIRCLES:
                    return new CirclesFixPos3DModel();
                case EFixPos3DType.CIRCLELINE:
                    return new CircleLineFixPos3DModel();
                case EFixPos3DType.LINES:
                    return new LinesFixPos3DModel();
                case EFixPos3DType.MODELMATCH:
                    return new ModelMatchFixPos3DModel();
                default:
                    throw new Exception($"ToolBaseModel not implemented for {type}");
            }
        }
    }
}