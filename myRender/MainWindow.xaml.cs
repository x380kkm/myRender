using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace myRender;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        //pac.Class1.DrawPoint(MyCanvas, 100, 100,10, 10, Colors.Red);
        //pac.Class1.DrawPoint(MyCanvas, 200, 200, 10, 10, Colors.Red);
        pac.Class1.DrawLine(MyCanvas, Colors.Blue, new System.Numerics.Vector2(102, 202), new System.Numerics.Vector2(208, 0));
        pac.Class1.DrawLine(MyCanvas, Colors.Black, new System.Numerics.Vector2(100, 300), new System.Numerics.Vector2(100, 100));
        pac.Class1.DrawLine(MyCanvas, Colors.Yellow, new System.Numerics.Vector2(300, 100), new System.Numerics.Vector2(100, 50));
        
        
    }
    
}
