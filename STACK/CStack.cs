using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STACK
{
	public class CStack<T>
	{
		private T[] _array; // массив для хранения данных типа Т
		private const int defaultCapacity = 10; // по умолчанию вместимость, потом если что можно будет расширить
		private int size; // размер

		public CStack() // конструктор
		{
			this.size = 0;
			this._array = new T[defaultCapacity];
		}

		public bool isEmpty () // проверка на пустоту
		{
			return this.size == 0;
		}

		public virtual int Count // параметр для вывода размера
		{ 
			get{
				return this.size;
			}
		}

		public T Pop() // метод взятия с вершины
		{
			if (this.size == 0)
			{
				throw new InvalidOperationException();
			}
			else
			{
				return this._array[--this.size];
			}
		}

		public void Push(T newElement)
		{
			if (this.size == this._array.Length) // if stach overflow
			{ // не очень красиывый вариант, можно будет переделать 
				T[] newArray = new T[2*this._array.Length];
				Array.Copy(this._array, 0, newArray, 0, this.size);
				this._array = newArray; // просто создаем новый массив с двойным размером
			}
			this._array[this.size++] = newElement; // и вставляем сам элемент
		}

		public T Peek()
		{
			if (this.size == 0)
			{
				throw new InvalidOperationException();
			}
			return this._array[this.size - 1];
		}

	}
}
