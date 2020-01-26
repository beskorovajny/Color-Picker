using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection;
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
using System.Xml.Serialization;

namespace Color_Picker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static string PATH = @"D:\ColorPicker.xml";
        private Colors colorsList = new Colors();
        Color pick;
        SolidColorBrush solidColorBrush;
        
        public MainWindow()
        {
            InitializeComponent();
            if (colorListView.Items.Count > 0)
            {
                delete.IsEnabled = true;
                if (colorListView.SelectedItem != null)
                {
                    ColorBlock.Background = (SolidColorBrush)colorListView.SelectedItem;
                }
            }

        }

        private void AddColor_Click(object sender, RoutedEventArgs e)
        {
            delete.IsEnabled = true;

            solidColorBrush = (SolidColorBrush)ColorBlock.Background;
            pick = solidColorBrush.Color;

            listColors.Items.Clear();


            colorsList.Items.Add(new Items()
            {
                color = pick
            }) ;

            foreach(var item in colorsList.Items)
            {
                listColors.Items.Add(item);
            }

        }

        private void BlueSlide_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            UpdateColorBox();
            AddColor.IsEnabled = true;
        }

        private void GreenSlide_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            UpdateColorBox();
            AddColor.IsEnabled = true;
        }

        private void RedSlide_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            UpdateColorBox();
            AddColor.IsEnabled = true;
        }

        private void AlphaSlide_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            UpdateColorBox();
            AddColor.IsEnabled = true;
        }
        private void UpdateColorBox()
        {
            Color color = new Color();
            if (AlphaCheck.IsChecked == false)
            {
               color = Color.FromArgb(Convert.ToByte(AlphaSlide.Maximum),
               Convert.ToByte(RedSlide.Value),
               Convert.ToByte(GreenSlide.Value),
               Convert.ToByte(BlueSlide.Value)
               );
            }
           
            else if(RedCheck.IsChecked == false)
            {
                    color = Color.FromArgb(Convert.ToByte(AlphaSlide.Value),
                    Convert.ToByte(RedSlide.Minimum),
                    Convert.ToByte(GreenSlide.Value),
                    Convert.ToByte(BlueSlide.Value)
                    );
            }
           
            else if(GreenCheck.IsChecked == false)
            {
                color = Color.FromArgb(Convert.ToByte(AlphaSlide.Value),
                   Convert.ToByte(RedSlide.Value),
                   Convert.ToByte(GreenSlide.Minimum),
                   Convert.ToByte(BlueSlide.Value)
                   );
            }
           
           
            else if(BlueCheck.IsChecked == false)
            {
                color = Color.FromArgb(Convert.ToByte(AlphaSlide.Value),
                  Convert.ToByte(RedSlide.Value),
                  Convert.ToByte(GreenSlide.Value),
                  Convert.ToByte(BlueSlide.Minimum)
                  );
            }
            else
            {
                color = Color.FromArgb(Convert.ToByte(AlphaSlide.Value),
                 Convert.ToByte(RedSlide.Value),
                 Convert.ToByte(GreenSlide.Value),
                 Convert.ToByte(BlueSlide.Value)
                 );
            }
            ColorBlock.Background = new SolidColorBrush(color);
        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
           
                if (listColors.SelectedItem != null)
                {
                    colorsList.Items.RemoveAt(listColors.SelectedIndex);
                    listColors.Items.Clear();
                }
                foreach(var item in colorsList.Items)
            {
                listColors.Items.Add(item);
            }
            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
           
            
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            
        }
    }
}
