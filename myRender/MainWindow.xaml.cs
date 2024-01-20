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
        private Renderer renderer;
        private ModelRenderer modelRenderer;
        private ObjModel model;

        public MainWindow()
        {
            InitializeComponent();
            var objFileReader = new ObjFileReader();
            model = objFileReader.ReadFile("read/african_head.obj");
            var tgadealer = new TGADealer("read/african_head_diffuse.tga");
            renderer = new Renderer((int)MyCanvas.Width, (int)MyCanvas.Height, tgadealer);
            Vector3 lightVector = new Vector3(0, 0, 1);
            lightVector = Vector3.Normalize(lightVector);

            var class2 = new Class2(renderer, lightVector, tgadealer);
            MyImage.Source = renderer.ImageSource;

            Vector3 min = new Vector3(float.MaxValue, float.MaxValue, float.MaxValue);
            Vector3 max = new Vector3(float.MinValue, float.MinValue, float.MinValue);
            foreach (var vertex in model.Vertices)
            {
                min = Vector3.Min(min, new Vector3(vertex.X, vertex.Y, vertex.Z));
                max = Vector3.Max(max, new Vector3(vertex.X, vertex.Y, vertex.Z));
            }

            Triangle3D.Min3D = min;
            Triangle3D.Max3D = max;

            MyImage.Source = renderer.ImageSource;

            var startColor = Colors.Red;
            var endColor = Colors.Blue;
            var colorGradient = new ColorGradient(startColor, endColor);

            modelRenderer =
                new ModelRenderer(renderer, (int)MyCanvas.Width / 8, (int)MyCanvas.Height / 8, lightVector, tgadealer);
            modelRenderer.RenderModel(model);

            renderer.Render();

            this.Show();
        }

        private void RotateDownButton_Click(object sender, RoutedEventArgs e)
        {
            RotateModel(Matrix4x4.CreateRotationX(MathF.PI / 30));
        }

        private void RotateUpButton_Click(object sender, RoutedEventArgs e)
        {
            RotateModel(Matrix4x4.CreateRotationX(-MathF.PI / 30));
        }

        private void RotateLeftButton_Click(object sender, RoutedEventArgs e)
        {
            RotateModel(Matrix4x4.CreateRotationY(MathF.PI / 30));
        }

        private void RotateRightButton_Click(object sender, RoutedEventArgs e)
        {
            RotateModel(Matrix4x4.CreateRotationY(-MathF.PI / 30));
        }
        
        private void MoveDownButton_Click(object sender, RoutedEventArgs e)
        {
            MoveModel(new Vector3(0, 0.3f, 0)); // 这里的Vector3(0, 1, 0)表示在Y轴方向上移动
        }

        private void MoveUpButton_Click(object sender, RoutedEventArgs e)
        {
            MoveModel(new Vector3(0, -0.3f, 0)); // 这里的Vector3(0, -1, 0)表示在Y轴方向上移动
        }

        private void MoveRightButton_Click(object sender, RoutedEventArgs e)
        {
            MoveModel(new Vector3(-0.3f, 0, 0)); // 这里的Vector3(-1, 0, 0)表示在X轴方向上移动
        }

        private void MoveLeftButton_Click(object sender, RoutedEventArgs e)
        {
            MoveModel(new Vector3(0.3f, 0, 0)); // 这里的Vector3(1, 0, 0)表示在X轴方向上移动
        }

        private void ScaleUpButton_Click(object sender, RoutedEventArgs e)
        {
            ScaleModel(1.1f); // 这里的1.1f表示将模型的大小增加10%
        }

        private void ScaleDownButton_Click(object sender, RoutedEventArgs e)
        {
            ScaleModel(0.9f); // 这里的0.9f表示将模型的大小减少10%
        }

        private void MoveModel(Vector3 direction)
        {
            for (int i = 0; i < model.Vertices.Count; i++)
            {
                var vertex = model.Vertices[i];
                var position = new Vector3(vertex.X, vertex.Y, vertex.Z);
                position += direction; // 在指定方向上移动模型
                model.Vertices[i] = new Vertex(position.X, position.Y, position.Z);
            }

            renderer.Clear();

            modelRenderer.RenderModel(model);

            renderer.Render();
        }

        private void ScaleModel(float scaleFactor)
        {
            for (int i = 0; i < model.Vertices.Count; i++)
            {
                var vertex = model.Vertices[i];
                var position = new Vector3(vertex.X, vertex.Y, vertex.Z);
                position *= scaleFactor; // 缩放模型
                model.Vertices[i] = new Vertex(position.X, position.Y, position.Z);
            }

            renderer.Clear();

            modelRenderer.RenderModel(model);

            renderer.Render();
        }

        private void RotateModel(Matrix4x4 rotationMatrix)
        {
            for (int i = 0; i < model.Vertices.Count; i++)
            {
                var vertex = model.Vertices[i];
                var position = new Vector3(vertex.X, vertex.Y, vertex.Z);
                position = Vector3.Transform(position, rotationMatrix);
                model.Vertices[i] = new Vertex(position.X, position.Y, position.Z);
            }

            renderer.Clear();

            modelRenderer.RenderModel(model);

            renderer.Render();
        }
    }
}