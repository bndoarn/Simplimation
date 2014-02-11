using System;
using System.Collections.Generic;
using System.Linq;
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
using System.ComponentModel;

namespace Simplimation
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public FrameStack proj = new FrameStack();

        public MainWindow()
        {
            InitializeComponent();


            benchgrid.DataContext = proj;


        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog file = new Microsoft.Win32.OpenFileDialog();
            file.FileName = ""; // Default file name
            file.DefaultExt = ""; // Default file extension
            file.Filter = "PNG Image Files (.png)|*.png"; // Filter files by extension

            Nullable<bool> result = file.ShowDialog();

            if (result == true)
            {
                // Open document
                string filename = file.FileName;



                frame save = new frame()
                {
                    src = filename,
                    delay = 200,
                };

                proj.append(ref proj, save);

                benchgrid.ItemsSource.


            }
        }
    }
}
