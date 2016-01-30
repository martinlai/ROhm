using System;
using System.Collections.Generic;

public abstract class Resistor
{
    private double band1;
    private double band2;
    private double multiplier;
    private double resistorValue;
    // Minimum number of bands is 3; constructor forces minimum of these values to be passed to it
    protected Resistor(double band1, double band2, double multiplier)
    {
        this.band1 = band1;
        this.band2 = band2;
        this.multiplier = multiplier;
        resistorValue = CalculateResistance();
    }
    //Can override virtual method when we have more than 3 bands 
    public virtual double CalculateResistance()
    {
        return ((band1 + 10 * band2) * multiplier);
    }

    public double Resistance() 
    {
            return resistorValue;   
    }
  

}

public class Resistance {
	public static void Main() {
		
		Dictionary<string, double> Resistors = new Dictionary<string, double>();
		
		string[] color = {"Black", "Brown", "Red", "Orange", "Yellow", "Green", "Blue", "Violet", "Gray", "White"};
		int[] significantFigures = new int[10];
		double resistorValue;
		
		for(int i = 0; i < significantFigures.Length; i ++) {
			significantFigures[i] = i;
		}
		
		for(int j = 0; j < significantFigures.Length; j ++) {
			Resistors.Add(color[j],significantFigures[j]);
			//Console.WriteLine( "color: {0, 6}" + " Figure: {1, 2}", color[j], significantFigures[j] );
		}
		
		
		Console.WriteLine("Please enter the left most color band: ");
		string color1 = Console.ReadLine();
		Console.WriteLine("Please enter the second color band: ");
		string color2 = Console.ReadLine();
		try {
		int x = (int) Resistors[color1] ;
		int y = (int) Resistors[color2] ;
		
			resistorValue = significantFigures[x] * Math.Pow(10, significantFigures[y]);
	         Console.WriteLine("The resistance is {0}", resistorValue);
		}
		catch(Exception e) {
			Console.WriteLine("Sorry, you entries are not valid");
		}
	}
}