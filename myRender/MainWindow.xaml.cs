using System.Windows;
using System.Windows.Media;
using myRender.renderPac;
using System.Numerics;
using Pac.Tool.Art3D._OBJ;
namespace myRender;
/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        /*draw line
        var modelRenderer = new ModelRenderer(MyCanvas);
        modelRenderer.Draw3DModel("read/african_head.obj",300,300);
        */
        //DrawTriangle
        Class2.DrawTriangle(MyCanvas, Colors.Red, new Vector2(100, 100), new Vector2(210, 400), new Vector2(305, 210));
        
    }
    
}
