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

            Fish fish = new Fish("yellow", 23, 500, true);
            Bird bird = new Bird("Red", 123, 1400, false);

            fish.GetCommonInfo();
            fish.GetFishesInfo();

            bird.GetCommonInfo();
            bird.GetBirdsInfo();

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

    // базовый класс
    class Animal
    {
        public string color;
        public int size;
        public int weidth;

        public void GetCommonInfo()
        {
            Console.WriteLine("Животное: {0}\n Размер: {1}\n  Вес: {2}\n ", color, size, weidth);
        }
    }

    class Fish : Animal
    {
        public bool canSweam;

        public Fish(string color, int size, int weidth, bool canSweam)
        {
            this.color = color;
            this.size = size;
            this.weidth = weidth;
            this.canSweam = canSweam;
        }

        public void GetFishesInfo ()
        {
            Console.WriteLine("Рыба умеет плавать: " + (this.canSweam==true ? "Да" : "Нет"));
        }
    }

    class Bird : Animal
    {
        public bool canFly;
        
        public Bird(string color, int size, int weidth, bool canFly)
        {
            this.color = color;
            this.size = size;
            this.weidth = weidth;
            this.canFly = canFly;
        }

        public void GetBirdsInfo ()
        {
            Console.WriteLine("Птица умеет летать: " + (this.canFly == true ? "Да" : "Нет"));
        }
    }
}
