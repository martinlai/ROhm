using System;
using System.Collections.Generic;

public abstract class Resistor
{
    protected double resistance;
    protected double tolerance;
    protected double tempCo;

    //Pass in dictionary containing values of resistor bands based on colour
    public virtual void CalculateValues(Dictionary<string, double> Band)
    {
        resistance = (Band["one"] + 10*Band["two"])*Math.Pow(10, Band["multiplier"]);
    }

    public double Resistance{ get { return resistance;  }    }
}

class ThreeBandResistor : Resistor
{
    //internal keyword means that you cannot directly create a ThreeBandResistor without using the factory
    internal ThreeBandResistor() {}

}

class FourBandResistor : Resistor
{
    internal FourBandResistor() {}
    public override void CalculateValues(Dictionary<string, double> Band)
    {
        resistance = (Band["one"] + 10*Band["two"] + 100*Band["three"])*Math.Pow(10, Band["multiplier"]);
        tolerance = Band["tolerance"];
    }

    public double Tolerance   { get { return tolerance; } }

}

class FiveBandResistor : Resistor
{
    internal FiveBandResistor() {}
    public override void CalculateValues(Dictionary<string, double> Band)
    {
        resistance = (Band["one"] + 10 * Band["two"] + 100 * Band["three"] * 1000 * Band["four"]) * Math.Pow(10, Band["multiplier"]);
        tolerance = Band["tolerance"];
    }
    public double Tolerance { get { return tolerance; } }
}

class SixBandResistor : Resistor
{
    internal SixBandResistor() {}
    public override void CalculateValues(Dictionary<string, double> Band)
    {
        resistance = (Band["one"] + 10 * Band["two"] + 100 * Band["three"] * 1000 * Band["four"]) * Math.Pow(10, Band["multiplier"]);
        tolerance = Band["tolerance"];
    }
    public double Tolerance { get { return tolerance; } }
    public double TempCoefficient { get { return tempCo; } }
}

// Enforces resistor creation in resistor factory
abstract class ResistorCreator
{
    public abstract Resistor CreateResistor(int numOfBands);
}

// Factory to decide which type of resistor to create based on number of bands
class ResistorFactory : ResistorCreator
{
    public override Resistor CreateResistor(int numOfBands)
    {
        switch(numOfBands)
        {
            case 3:
                return new ThreeBandResistor();
            case 4:
                return new FourBandResistor();
            case 5:
                return new FiveBandResistor();
            case 6:
                return new SixBandResistor();
            default:
                // If numOfBands was not 3, 4 , 5, 6 there was some error in parameter passing
                throw new ArgumentException("Invalid number of bands, cannot create resistor with " + numOfBands + " bands", "numOfBands");

        }
    }
}