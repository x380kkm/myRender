using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

public class TgaImage
{
    private Image<Rgba32> _image;

    public TgaImage(string filePath)
    {
        _image = Image.Load<Rgba32>(filePath);
    }

    public Rgba32 GetPixelColor(int x, int y)
    {
        return _image[x, y];
    }
}