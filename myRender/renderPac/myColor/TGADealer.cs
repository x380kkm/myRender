using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using System.Numerics;
using Color = System.Windows.Media.Color;

namespace myRender.renderPac.myColor
{
    // ReSharper disable once InconsistentNaming
    public class TGADealer
    {
        private Image<Rgba32> _image;

        public TGADealer(string filePath)
        {
            _image = Image.Load<Rgba32>(filePath);
        }

        public Color GetPixelColor(int x, int y)
        {
            x = Math.Abs(x) % _image.Width;
            y = Math.Abs(y) % _image.Height;

            Rgba32 pixelColor = _image[x, y];
            return Color.FromArgb(pixelColor.A, pixelColor.R, pixelColor.G, pixelColor.B);
        }
        // 新增的方法，用于处理纹理坐标
        // ReSharper disable once InconsistentNaming
        public Color GetPixelColorFromUV(Vector2 uv)
        {
            // 将纹理坐标映射到图像的宽度和高度
            int x = (int)(uv.X * _image.Width);
            int y = (int)(uv.Y * _image.Height);

            // 由于UV坐标的原点在左下角，而图像的原点在左上角，所以需要翻转y坐标
            y = _image.Height - y - 1;

            // 返回对应的像素颜色
            return GetPixelColor(x, y);
        }
    }
}