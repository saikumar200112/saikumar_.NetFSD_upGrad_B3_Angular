using System.Collections.Generic;
namespace consoleApp1
{
    public class Shape
    {
        public virtual double CalculateArea()
        {
            return 0;
        }
    }

    public class Rectangle : Shape
    {
        public double Width = 5;
        public double Height = 10;
        public override double CalculateArea()
        {
            return Width * Height;
        }
    }

    public class Circle : Shape
    {
        public double Radius = 7;
        public override double CalculateArea()
        {
            return 3.14 * Radius * Radius;
        }
    }
    public class AreaPrinter
    {

        public void PrintArea(Shape someShape, string shapeName)
        {
            double area = someShape.CalculateArea();
            Console.WriteLine($"The area of {shapeName} is  {area}");
        }
    }



   internal class Program
    {
        static void Main(string[] args)
        {
            AreaPrinter printer = new AreaPrinter();


            Shape myRect = new Rectangle();
            printer.PrintArea(myRect, "Rectangle");


            Shape myCircle = new Circle();
            printer.PrintArea(myCircle, "Circle");


            Console.ReadLine();
        }
    }
}