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
		private double DoDevision(double x, double y) { return x / y; }
		private double DoMultiplication(double x, double y) { return x * y; }
		private double DoSubtraction(double x, double y) { return x - y; }
		private double DoAddition(double x, double y) { return x + y; }
		// и желательно избавиться от swithch
		private delegate double OperationDelegate(double x, double y); // делегат для выполнения операции с двумя числами (бинарный)
		private Dictionary<string, OperationDelegate> operations; // словарь в котором будем хранить пары ( операция - кусок кода (функции) для выполнения)

		public Calculator()
		{
			operations = 
				new Dictionary<string,OperationDelegate>
				{
					{"+", this.DoAddition},
					{"-", this.DoSubtraction},
					{"*", this.DoMultiplication},
					{"/", this.DoDevision}
				};
		}

		public double PerformNewOperation(string op, double x, double y)
		{
			if (!operations.ContainsKey(op))
				throw new ArgumentException(string.Format("Operation {0} is invalid", op), "op");
			return operations[op](x, y);
		}


	}
}
