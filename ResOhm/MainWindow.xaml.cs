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
        Dictionary<string, int> resColours = new Dictionary<string, int>();
        Dictionary<string, int> tempColours = new Dictionary<string, int>();
        public Dictionary<string, int> ResColours { get { return resColours; } }
        public Dictionary<string, int> TempColours { get { return tempColours; } }
        public MainWindow()
        {
            InitializeComponent();
            ResultBoxError.Visibility = Visibility.Hidden;
            string[] colours = { "Black", "Brown", "Red", "Orange", "Yellow", "Green", "Blue", "Violet", "Grey", "White" };
         
            for (int i = 0; i < colours.Length; i++)
            {
                resColours.Add(colours[i], i);
            }

            tempColours.Add("Brown", 100);
            tempColours.Add("Red", 50);
            tempColours.Add("Orange", 15);
            tempColours.Add("Yellow", 25);
            tempColours.Add("Blue", 10);
            tempColours.Add("Violet", 5);
           
         
        }

        private void ConvertButton_Click(object sender, RoutedEventArgs e)
        {

            if(NumOfBands.SelectedItem != null) {

                ResultBox.Visibility = Visibility.Visible;
                ResultBoxError.Visibility = Visibility.Hidden;
                int numOfBands = Convert.ToInt32(((ComboBoxItem)NumOfBands.SelectedItem).Content);

                int BandNumber = 0;
                double[] Bands = new double[numOfBands];


                foreach (ComboBox child in ResistorBands.Children)
                {

                    if (child.Visibility == Visibility.Visible)
                    {
                        Bands[BandNumber] = Convert.ToDouble(child.SelectedValue);
                    }
                    BandNumber++;
                }

                ResistorFactory rf = new ResistorFactory();
                Resistor resistor = rf.CreateResistor(numOfBands);
                resistor.CalculateValues(Bands);
                ResultBox.DataContext = resistor;

            }
            else
            {
                ResultBoxError.Visibility = Visibility.Visible;
                ResultBox.Visibility = Visibility.Hidden;
            }


        }


        private void NumOfBands_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ResultBoxError.Visibility = Visibility.Hidden;
            ResultBox.Visibility = Visibility.Visible;
            string numOfBands = ((ComboBoxItem)NumOfBands.SelectedItem).Content.ToString();

            switch (numOfBands)
            {
                case "4":
                    vBand4.Visibility = Visibility.Visible;
                    Band4.Visibility = Visibility.Visible;
                    vBand5.Visibility = Visibility.Hidden;
                    Band5.Visibility = Visibility.Hidden;
                    vBand6.Visibility = Visibility.Hidden;
                    Band6.Visibility = Visibility.Hidden;
                    break;
                case "5":
                    vBand4.Visibility = Visibility.Visible;
                    Band4.Visibility = Visibility.Visible;
                    vBand5.Visibility = Visibility.Visible;
                    Band5.Visibility = Visibility.Visible;
                    vBand6.Visibility = Visibility.Hidden;
                    Band6.Visibility = Visibility.Hidden;
                    break;
                case "6":
                    vBand4.Visibility = Visibility.Visible;
                    Band4.Visibility = Visibility.Visible;
                    vBand5.Visibility = Visibility.Visible;
                    Band5.Visibility = Visibility.Visible;
                    vBand6.Visibility = Visibility.Visible;
                    Band6.Visibility = Visibility.Visible;
                    break;
                default:
                    vBand4.Visibility = Visibility.Hidden;
                    Band4.Visibility = Visibility.Hidden;
                    vBand5.Visibility = Visibility.Hidden;
                    Band5.Visibility = Visibility.Hidden;
                    vBand6.Visibility = Visibility.Hidden;
                    Band6.Visibility = Visibility.Hidden;
                    break;
            }
       
        }

  
    }
}
