using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STACK
{
	// пример из http://evilcoderr.blogspot.ru/2013/01/stack-c.html
	class Program
	{
		//собственно демонстрация работы
		static void Main(string[] args)
		{
			CStack<int> stack = new CStack<int>();
			stack.Push(3);
			stack.Push(6);
			Console.WriteLine("elevent Number " + stack.Count.ToString() + " is  " + stack.Pop().ToString());
			Console.WriteLine("elevent Number " + stack.Count.ToString() + " is  " + stack.Pop().ToString());
			Console.ReadLine();
		}
	}
}
