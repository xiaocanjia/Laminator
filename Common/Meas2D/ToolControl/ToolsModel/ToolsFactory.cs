namespace Meas2D
{
    public class ToolsFactory
    {
        public static Tool2DBaseModel CreateTool(ETool2DType type)
        {
            switch (type)
            {
                case ETool2DType.READCODE:
                    return new ReadCodeToolModel();
                default:
                    throw new System.Exception($"{type} has not being implemented");
            }
        }
    }
}
