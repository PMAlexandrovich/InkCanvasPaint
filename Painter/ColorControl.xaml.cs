using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Painter
{
    /// <summary>
    /// Логика взаимодействия для ColorControl.xaml
    /// </summary>
    public partial class ColorControl : UserControl
    {
        public ColorControl()
        {
            
            InitializeComponent();
        }

        byte r=255, g=255, b=255, a=255;

        public byte A
        {
            get { return a; }
            set
            {
                a = (byte)value;
                Color = Color.FromArgb(a, r, g, b);
            }
        }
        public byte R
        {
            get { return r; }
            set
            {
                r = (byte)value;
                Color = Color.FromArgb(a, r, g, b);
            }
        }
        public byte G
        {
            get { return g; }
            set
            {
                g = (byte)value;
                Color = Color.FromArgb(a, r, g, b);
            }
        }
        public byte B
        {
            get { return b; }
            set
            {
                b = (byte)value;
                Color = Color.FromArgb(a, r, g, b);
            }
        }

        public Color Color
        {
            get { return (Color)GetValue(ColorProperty); }
            set { SetValue(ColorProperty, value); }
        }

        public static readonly DependencyProperty ColorProperty =
            DependencyProperty.Register("Color", typeof(Color), typeof(ColorControl));


    }
}
