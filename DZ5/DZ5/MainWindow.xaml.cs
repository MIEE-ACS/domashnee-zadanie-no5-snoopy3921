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

namespace DZ5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    class Pixel
    {
        public struct Color
        {
            public byte r, g, b;
        }
        private int x, y;
        private Color c;
        public Pixel()
        {
            x = y = 0;
            c.r = c.g = c.b = 252;          
        }
        public Pixel(int x, int y, byte r, byte g, byte b)
        {
            this.x = x;
            this.y = y;
            this.c.r = r;
            this.c.g = g;
            this.c.b = b;
        }
        public int X
        {
            get { return x; }
            set { x = value; }
        }
        public int Y
        {
            get { return y; }       
            set { y = value; }
        }

        public Color getColor() { return c; }
        public void setColor(byte r, byte g, byte b) 
        {
            this.c.r = r;
            this.c.g = g;
            this.c.b = b;
        }
        public void setRed(byte r)
        {
            this.c.r = r;
        }
        public void setGreen(byte r)
        {
            this.c.b = r;
        }
        public void setBlue(byte r)
        {
            this.c.r = r;
        }
        public String toString()
        {   
            return "x:\t"+x.ToString()+"\ny:\t"+y.ToString()+"\nR:\t"+c.r.ToString()+"\nG:\t"+c.g.ToString()+"\nB:\t"+c.b.ToString();
        }
    }

    public partial class MainWindow : Window
    {
        Pixel x = new Pixel(50, 50, 50, 60, 255);
        //Pixel x = new Pixel();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void tb1_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            

            try{
                if (int.Parse(tbX.Text) > 486 || int.Parse(tbX.Text) < 0) { tb1.Text = "X value over range! Reset to 0"; x.X = 0; }
                else x.X = int.Parse(tbX.Text); 
            } catch (Exception err) { tb1.Text = err.Message; }

            try{
                if (int.Parse(tbY.Text) > 291 || int.Parse(tbX.Text) < 0) { tb1.Text = "X value over range! Reset to 0"; x.Y = 0; }
                else x.Y = int.Parse(tbY.Text); 
            } catch (Exception err) { tb1.Text = err.Message; }



            try {
                if (int.Parse(tbR.Text) > 255 || int.Parse(tbR.Text) < 0) { tb1.Text = "Red value over range! Reset to 0"; x.setRed(0); }
                else if (int.Parse(tbG.Text) > 255 || int.Parse(tbG.Text) < 0) { tb1.Text = "Green value over range! Reset to 0"; x.setGreen(0); }
                else if (int.Parse(tbB.Text) > 255 || int.Parse(tbB.Text) < 0) { tb1.Text = "Blue value over range! Reset to 0"; x.setBlue(0); }
                else    x.setColor((byte)int.Parse(tbR.Text), (byte)int.Parse(tbG.Text), (byte)int.Parse(tbB.Text)); 
            } catch (Exception err) { tb1.Text = err.Message; }
            finally
            {
                lb1.Background = new SolidColorBrush(Color.FromArgb(0xFF, x.getColor().r, x.getColor().g, x.getColor().b));
                lb1.Margin = new Thickness(x.X, x.Y, 0, 0);
            }


        }

        private void btn2_Click(object sender, RoutedEventArgs e)
        {
            tb1.Text = x.toString();
            lb1.Background = new SolidColorBrush(Color.FromArgb(0xFF, x.getColor().r, x.getColor().g, x.getColor().b));
            lb1.Margin = new Thickness(x.X, x.Y, 0, 0);
        }
    }
}
