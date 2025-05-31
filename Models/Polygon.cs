using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace u24634400_Prac8.Models
{
    public abstract class Polygon
    {
        private int _sides;
        public int Sides
        {
            get { return _sides; }
            set { _sides = value; }
        }

        public int Length { get; set; }

        public string _color { get; set; }
        public string Description { get; set; }
        public string XCoordinate { get; set; }
        public string YCoordinate { get; set; }
        public string StrokeColor { get; set; }
        public int StrokeWidth { get; set; }
        public string FillColor { get; set; }
        

        public string getSides()
        {
            return "#Sides is " + Sides;
        }

        public abstract double GetArea();

        public abstract string GetSVG();


    }

    //Create derived class = square
    public class Square : Polygon
    {
        //constructor 
        public Square(int length)
        {
            Sides = 4;
            Length = length;

        }

        //class method to calculate area
        public override double GetArea()
        {

            return Length * Length;
            
        }

        public override string GetSVG()
        {
            return "<svg width='450' height='450'>" +
                   "<rect width='" + Length + "' height='" + Length + "' style='fill:" + _color + ";' />" +
                   "</svg>";
        }
    }

    
    public class Rectangle : Polygon
    {
        
        public int Breadth { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public int Width { get; set; }
        public int Height { get; set; }

        //constructor
        public Rectangle(int width, int height)
        {
            Width = width;
            Height = height;
            Sides = 4;
        }

        public Rectangle() { }

        //class method to calculate area
        public override double GetArea()
        {

            return Width * Height;
            
        }

        public override string GetSVG()
        {
            return "<svg width='450' height='450'>" +
                   "<rect width='" + Length + "' height='" + Breadth + "' style='fill:" + _color + ";' />" +
                   "</svg>";
        }

    }

    public class Triangle : Polygon
    {
       
        public int Height { get; set; }
        public int Point1X { get; set; }
        public int Point1Y { get; set; }
        public int Point2X { get; set; }
        public int Point2Y { get; set; }
        public int Point3X { get; set; }
        public int Point3Y { get; set; }
        

        public Triangle() { }

        public override double GetArea()
        {
            return 0.5 * Math.Abs(
                Point1X * (Point2Y - Point3Y) +
                Point2X * (Point3Y - Point1Y) +
                Point3X * (Point1Y - Point2Y)
            );
        }

        public override string GetSVG()
        {
            return $"<polygon points='{Point1X},{Point1Y} {Point2X},{Point2Y} {Point3X},{Point3Y}' " +
                   $"fill='{_color}' stroke='{StrokeColor}' stroke-width='{StrokeWidth}' />";
        }
    }



    public class Ellipse : Polygon
    {
        public int RadiusX { get; set; }
        public int RadiusY { get; set; }
        public int CentreX { get; set; }
        public int CentreY { get; set; }


        public Ellipse(int radiusX, int radiusY, string color, int centreX, int centreY)
        {
            RadiusX = radiusX;
            RadiusY = radiusY;
            Sides = 0;
            _color = color;
            CentreX = centreX;
            CentreY = centreY;
        }

        public Ellipse() { }

        public override double GetArea()
        {
            return Math.PI * RadiusX * RadiusY;
        }

        public override string GetSVG()
        {
            return $"<ellipse cx='{CentreX}' cy='{CentreY}' rx='{RadiusX}' ry='{RadiusY}' fill='{_color}' />";

        }
    }

}