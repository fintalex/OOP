using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace polymorphism
{
	class InterfaceExample
	{
		static void Main2(string[] args)
		{
			Car car = new Car();
			car.Go(10);

			Console.WriteLine("Машина c {1} колесами проходит участок в {0} метров ", car.X, car.AmountOfWheels);
			car.Stop();
			Console.WriteLine("Maшина {0} ", car.Runing ? "Едет" : "Стоит");
			Console.ReadLine();
		}
	}

	interface IStop
	{
		void Stop();
	}
	// интерфейс некоторе подобие абстрактного класса
	interface IRun
	{
		// каждый член является абстрактным, поэтому он не содержит реализации
		// в интерфейсе также можно держать свойства
		int X { get; set; }
		bool Runing { get; }
		void Go(int length); // реализацию нигде не пришем
	}

	// базовый класс должен всегда стоять перед интерфейсами
	class Car : Mshine, IRun, IStop
	{
		public Car()
		{
			amountOfWheels = 4;
		}

		int x;
		public int X
		{
			get { return x; }
			set { x = value; }
		}

		bool running;
		public bool Runing
		{
			get { return running; }
		}

		public void Go(int length)
		{
			x += length;
			running = true;
		}

		public void Stop()
		{
			running = false;
		}
	}

	class Mshine
	{
		protected byte amountOfWheels;
		public byte AmountOfWheels
		{
			get { return amountOfWheels; }
		}
	}
}
