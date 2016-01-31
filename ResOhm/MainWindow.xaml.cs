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
        Dictionary<string, double> resColours = new Dictionary<string, double>();
        public Dictionary<string, double> ResColours
        {
            get
            {
                return resColours;
            }
        }
      // Source   http://www.nullskull.com/faq/175/binding-wpf-combobox-items-to-dictionary.aspx
        public MainWindow()
        {
            InitializeComponent();
           
            string[] colours = { "Black", "Brown", "Red", "Orange", "Yellow", "Green", "Blue", "Violet", "Grey", "White" };

            for (int i = 0; i < colours.Length; i++)
            {
                resColours.Add(colours[i], i);
            }

       
          
         
        }

        private void ConvertButton_Click(object sender, RoutedEventArgs e)
        {
         
            

            int numOfBands = Convert.ToInt32(((ComboBoxItem)NumOfBands.SelectedItem).Content);
            int BandNumber = 0;
            double[] Bands = new double[numOfBands];
      

            foreach (ComboBox child in ResistorBands.Children)
            {
                
                if(child.Visibility == Visibility.Visible)
                {
                    Bands[BandNumber] = Convert.ToDouble(child.SelectedValue);
                }
                BandNumber++;
            }
  
            ResistorFactory rf = new ResistorFactory();
            Resistor resistor = rf.CreateResistor(numOfBands);
            resistor.CalculateValues(Bands);
            double test = resistor.Resistance;
        

            


        }


        private void NumOfBands_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string numOfBands = ((ComboBoxItem)NumOfBands.SelectedItem).Content.ToString();

            switch (numOfBands)
            {
                case "4":
                    Band4.Visibility = Visibility.Visible;
                    Band5.Visibility = Visibility.Hidden;
                    Band6.Visibility = Visibility.Hidden;
                    break;
                case "5":
                    Band4.Visibility = Visibility.Visible;
                    Band5.Visibility = Visibility.Visible;
                    Band6.Visibility = Visibility.Hidden;
                    break;
                case "6":
                    Band4.Visibility = Visibility.Visible;
                    Band5.Visibility = Visibility.Visible;
                    Band6.Visibility = Visibility.Visible;
                    break;
                default:
                    Band4.Visibility = Visibility.Hidden;
                    Band5.Visibility = Visibility.Hidden;
                    Band6.Visibility = Visibility.Hidden;
                    break;
            }
       
        }


     
    }
}
