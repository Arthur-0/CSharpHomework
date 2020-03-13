using System;

namespace W3Homework1
{
    class Program
    {
        static void Main(string[] args)
        {
            shape[] shapeCollection=new shape[10];
            double areaSum = 0;
            for (int i = 0; i < 10; i++)
            {
                shapeCollection[i] = shapeFactory.getshape(randomShape(), i + 1, i + 1, i + 1);
                areaSum += shapeCollection[i].area();
            }
            Console.WriteLine(areaSum);
        }

        static string randomShape()
        {
            Random randomNum = new Random();
            int shapeNum = randomNum.Next(1, 3);
            switch(shapeNum)
            {
                case 1:
                    return "Triangle";
                case 2:
                    return "Rectangle";
                case 3:
                    return "square";
                default:
                    return "";

            }
        }
    }

    public class shape
    {
        public virtual double area() { return 0; }
        bool isLegal() { return false; }
    }

    public class Triangle:shape
    {
        private double edge1, edge2, edge3;
        public Triangle(double a,double b,double c)
        {
            edge1 = a;
            edge2 = b;
            edge3 = c;
        }

        public bool isLegal()
        {
            if (edge1 > 0 && edge2> 0 && edge3 > 0)
            {
                return edge1 < edge2 + edge3 && edge2 < edge1 + edge3 && edge3 < edge1 + edge2;
            }
            else return false;

        }
        public override double area()
        {
            if(isLegal()==true)
            {
                double p = (edge1 + edge2 + edge3) / 2;
                return Math.Sqrt(p * (p - edge3) * (p - edge2) * (p - edge1));
            }
            else
            {
                Console.WriteLine("数据不合法，请重新设置");
                return 0;
            }
            
        }
    }

    public class square:shape
    {
        public square(double width)
        {
            this.width = width;
        }
        protected double width;
        public double Width
        {
            get { return width; }
            set { width = value; }
        }
        public bool isLegal()
        {
            return  width > 0;
        }
        public override double area()
        {
            if (isLegal() == true)
                return width * width;
            else
            {
                Console.WriteLine("数据不合法，请重新设置");
                return 0;
            }
        }
    }

    public class Rectangle:square
    {
        private double height;
        public Rectangle(double height,double width):base(width)
        {
            this.height = height;
            this.width = width;
        }
        
        public double Height
        {
            get { return height; }
            set { height = value; }
        }

        new public bool isLegal()
        {
            return height > 0 && width > 0;
        }
        new public double area()
        {
            if(isLegal()==true)
                return height*width;
            else
            {

                Console.WriteLine("数据不合法，请重新设置");
                return 0;
            }

        }
    }

    public class shapeFactory
    {
        public static shape getshape(string shape, double a = 0.0, double b = 0.0,double c=0.0)
        {
            switch(shape)
            {
                case "Triangle":
                    return new Triangle(a,b,c);
                case "Rectangle":
                    return new Rectangle(a, b);
                case "square":
                    return new square(a);
                default:
                    return null;
            }
        }
    }

}
