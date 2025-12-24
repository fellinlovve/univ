using System;

public class Human : ICalculate, IVisual
{
    private string FIO;
    private int Age;

    public Human(string pFIO, int pAge)
    {
        FIO = pFIO;
        Age = pAge;
    }

    public void Plus(int pPlus)
    {
        Age += pPlus;
    }

    public void Minus(int pMinus)
    {
        Age -= pMinus;
    }

    public string Name
    {
        get { return FIO + " : " + Age.ToString(); }
        set { FIO = value; }
    }

    public void DrawObject()
    {
        Console.WriteLine(
            "  o  \n" +
            " ---- \n" +
            "  |  \n" +
            " / \\ \n"
        );
        Console.WriteLine(Name);
    }
}
