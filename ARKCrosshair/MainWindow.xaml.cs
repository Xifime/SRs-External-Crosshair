using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace ARKCrosshair
{
    public partial class MainWindow : Window
    {
        public Window w3;

        public MainWindow()
        {
            InitializeComponent();
            Window w = new Window();
            double size = 64;
            double width = (System.Windows.SystemParameters.PrimaryScreenWidth / 2) - (size / 2);
            double height = (System.Windows.SystemParameters.PrimaryScreenHeight / 2) - (size / 2);
            w.Title = "Crosshair";
            w.Width = size;
            w.Height = size;
            w.Top = height;
            w.Left = width;
            w.AllowsTransparency = true;
            w.WindowStyle = WindowStyle.None;
            w.Topmost = true;
            w.Background = null;
            w.ShowInTaskbar = false;
            w.Show();
            w.Hide();
            w3 = w;
            Window w1 = new Window();
            w.Title = "CrosshairHandler";
            w1.Top = -100;
            w1.Left = -100;
            w1.Width = 1;
            w1.Height = 1;
            w1.WindowStyle = WindowStyle.ToolWindow;
            w1.ShowInTaskbar = false;
            w1.Show();
            w.Owner = w1;
            w1.Hide();
        }

        private void OnUIClose(object sender, EventArgs e)
        {
            Environment.Exit(1);
        }

        private void OnCHairDragEnter(object sender, DragEventArgs e)
        {
            
        }

        private void OnCHairDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                // Note that you can have more than one file.
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                Img.Source = new BitmapImage(new Uri(files[0].ToString()));
                ImageBrush myBrush = new ImageBrush();
                myBrush.ImageSource = new BitmapImage(new Uri(files[0].ToString()));
                w3.Background = myBrush;
            }
        }

        private void Disable(object sender, RoutedEventArgs e)
        {
            w3.Hide();
        }

        private void Enable(object sender, RoutedEventArgs e)
        {
            w3.Show();
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                double size = Convert.ToInt16(Size.Text);
                w3.Width = size;
                w3.Height = size;
                double width = (System.Windows.SystemParameters.PrimaryScreenWidth / 2) - (size / 2);
                double height = (System.Windows.SystemParameters.PrimaryScreenHeight / 2) - (size / 2);
                w3.Top = height;
                w3.Left = width;
                MessageBox.Show("Размер установлен!", "Crosshair", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch
            {
                MessageBox.Show("Укажите число!", "Crosshair", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
