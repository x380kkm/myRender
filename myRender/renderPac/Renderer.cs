using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows;

namespace myRender.renderPac
{
    public class Renderer
    {
        private WriteableBitmap _bitmap;
        private Color[,] _colorData;
        private float[,] _depthBuffer; 

        public Renderer(int width, int height)
        {
            _bitmap = new WriteableBitmap(width, height, 24, 24, PixelFormats.Bgra32, null);
            _colorData = new Color[width, height];
            _depthBuffer = new float[width, height]; 
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    _depthBuffer[x, y] = float.MaxValue; 
                }
            }
        }

        public ImageSource ImageSource => _bitmap;

        public void DrawPoint(int x, int y, float depth)
        {
            if (x < 0 || x >= _colorData.GetLength(0) || y < 0 || y >= _colorData.GetLength(1))
            {
                return;
            }

            if (depth <= _depthBuffer[x, y])
            {
                _colorData[x, y] = DepthToColor(depth);
                _depthBuffer[x, y] = depth;
            }
        }

        private Color DepthToColor(float depth)
        {
            byte colorValue = (byte)(100 + depth * 50); // Map depth to a value between 100 and 150
            return Color.FromRgb(colorValue, colorValue, colorValue);
        }
        
        public void Render()
        {
            for (int x = 0; x < _colorData.GetLength(0); x++)
            {
                for (int y = 0; y < _colorData.GetLength(1); y++)
                {
                    var color = _colorData[x, y];
                    var pixelData = (color.A << 24) | (color.R << 16) | (color.G << 8) | color.B;
                    var rect = new Int32Rect(x, y, 1, 1);
                    _bitmap.WritePixels(rect, new int[] { pixelData }, 4, 0);
                }
            }
        }
    }
}