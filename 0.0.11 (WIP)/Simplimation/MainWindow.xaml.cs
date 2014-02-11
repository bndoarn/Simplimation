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
using System.Windows.Threading;
using System.ComponentModel;

namespace Simplimation
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public FrameStack proj = new FrameStack();

        private int index = 0;
        private int thecount = 0;
        private bool playing = false;
        private bool paused = false;
        private int selex = 0;
        private DispatcherTimer dispatcherTimer = new DispatcherTimer();
        
        public MainWindow()
        {
            InitializeComponent();

            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);    


        }

        /*private void playtime_clock_tick(object sender, EventArgs e)
        {
            if (PlayTime.Value != PlayTime.Maximum)
            {
                PlayTime.Value = PlayTime.Value + 10;
            }
            else
            {
                playtime_clock.Stop();
                delaybox.IsEnabled = true;
            }
        }
        */

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            if (thecount < proj.working.Count() - 1)
            {
                playing = true;
                thecount++;
                var switcho = proj.working[thecount].src;
                BitmapImage Changement = new BitmapImage(new Uri(switcho));
                int timing = proj.working[thecount].delay;
                dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, timing);
                Big.Source = Changement;


            }
            else
            {
                playing = false;
                dispatcherTimer.Stop();
                thecount = -1;
               
                Play_Button.Source = new BitmapImage(new Uri("pack://application:,,,/Simplimation;component/graphics/play_o.png"));
           

            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog fileload = new Microsoft.Win32.OpenFileDialog();
            fileload.FileName = ""; // Default file name
            fileload.DefaultExt = ""; // Default file extension
            fileload.Filter = "PNG Image Files (.png)|*.png"; // Filter files by extension
            fileload.Multiselect = true;
            Nullable<bool> result = fileload.ShowDialog();

            if (result == true)
            {
                // Open document
                int reads = fileload.FileNames.Count();
                int cur = 0;
                foreach (String file in fileload.FileNames)
                {
                    string filename = fileload.FileNames[cur];



                    frame save = new frame()
                    {
                        src = filename,
                        delay = 100,
                    };

                    proj.append(save);
                    if (cur < reads)
                    {
                        cur++;
                    }
                }

                index = proj.working.Count();
                if (index > 5)
                {
                    index = index - 5;
                }
                else
                {
                    index = 0;
                }
                reconfig_bench();
            }
        }

        private void reconfig_bench()
        {

            //frame 1
                try
                {
                    prev1.Source = new BitmapImage(new Uri(proj.working[index].src));
                    f1_delay.Text = proj.working[index].delay.ToString();
                }
                catch 
                {
                    prev1.Source = new BitmapImage(new Uri("pack://application:,,,/Simplimation;component/graphics/nonbut.png"));
                    f1_delay.Text = "20";
                }
            //frame 2
                try
                {
                    prev2.Source = new BitmapImage(new Uri(proj.working[index + 1].src));
                    f2_delay.Text = proj.working[index + 1].delay.ToString();
                }
                catch 
                {
                    prev2.Source = new BitmapImage(new Uri("pack://application:,,,/Simplimation;component/graphics/nonbut.png"));
                    f2_delay.Text = "20";
                }
            //frame 3
                try
                {
                    prev3.Source = new BitmapImage(new Uri(proj.working[index + 2].src));
                    f3_delay.Text = proj.working[index + 2].delay.ToString();
                }
                catch 
                {
                    prev3.Source = new BitmapImage(new Uri("pack://application:,,,/Simplimation;component/graphics/nonbut.png"));
                    f3_delay.Text = "20";
                }
            //frame 4
                try
                {
                    prev4.Source = new BitmapImage(new Uri(proj.working[index + 3].src));
                    f4_delay.Text = proj.working[index + 3].delay.ToString();
                }
                catch 
                {
                    prev4.Source = new BitmapImage(new Uri("pack://application:,,,/Simplimation;component/graphics/nonbut.png"));
                    f4_delay.Text = "20";
                }
            //frame 5
                try
                {
                    prev5.Source = new BitmapImage(new Uri(proj.working[index + 4].src));
                    f5_delay.Text = proj.working[index + 4].delay.ToString();
                }
                catch 
                {
                    prev5.Source = new BitmapImage(new Uri("pack://application:,,,/Simplimation;component/graphics/nonbut.png"));
                    f5_delay.Text = "20";
                }

                slot1_fn.Content = index.ToString();
                slot2_fn.Content = (index + 1).ToString();
                slot3_fn.Content = (index + 2).ToString();
                slot4_fn.Content = (index + 3).ToString();
                slot5_fn.Content = (index + 4).ToString();

        }

        private void _adv_Click(object sender, RoutedEventArgs e)
        {
            if (proj.working.Count() > 5)
            {
                index++;
                reconfig_bench();
                Hi_1.BorderBrush = Brushes.Black;
                Hi_2.BorderBrush = Brushes.Black;
                Hi_3.BorderBrush = Brushes.Black;
                Hi_4.BorderBrush = Brushes.Black;
                Hi_5.BorderBrush = Brushes.Black;
                
            }

        
        }

        private void _prev_Click(object sender, RoutedEventArgs e)
        {

            if (index > 0)
            {
                index--;
                reconfig_bench();
                Hi_1.BorderBrush = Brushes.Black;
                Hi_2.BorderBrush = Brushes.Black;
                Hi_3.BorderBrush = Brushes.Black;
                Hi_4.BorderBrush = Brushes.Black;
                Hi_5.BorderBrush = Brushes.Black;

            }
        }

        private void im_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Hi_1.BorderBrush = Brushes.Black;
            Hi_2.BorderBrush = Brushes.Black;
            Hi_3.BorderBrush = Brushes.Black;
            Hi_4.BorderBrush = Brushes.Black;
            Hi_5.BorderBrush = Brushes.Black;
            try
            {
                if (sender.Equals(prev1))
                {
                    Hi_1.BorderBrush = Brushes.Yellow;
                    Big.Source = new BitmapImage(new Uri(proj.working[index].src));
                    selex = 0;
                }

                if (sender.Equals(prev2))
                {
                    Hi_2.BorderBrush = Brushes.Yellow;
                    Big.Source = new BitmapImage(new Uri(proj.working[index + 1].src));
                    selex = 1;
                }

                if (sender.Equals(prev3))
                {
                    Hi_3.BorderBrush = Brushes.Yellow;
                    Big.Source = new BitmapImage(new Uri(proj.working[index + 2].src));
                    selex = 2;
                }

                if (sender.Equals(prev4))
                {
                    Hi_4.BorderBrush = Brushes.Yellow;

                    Big.Source = new BitmapImage(new Uri(proj.working[index + 3].src));
                    selex = 3;

                }

                if (sender.Equals(prev5))
                {
                    Hi_5.BorderBrush = Brushes.Yellow;
                    Big.Source = new BitmapImage(new Uri(proj.working[index + 4].src));
                    selex = 4;
                }
            }
            catch
            {
                Big.Source = new BitmapImage(new Uri("pack://application:,,,/Simplimation;component/graphics/nonbut.png"));
            }
        }

        private void delay_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (sender.Equals(f1_delay))
                {
                    proj.working[index].delay = Convert.ToInt32(f1_delay.Text);
                }

                if (sender.Equals(f2_delay))
                {
                    proj.working[index + 1].delay = Convert.ToInt32(f2_delay.Text);
                }

                if (sender.Equals(f3_delay))
                {
                    proj.working[index + 2].delay = Convert.ToInt32(f3_delay.Text);
                }

                if (sender.Equals(f4_delay))
                {
                    proj.working[index + 3].delay = Convert.ToInt32(f4_delay.Text);
                }

                if (sender.Equals(f5_delay))
                {
                    proj.working[index + 4].delay = Convert.ToInt32(f5_delay.Text);
                }
            }
            catch
            {
                //do nothing
            }
        }

        private void Add_it_MouseEnter(object sender, MouseEventArgs e)
        {
            Add_it.Source = new BitmapImage(new Uri("pack://application:,,,/Simplimation;component/graphics/new_image_lite.png"));
        }

        private void Add_it_MouseLeave(object sender, MouseEventArgs e)
        {
            Add_it.Source = new BitmapImage(new Uri("pack://application:,,,/Simplimation;component/graphics/new_image.png"));
        }

        private void rem_it_MouseEnter(object sender, MouseEventArgs e)
        {
            rem.Source = new BitmapImage(new Uri("pack://application:,,,/Simplimation;component/graphics/rem_glow.png"));
        }

        private void rem_it_MouseLeave(object sender, MouseEventArgs e)
        {
            rem.Source = new BitmapImage(new Uri("pack://application:,,,/Simplimation;component/graphics/rem.png"));
        }


        private void Play_Button_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Play_Button.Source = new BitmapImage(new Uri("pack://application:,,,/Simplimation;component/graphics/pause_o.png"));
            dispatcherTimer.Start();
            paused = false;
                if (playing == true)
                {
                    dispatcherTimer.Stop();
                    playing = false;
                    paused = true;
                }
        }

        private void Play_Button_MouseEnter(object sender, MouseEventArgs e)
        {

            if (playing == true || paused == true)
            {
                Play_Button.Source = new BitmapImage(new Uri("pack://application:,,,/Simplimation;component/graphics/pause_o.png"));
            }
            else
            {
                Play_Button.Source = new BitmapImage(new Uri("pack://application:,,,/Simplimation;component/graphics/play_o.png")); 
            }
        }

        private void Play_Button_MouseLeave(object sender, MouseEventArgs e)
        {
            if (playing == true || paused == true)
            {
                Play_Button.Source = new BitmapImage(new Uri("pack://application:,,,/Simplimation;component/graphics/pause_i.png"));
            }
            else
            {
                Play_Button.Source = new BitmapImage(new Uri("pack://application:,,,/Simplimation;component/graphics/play_i.png"));
            }
        }

        private void remove_frame()
        {
            
        }

        private void con_beg_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            paused = false;
            if (playing == true)
            {
                dispatcherTimer.Stop();
                playing = false;
                Play_Button.Source = new BitmapImage(new Uri("pack://application:,,,/Simplimation;component/graphics/play_o.png")); 
               
            }
            try
            {
                BitmapImage Changement = new BitmapImage(new Uri(proj.working[0].src));
                Big.Source = Changement;
            }
            catch
            {
                //do nothing
            }
                

        }

        private void con_beg_MouseEnter(object sender, MouseEventArgs e)
        {
            con_beg.Source = new BitmapImage(new Uri("pack://application:,,,/Simplimation;component/graphics/rev_hov.png"));
        }

        private void con_beg_MouseLeave(object sender, MouseEventArgs e)
        {
            con_beg.Source = new BitmapImage(new Uri("pack://application:,,,/Simplimation;component/graphics/rev.png"));
        }

        private void rem_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                proj.working.RemoveAt(index + selex);
                reconfig_bench();
            }
            catch
            {
                //do nothing
            }
            try
            {
                BitmapImage Changement = new BitmapImage(new Uri(proj.working[index + selex].src));
                Big.Source = Changement;
            }
            catch
            {
                Big.Source = new BitmapImage(new Uri("pack://application:,,,/Simplimation;component/graphics/nonbut.png"));
            }
        }

        private void Grid_SizeChanged(object sender, SizeChangedEventArgs e)
        {

        }

    }
}
