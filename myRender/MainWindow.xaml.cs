using System.Windows;
using myRender.renderPac;
using System.Numerics;
using System.Windows.Media;
using Pac.Tool.Math;

namespace myRender
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var renderer = new Renderer((int)MyCanvas.Width, (int)MyCanvas.Height);
            var class2 = new Class2(renderer);
            Triangle3D.Min3D = new Vector3(-2, -2, -2);
            Triangle3D.Max3D = new Vector3(2, 2, 2);
            MyImage.Source = renderer.ImageSource; // 将 Renderer 对象的 ImageSource 属性设置为 Image 元素的 Source 属性
            // 创建一个大的三角形
            var triangle3D1 = new Triangle3D(
                new Vector3(-1, -1, 0),
                new Vector3(1, -1, 0),
                new Vector3(0, 1, 0)
            );

            // 创建一个小的三角形，部分地从大的三角形中钻出
            var triangle3D2 = new Triangle3D(
                new Vector3(-0.5f, -0.5f, 0.5f),
                new Vector3(0.5f, -0.5f, 0.5f),
                new Vector3(0, 0.5f, 0.5f)
            );

            // 使用 Class2 的 FillTriangle 方法来填充这两个三角形
            class2.FillTriangle3D(triangle3D1, Colors.Red, new Vector2((int)MyCanvas.Width, (int)MyCanvas.Height));
            class2.FillTriangle3D(triangle3D2, Colors.Blue, new Vector2((int)MyCanvas.Width, (int)MyCanvas.Height));

            
            
            // 调用 Renderer 的 Render 方法来更新图像
            renderer.Render();

            this.Show();
        }
    }
}