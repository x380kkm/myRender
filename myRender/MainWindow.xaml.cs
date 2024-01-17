using System.Windows;
using System.Windows.Media;
using myRender.renderPac;
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
        var modelRenderer = new ModelRenderer(MyCanvas);
        modelRenderer.Draw3DModel("read/african_head.obj",300,300);
        
    }
    
}
