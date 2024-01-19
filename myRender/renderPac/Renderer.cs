using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows;

namespace myRender.renderPac
{
    public class Renderer
    {
        private WriteableBitmap _bitmap;
        private Color[,] _colorData;
        private float[,] _depthBuffer; // 新增的深度缓冲

        public Renderer(int width, int height)
        {
            _bitmap = new WriteableBitmap(width, height, 24, 24, PixelFormats.Bgra32, null);
            _colorData = new Color[width, height];
            _depthBuffer = new float[width, height]; // 初始化深度缓冲
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    _depthBuffer[x, y] = float.MaxValue; // 将深度缓冲的初始值设置为最大值
                }
            }
        }

        public ImageSource ImageSource => _bitmap;

        // 修改 DrawPoint 方法，添加一个深度参数
        public void DrawPoint(int x, int y, Color color, float depth = 0)
        {
            if (x < 0 || x >= _colorData.GetLength(0) || y < 0 || y >= _colorData.GetLength(1))
            {
                return;
            }

            // 只有当新的深度值小于等于深度缓冲中的值时，才更新像素的颜色和深度值
            if (depth <= _depthBuffer[x, y])
            {
                _colorData[x, y] = color;
                _depthBuffer[x, y] = depth;
            }
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