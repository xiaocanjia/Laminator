using HalconDotNet;

namespace Vision2D
{
    public class JMessage
    {
        public int Row;

        public int Col;

        public double Size;

        private readonly double initSize;

        public string Text;

        public string Color;

        public JMessage(int row, int col, double size, string color, string text)
        {
            Row = row;
            Col = col;
            initSize = size;
            Size = size;
            Color = color;
            Text = text;
        }

        public void Show(HWindow window)
        {
            if (Color != "")
                window.SetColor(Color);
            window.SetFont($"-Consolas-{Size}-*-0-*-*-0-");
            window.SetTposition(Row, Col);
            window.WriteString(Text);
        }

        public void ResetSize()
        {
            Size = initSize;
        }
    }
}
