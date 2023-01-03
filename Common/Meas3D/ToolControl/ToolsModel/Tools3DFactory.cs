using System;

namespace Meas3D.Tool
{
    class ToolsFactory
    {
        public static Tool3DBaseModel CreateTool(ETool3DType toolType)
        {
            switch (toolType)
            {
                case ETool3DType.FITPLANE:
                    return new FitPlaneTool3DModel();
                case ETool3DType.PLANETOPLANEANGLE:
                    return new PlaneToPlaneAngleTool3DModel();
                case ETool3DType.REGIONHEIGHT:
                    return new RegionHeightTool3DModel();
                case ETool3DType.FITCIRCLE:
                    return new FitCircleTool3DModel();
                case ETool3DType.VECTEXLOC:
                    return new VertexLocTool3DModel();
                case ETool3DType.FITLINE:
                    return new FitLineTool3DModel();
                case ETool3DType.CIRCLESDIST:
                    return new CirclesDistTool3DModel();
                case ETool3DType.CTLDIST:
                    return new CTLDistTool3DModel();
                case ETool3DType.LINESDIST:
                    return new LinesDistTool3DModel();
                case ETool3DType.CLUE:
                    return new ClueTool3DModel();
                case ETool3DType.PLANESINTERSECTION:
                    return new PlanesIntersectionTool3DModel();
                case ETool3DType.POINTSDIST:
                    return new PointsDistTool3DModel();
                default:
                    throw new Exception($"ToolBaseModel not implemented for {toolType}");
            }
        }
    }
}
