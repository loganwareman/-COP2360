using System;

public enum RectangleType
{
    Square,
    Golden,
    Custom
}

public interface IShape
{
    float GetArea();
    float GetPerimeter();
    RectangleType Type { get; }
}

public class Rectangle : IShape
{
    public readonly float Width;
    public readonly float Height;

    public Rectangle(float width, float height)
    {
        Width = width;
        Height = height;
    }

    public void Deconstruct(out float width, out float height)
    {
        width = Width;
        height = Height;
    }

    public float GetArea() => Width * Height;

    public float GetPerimeter() => 2 * (Width + Height);

    public RectangleType Type =>
        Width == Height ? RectangleType.Square :
        Math.Abs(Width / Height - 1.618f) < 0.01f ? RectangleType.Golden :
        RectangleType.Custom;

    public override string ToString()
    {
        return $"Rectangle: {Width} x {Height}, Type: {Type}, Area: {GetArea()}, Perimeter: {GetPerimeter()}";
    }
}

class Program
{
    static void Main()
    {
        var rect = new Rectangle(3f, 4f);

        var (w, h) = rect;
        Console.WriteLine($"Deconstructed: Width = {w}, Height = {h}");

        Console.WriteLine(rect);

        IShape shape = rect;
        Console.WriteLine($"Area: {shape.GetArea()}");
        Console.WriteLine($"Perimeter: {shape.GetPerimeter()}");
        Console.WriteLine($"Type: {shape.Type}");
        Console.WriteLine("Press Any Key to Close");
        Console.ReadLine();
    }
}


