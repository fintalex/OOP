using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace FuncAction
{
	class Program
	{
		//delegate
		delegate double CalcArea(int r);
		static CalcArea cpointer = CalculateArea;
		// lamda


		static double CalculateArea(int r)
		{
			return 3.14 * r * r;
		}

		static void Main(string[] args)
		{
			//delegate
			double area = cpointer(20);
			CalcArea calArea = new CalcArea(delegate(int r)
				{
					return 3.14 * r * r;
				});
			double area2 = calArea(20);

			// lamda
			CalcArea calcAreeByLambda = r => 3.14 * r * r;
			double areaByLambda = calcAreeByLambda(20);

			// generic delegate Func
			Func<Double, Double> calcAreaByFunc = r => 3.14 * r * r;
			double areaByFunc = calcAreaByFunc(20);

			// generic delegate Action
			Action<string> MyAction = y => Console.WriteLine(y);
			MyAction("Hello");

			// Predicate
			Predicate<string> ChechGreaterThan5 = x => x.Length > 5;
			Console.WriteLine(ChechGreaterThan5("Hello"));
			
			//============================================================

			List<string> oString = new List<string>();
			oString.Add("Dimanuch");
			oString.Add("Vasua");

			// in several function of List we use a DELEGATE
			// so we can use our created delegate
			string str = oString.Find(ChechGreaterThan5); // will find Dimanuch
			Console.WriteLine(str);

			//expression trees
			// (10 + 20) - (5 + 3)

			// (10 + 20)
			BinaryExpression b1 = Expression.MakeBinary(
				ExpressionType.Add,
				Expression.Constant(10),
				Expression.Constant(20));
			//(5 + 3)
			BinaryExpression b2 = Expression.MakeBinary(
				ExpressionType.Add,
				Expression.Constant(5),
				Expression.Constant(3));
			// (10 + 20) - (5 + 3)
			BinaryExpression b3 = Expression.MakeBinary(
				ExpressionType.Subtract,
				b1,
				b2);

			// this statement will create a delegate by parsing the expression tree
			int result = Expression.Lambda<Func<int>>(b3).Compile()();


			Console.ReadLine();
		}

		

	}
}
