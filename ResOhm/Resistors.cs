using System;
using System.Collections.Generic;

public abstract class Resistor
{
    private string band1;
    private string band2;
    private string multiplier;
    private double resistorValue;

	
    // Minimum number of bands is 3; constructor forces minimum of these values to be passed to it
    protected Resistor(string band1, string band2, string multiplier)
    {
        this.band1 = band1;
        this.band2 = band2;
        this.multiplier = multiplier;
        resistorValue = CalculateResistance();
    }
	
    //Can override virtual method when we have more than 3 bands 
    public virtual double CalculateResistance()
    {
       return ( 10*significantFigures[index1] +　significantFigures[index2]　)* Math.Pow(10, significantFigures[index3] );
    }

    public double Resistance() 
    { 
            return resistorValue;   
    }
	
}

public class ThreeBandResistor : Resistor {
	private ThreeBandResistor(string band1, string band2, string multiplier) : base(band1, band2, multiplier)
    {

    }
	

	
}
//Store code to be moved to interface with GUI
public class Temp
{
    protected string[] color = { "Black", "Brown", "Red", "Orange", "Yellow", "Green", "Blue", "Violet", "Gray", "White" };
    protected int[] significantFigures = new int[10];
    protected int index1;
    protected int index2;
    protected int index3;

    Dictionary<string, double> Resistors = new Dictionary<string, double>();
		
        // We can just hard code values, no need to create new array to do this
		for(int i = 0; i<significantFigures.Length; i ++) {
			significantFigures[i] = i;
		}
		
		for(int j = 0; j<significantFigures.Length; j ++) {
			Resistors.Add(color[j],significantFigures[j]);
		}
		
    //GUI will take care of error checking (in fact, if we put in a dropdown list or radio button then the user cannot possibly pass in incorrect values
		try {
			index1 = (int) Resistors[band1] ;
			index2 = (int) Resistors[band2] ;
			index3 = (int) Resistors[multiplier] ;
		
			resistorValue = CalculateResistance();
			//Console.WriteLine("The resistance is {0}", resistorValue);
		}
		catch(Exception e) {
			//Console.WriteLine("Sorry, you entries are not valid");
		}
	
}

public class Demo{
	static void Main(){
	double resistance;
	
	Console.WriteLine("Please enter the color of first value band: ");
	string band1 = Console.ReadLine();
	
	Console.WriteLine("Please enter the color of second value band: ");
	string band2 = Console.ReadLine();
	
	Console.WriteLine("Please enter the color of multiplier band: ");
	string multiplier = Console.ReadLine();
	
		ThreeBandResistor a = new ThreeBandResistor(band1, band2, multiplier);	
	
	resistance = a.Resistance();
	
	Console.WriteLine("Resistance: {0} ohms", resistance);
		
	}
	
}

/*public class Resistance {
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
} */