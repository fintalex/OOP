using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace polymorphism
{
	class Program
	{
		static void Main(string[] args)
		{
			List<Shape> shapes = new List<Shape>();
			shapes.Add(new Rectangle());
			shapes.Add(new Triangle());
			shapes.Add(new Circle());

			foreach (var shape in shapes)
			{
				shape.Draw();
			}

			Console.ReadKey();
		}
	}

	// абстрактный класс - фигура
	// который имеет координаты центра, ширину и высоту
	abstract class Shape
	{
		public int X { get; private set; }
		public int Y { get; private set; }
		public int Height { get; set; }
		public int Wedth { get; set; }

		// абстрактный или виртуальный метод для переопределения
		// abstract - без реализации метода в базовом классе
		// virtual - требует реализацию
		// мтеод будем потом переопределять
		public abstract void Draw();
		
	}

	class Circle : Shape
	{
		public override void Draw()
		{
			Console.WriteLine("I am busy, a im drawing Circle");
			//base.Draw();
		}
	}

	class Rectangle : Shape
	{
		public override void Draw()
		{
			Console.WriteLine("I am busy, a im drawing Rectangle");
			//base.Draw();
		}
	}

	class Triangle : Shape
	{
		public override void Draw()
		{
			Console.WriteLine("I am busy, a im drawing Triangle");
			//base.Draw();
		}
	}
}
