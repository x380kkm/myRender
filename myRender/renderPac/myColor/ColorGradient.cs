using System.Windows.Media;

namespace myRender.renderPac.myColor
{
    public class ColorGradient
    {
        private readonly Color _color0;
        private readonly Color _color1;

        public ColorGradient(Color color0, Color color1)
        {
            _color0 = color0;
            _color1 = color1;
        }

        public Color GetColor(float depth)
        {
            // Clamp the depth value between 0 and 1
            depth = System.Math.Max(0, System.Math.Min(1, depth));

            // Perform linear interpolation between the two colors
            byte r = (byte)((1 - depth) * _color0.R + depth * _color1.R);
            byte g = (byte)((1 - depth) * _color0.G + depth * _color1.G);
            byte b = (byte)((1 - depth) * _color0.B + depth * _color1.B);

            // Ignore the alpha value and set it to 255 (fully opaque)
            byte a = 255;

            return Color.FromArgb(a, r, g, b);
        }
    }
}