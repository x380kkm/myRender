using System.Windows;
using myRender.renderPac;
using System.Numerics;
using System.Windows.Media;
using myRender.renderPac.myColor;
using Pac.Tool.Math;
using Pac.Tool.Art3D._OBJ;

namespace myRender
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {   Console.WriteLine("MainWindow constructor start");
            // ...您的代码...
            
            InitializeComponent();
            var renderer = new Renderer((int)MyCanvas.Width, (int)MyCanvas.Height);
            var class2 = new Class2(renderer);
            MyImage.Source = renderer.ImageSource; // 将 Renderer 对象的 ImageSource 属性设置为 Image 元素的 Source 属性
        
           //创建一个 ObjFileReader 实例并读取 .obj 文件
           var objFileReader = new ObjFileReader();
           var model = objFileReader.ReadFile("C:\\Users\\30705\\RiderProjects\\myRender\\myRender\\bin\\Debug\\net8.0-windows\\read\\african_head.obj");
           
           // 计算模型的最大和最小顶点
           Vector3 min = new Vector3(float.MaxValue, float.MaxValue, float.MaxValue);
           Vector3 max = new Vector3(float.MinValue, float.MinValue, float.MinValue);
           foreach (var vertex in model.Vertices)
           {
               min = Vector3.Min(min, new Vector3(vertex.X, vertex.Y, vertex.Z));
               max = Vector3.Max(max, new Vector3(vertex.X, vertex.Y, vertex.Z));
           }

           // 设置 Triangle3D 的最大和最小值
           Triangle3D.Min3D = min;
           Triangle3D.Max3D = max;
           
           
           MyImage.Source = renderer.ImageSource; // 将 Renderer 对象的 ImageSource 属性设置为 Image 元素的 Source 属性

           //// 创建一个 ColorGradient 实例
           //var startColor = Colors.Red; // 渐变的起始颜色
           //var endColor = Colors.Blue; // 渐变的结束颜色
           //var colorGradient = new ColorGradient(startColor, endColor);

           // 创建一个 ModelRenderer 实例并渲染模型
           var modelRenderer = new ModelRenderer(renderer, (int)MyCanvas.Width / 8, (int)MyCanvas.Height / 8);
           modelRenderer.RenderModel(model);

           // 调用 Renderer 的 Render 方法来更新图像
           renderer.Render();
           
          // 创建一个三角形
        // var triangle3D = new Triangle3D(
        //     new Vector3(0, 0, 0),
        //     new Vector3(1, 0, 0),
        //     new Vector3(0, 1, 0)
        // );
        // 
          //class2.FillTriangle3D(triangle3D, new Vector2((int)MyCanvas.Width, (int)MyCanvas.Height));
          // 调用 Renderer 的 Render 方法来更新图像
          //renderer.Render();
          this.Show();
          Console.WriteLine("MainWindow constructor end");
        }
    }
}