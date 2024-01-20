using System.Numerics;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows;
using myRender.renderPac.myColor;

namespace myRender.renderPac
{
    public class Renderer
    {
        private WriteableBitmap _bitmap;
        private Color[,] _colorData;
        private float[,] _depthBuffer; 
        private TGADealer _tgaDealer;
        public Renderer(int width, int height, TGADealer tgaDealer)
        {
            _tgaDealer = tgaDealer;
            _bitmap = new WriteableBitmap(width, height, 12, 12, PixelFormats.Bgr32, null);
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

        public void DrawPoint(int x, int y, float depth, Vector3 normal, Vector3 lightVector, Color color)
        {
            if (x < 0 || x >= _colorData.GetLength(0) || y < 0 || y >= _colorData.GetLength(1))
            {
                return;
            }

            if (depth <= _depthBuffer[x, y])
            {
                Color diffuseColor = ApplyDiffuse(color, lightVector, normal);
                //_colorData[x, y] = DepthToColor(normal,lightVector);
                _colorData[x, y] =  diffuseColor;
                _depthBuffer[x, y] = depth;
            }
        }

       //private Color DepthToColor(Vector3 normal, Vector3 lightVector)
       //{
       //    // 计算三角形的法线和光照矢量的点乘
       //    float lightIntensity = Vector3.Dot(normal, lightVector);

       //    // 如果点乘的结果为负，将其设为0
       //    lightIntensity = System.Math.Max(0, lightIntensity);
       //    // 使用点乘的结果和光照强度来计算颜色值
       //    byte colorValue = (byte)(lightIntensity * 255);
       //    return Color.FromRgb(colorValue, colorValue, colorValue);
       //}
        
       public Color ApplyDiffuse(Color color, Vector3 lightVector, Vector3 normal)
       {
           var lightIntensity = Vector3.Dot(normal, lightVector);
           byte r = (byte)(color.R * lightIntensity);
           byte g = (byte)(color.G * lightIntensity);
           byte b = (byte)(color.B * lightIntensity);
           return Color.FromRgb(r, g, b);
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
