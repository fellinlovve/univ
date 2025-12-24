using System;

public class Car : ICalculate, IVisual
{
    private string Manufacturer;
    private string Model;
    private int Velocity;

    public Car(string pManufacturer, string pModel, int pVelocity)
    {
        Manufacturer = pManufacturer;
        Model = pModel;
        Velocity = pVelocity;
    }

    public void Plus(int pPlus)
    {
        Velocity += pPlus;
    }

    public void Minus(int pMinus)
    {
        Velocity -= pMinus; // Исправлено: должно быть вычитание
    }

    public string Name
    {
        get { return Manufacturer + " - " + Model + " : " + Velocity.ToString() + " km/h"; }
        set { Model = value; }
    }

    public void DrawObject()
    {
        Console.WriteLine(
            "    ________\n" +
            " __|\\      /|__\n" +
            "| --(@)----(@)--| \n"
        );
        Console.WriteLine(Name);
    }
}
