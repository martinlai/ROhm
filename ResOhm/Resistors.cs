using System;
using System.Collections.Generic;

public abstract class Resistor
{
    protected double resistance;
    protected double tolerance;
    protected double tempCo;

    //Pass in dictionary containing values of resistor bands based on colour
    public virtual void CalculateValues(double[] Bands)
    {
        resistance = (10*Bands[0] + Bands[1])*Math.Pow(10, Bands[2]);
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
    public override void CalculateValues(double[] Bands)
    {
        resistance = (10*Bands[0] + Bands[1])*Math.Pow(10, Bands[2]);
        tolerance = Bands[3];
    }

    public double Tolerance   { get { return tolerance; } }

}

class FiveBandResistor : Resistor
{
    internal FiveBandResistor() {}
    public override void CalculateValues(double[] Bands)
    {
        resistance = (100*Bands[0] + 10 * Bands[1] + Bands[2]) * Math.Pow(10, Bands[3]);
        tolerance = Bands[4];
    }
    public double Tolerance { get { return tolerance; } }
}

class SixBandResistor : Resistor
{
    internal SixBandResistor() {}
    public override void CalculateValues(double[] Bands)
    {
        resistance = (100 * Bands[0] + 10 * Bands[1] + Bands[2]) * Math.Pow(10, Bands[3]);
        tolerance = Bands[4];
        tempCo = Bands[5];
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