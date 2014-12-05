using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace FuncAction
{
	class Calculator
	{

		static void Main(string[] args)
		{
			Calculator calc = new Calculator();

			Console.WriteLine(calc.PerformOperation("+", 23, 3));
			Console.WriteLine(calc.PerformNewOperation("+", 23, 3));

			// использования операции добавления операции )))
			calc.DefineOperation("mod", (x,y)=>x%y);

			Console.WriteLine(calc.PerformNewOperation("mod", 23, 3));

			Console.ReadLine();
		}


		// Простой калькулятор
		public double PerformOperation(string op, double x, double y)
		{
			switch (op)
			{
				case "+": return x + y;
				case "-": return x - y;
				case "*": return x * y;
				case "/": return x / y;
				default: throw new ArgumentException(string.Format("Operation {0} is invalid", op), "op");
			}
		}

		// но надо оптимизировать
		// и желательно избавиться от swithch
		 // Мы вынесли определение операций из кода в данные — из свитча в словарь.
		private delegate double OperationDelegate(double x, double y); // делегат для выполнения операции с двумя числами (бинарный)
		private Dictionary<string, Func<double, double, double>> operations; // словарь в котором будем хранить пары ( операция - кусок кода (функции) для выполнения)

		// но этот конструктор и функции слишком громоздкие и их можно заменить 
		//private double DoDevision(double x, double y) { return x / y; }
		//private double DoMultiplication(double x, double y) { return x * y; }
		//private double DoSubtraction(double x, double y) { return x - y; }
		//private double DoAddition(double x, double y) { return x + y; }
		//public Calculator()
		//{
		//	operations = 
		//		new Dictionary<string,OperationDelegate>
		//		{
		//			{"+", this.DoAddition},
		//			{"-", this.DoSubtraction},
		//			{"*", this.DoMultiplication},
		//			{"/", this.DoDevision}
		//		};
		//}

		// и мы можем избавить от всех этих доп функций и написать при помощь анонимных методов:
		//public Calculator()
		//{
		//	operations =
		//		new Dictionary<string, OperationDelegate>
		//		{
		//			{"+", delegate(double x, double y) {return x + y;}},
		//			{"-", delegate(double x, double y) {return x - y;}},
		//			{"*", delegate(double x, double y) {return x * y;}},
		//			{"/", delegate(double x, double y) {return x / y;}}
		//		};
		//}

		// но выше тоже много лабуды, поэтому переписать все это можно через лямбда выражения
		public Calculator()
		{
			operations =
				new Dictionary<string, Func<double, double, double>>
				{
					{"+", (x,y) => x + y },
					{"-", (x,y) => x - y },
					{"*", (x,y) => x * y },
					{"/", (x,y) => x / y }
				};
		}

		public double PerformNewOperation(string op, double x, double y)
		{
			if (!operations.ContainsKey(op))
				throw new ArgumentException(string.Format("Operation {0} is invalid", op), "op");
			return operations[op](x, y);
		}



		// НОООО, теперь мы можем изящно в коде написать функцию по добавлению новых видов операци программно
		public void DefineOperation(string op, Func<double, double, double> newOper)
		{ 
			if (operations.ContainsKey(op))
				throw new ArgumentException(string.Format("Operation {0} already exists", op), "op");

			operations.Add(op, newOper);
		}
	}
}
