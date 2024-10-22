namespace ConsoleApp6
{
    //static class RandomExtension
    //{
    //    public static double NextDouble(this Random random, double min, double max)
    //    {
    //        return random.NextDouble * (min, max) + min;
    //    }
    //}
    //class Character
    //{
    //    public int Health;
    //    private string _name;
    //    protected float Speed;

    //    public static int Counter = 0;

    //    public Character()
    //    {
    //        Health = 0;
    //        _name = "Empty";
    //    }
    //    public Character(string name)
    //    {
    //        _name = name;
    //    }
    //}
    static class StringExtension
    {
        public static int ToInt(this string input)
        {
            return int.Parse(input);
        }
    }
    class Geometry
    {
        static double GetLength(double x, double y)
        {
            return Math.Sqrt(x * x + y * y);
        }

        static Vector Add(Vector vector1, Vector vector2)
        {
            return new Vector(vector1.X + vector2.X, vector1.Y + vector2.Y);
        }

        static double GetLength(Segment segment1)
        {
            return Math.Sqrt((segment1.End.X - segment1.Begin.X) * (segment1.End.X - segment1.Begin.X) 
                + (segment1.End.Y - segment1.Begin.Y) * (segment1.End.Y - segment1.Begin.Y));
            
        }
        
        static bool IsVectorInSegment(Vector point, Segment segment)
        {
            double length1 = Geometry.GetLength(new Segment(segment.Begin, point));
            double length2 = Geometry.GetLength(new Segment(point, segment.End));
            return GetLength(segment) - (length1 + length2) < 1e-9;
        }
    }


    class Vector
    {
        public double X;
        public double Y;

        public Vector(double x, double y)
        {
            X = x;
            Y = y;
        }
    }

    class Segment
    {
        public Vector Begin;
        public Vector End;
        
        public Segment(Vector begin, Vector end)
        {
            Begin = begin;
            End = end;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            //var arg1 = "100500";
            //Console.Write(arg1.ToInt() + "42".ToInt());
        }
    }
}