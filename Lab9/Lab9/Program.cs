using System;

// Интерфейс для операций сложения/вычитания
public interface ICalculate
{
    void Plus(int pPlus);
    void Minus(int pMinus);
}

// Интерфейс для отображения объекта
public interface IVisual
{
    void DrawObject();
    string Name { get; set; }
}