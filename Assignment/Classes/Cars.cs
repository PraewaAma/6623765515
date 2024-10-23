using System;

namespace Assignment.Classes;

public class Cars
{
    // Field
    public string Brand;
    public string Model;
    public double  Speed;
    public double  Fuel;
    public double  TotalMile;
    public double UseFuelRate;


    // Constructor 
    public Cars(string Brand,string Model,double Speed,double Fuel,double TotalMile,double UseFuelRate)
    {
        this.Brand = Brand;
        this.Model = Model;
        this.Speed = Speed;
        this.Fuel = Fuel;
        this.TotalMile = TotalMile;
        this.UseFuelRate = UseFuelRate;
    }

    // Method
    public void Drive(double Mile)
    {
        this.TotalMile += Mile;
        var FuelUsed = Mile * this.UseFuelRate;
        this.Fuel = this.Fuel - FuelUsed;
    }

    public uint TimeUsedforDrive(double Mile)
    {
        var TimeUsed = Mile/Speed;
        this.Drive(Mile);
        return Convert.ToUInt16(TimeUsed);
    }

    public string ShowInfoCar()
    {
        var InfoCars = $"Brands : {this.Brand} \n Model : {this.Model} \n Speed : {this.Speed} \n Fuel : {this.Fuel} \n Total Mile : {this.TotalMile} \n Fuel Used Rate : {this.UseFuelRate}";
        return InfoCars;
    }

}
