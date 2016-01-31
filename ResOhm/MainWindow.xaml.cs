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

namespace ResOhm
{
 

    public partial class MainWindow : Window
    {
       
       
        public MainWindow()
        {
            InitializeComponent();
            Dictionary<string, double> ResColours = new Dictionary<string, double>();
            string[] colours = { "Black", "Brown", "Red", "Orange", "Yellow", "Green", "Blue", "Violet", "Grey", "White" };

            for (int i = 0; i < colours.Length; i++)
            {
                ResColours.Add(colours[i], i);
            }
            Grid grid = this.Content as Grid;
            
            ComboBox colourSelector = new ComboBox();
            colourSelector.ItemsSource = ResColours;
            colourSelector.DisplayMemberPath = "Key";
     
            object resBandValue = colourSelector.SelectedItem;
          
         

            grid.Children.Add(colourSelector);
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            
        }


    }
}
