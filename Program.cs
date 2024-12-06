using System;

// Інтерфейс для 3D-системи координат
public interface I3DSystem
{
    void Render3D(double x, double y, double z);
}

// Реалізація 3D-системи координат
public class ThreeDSystem : I3DSystem
{
    public void Render3D(double x, double y, double z)
    {
        Console.WriteLine($"Rendering point in 3D: ({x}, {y}, {z})");
    }
}

// Інтерфейс для 2D-об'єктів
public interface ITwoDPoint
{
    double X { get; }
    double Y { get; }
}

// Клас для 2D-даних
public class TwoDPoint : ITwoDPoint
{
    public double X { get; }
    public double Y { get; }

    public TwoDPoint(double x, double y)
    {
        X = x;
        Y = y;
    }
}

// Адаптер для відображення 2D-точок у 3D-системі координат
public class TwoDToThreeDAdapter : I3DSystem
{
    private readonly ITwoDPoint _twoDPoint;

    public TwoDToThreeDAdapter(ITwoDPoint twoDPoint)
    {
        _twoDPoint = twoDPoint;
    }

    // Реалізація методу Render3D
    public void Render3D(double x, double y, double z)
    {
        // Використовуємо координати з 2D-точки, і Z = 0 за замовчуванням
        Console.WriteLine($"Адаптація 2D-точки ({_twoDPoint.X}, {_twoDPoint.Y}) до 3D: ({_twoDPoint.X}, {_twoDPoint.Y}, {z})");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        // Створення 2D-точки
        ITwoDPoint twoDPoint = new TwoDPoint(5.0, 10.0);

        // Використання адаптера
        I3DSystem adapter = new TwoDToThreeDAdapter(twoDPoint);

        // Відображення точки в 3D (z = 0 за замовчуванням)
        adapter.Render3D(twoDPoint.X, twoDPoint.Y, 0);
    }
}