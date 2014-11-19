1. [Интерфейс](#Interface)
2. [Инкапсуляция Наследование, Полиморфизм](#IncInhPol)
3. [Перегрузка и переопределение](#OveridingOverloading)
4. [Ключевое слово abstract](#Abstract)
5. [Ключевое слово virtual](#Virtual)
5. [Рекурсия](#Recursion)
6. [Конструкция Using](#Using)


###<a name='Interface'>Интерфейс</a>

===

***Интерфейс*** - Именованный набор сигнатур методов

``` C#
	public interface IShip
	{
		string Move(int distance);
		string Fight();
	}

	public interface IDestroybal
	{
		string Destroy();
	}
	
	
	
	public class TransportShip : IShip, IDestroybal
	{
		public TransportShip()
		{
		}
	
		//реализация  сигнатуры из интерфейса  IShip
		public string Move(int distance)
		{
			double time = (double)distance / 1000;
			return string.Format("Пройдено километр: {0} за время: {1}", distance, time);
		}
		//реализация  сигнатуры из интерфейса  IShip
		public string Fight()
		{
			return "Транспортный корабль не может вступать в бой!";
		}
		//реализация сигнатуры из интерфейса  IDestroybal
		public string Destroy()
		{
			return "Корабль уничтожен";
		}
	}

```

- Перед сигнатурой модификатор доступа не указывается, так как все перечисляемы сигнатуры имеют тот же модификатор доступа что и интерфейс
- Есть некоторое сходство с abstract class. где также определяли методы, но в абстрактном классе есть модификаторы доступа и мы можем задавать тело методы. В интерефейсе же никакой реализации невозможно.


#### Есть существенная разница между наследованием и реализацией интерфейса

1. При наследовании некоторый класс получает признаки родительского класса.
2. При реализации инт.  инт всего лишь вооплощает методы
3. Класс должен реализовать все методы интерфейса, как бы контракт на обязательство реализовать.
4. Класс можно реализовывать много интерфейсов.
5. В С# запрерщена множественная реализация наследования, не разрешается множественная реализцация интерфейсов.

Интерфейсы в какой то степени нужны для того чтобы можно было бы избежать невозможности множественного наследования, когда это необходимо. 

#### Способы реализации общего метода


- Если организовать класс с пересекающимися атрибутами, один общий класс - то это будет помойка. У трех каких то классов например Animal, Ship, House будет один общий класс ScrapHeap (), и в нем реализуем метод  GetProductinCost()  и  GetSpeed().  Но эти методы не нужны для всех подчиненных классов (Дома не имеют скорости, животные не имеют производительную стоимость).
- Можно использовать множественное наследование, но не все языки это поддерживают.
- А можно реализовать два интерфейса  ISpeedObject и IProductionObject. Соответственно в них будет методы   GetSpeed() и GetProductinCost()

---

###<a name='IncInhPol'>Инкапсуляция, Наследование и Полиморфизм</a>

===

***Инкапсуляция*** - это способность языка скрывать излишние детали реализации от пользователей. 
Этот принцип ООП упрощает жизнь программистам, так как не приходится думать о том что за код работает "за кулисами". 

С инкапсуляцией также связано понятие защиты данных. Например можно данные состояния объекта специфицировать с помощью ключевых слов private или protected, данные которых будут доступны только для других частей этого объекта.  

***Наследование*** - способность строить новые классы на основе предыдущих, родительских. Наследование позволяет расширить поведение дочернего класса, используя при этом основную функциональность базового класса.

***Полиморфизм*** - в двух словах - один метод - множество реализаций. В качестве примера можно взять класс фигура. У которого есть абстрактный метод GetS() вычислить площадь. У производных классов мы можем переопеределить это метод используя ключевое слово overide. Таким образом у нас будут несколько классов с одинаковым методом GetS() , но разной реализацией, каждый вычиляющий площадь необходимой фигуры.

---

###<a name='OveridingOverloading'>Перегрузка и переопределение</a>

===

***Перегрузка*** (Overloading) - определение двух методов с одинаковым именем в пределах одного класса но имеющих разную сигнатуру. Простой пример сложения двух переменных с помощью метода Plus. Только в одном случае метод будет принимать два int значения, в другом два string значения. 

```C#
public static int Plus(int a, int b)
{
	return a + b;
}
public static string Plus(string a, string b)
{
	return a + b;
}

static void Main(String[] args)
{
	Console.WriteLine(Plus(3, 7));
	Console.WriteLine(Plus("3", "7"));
	Console.ReadLine();
}
```

***Переопределение*** (Overiding) - определение метода который определен в родительском классе. Метод имеет ту же  сигнатуру.

---

###<a name='Abstract'>Ключевое слово abstract</a>

===

***Abstract*** - это ключевое слово может использоваться с методами, свойствами, индексаторами и событиями. Но в отличии от virtual - еще может использоваться и с классами. И это означает - что реализация данного объекта является неполной или отсутствует. Это также означает что данный класс необходим только для использования в качестве базового класса для других классов. 

***Абстрактный метод*** - это метод базового класса (обязательно абстрактного класса), который не реализует каких-либо действий, а предлагает только сигнатуру для производных классов.  Если наш производный класс наследуется от базового, в котором определен абстрактный метод, то этот метод обязательно должен быть реализован-переопределен в нашем производном классе, используя при этом знакомое нам клечевое слово overide. 
И кстати мы не можем создавать экземпляры абстрактного класса. На фиг он тогда нужен нам?????

---

###<a name='Virtual'> Ключевое слово virtual </a>

===

***Virtual*** - это ключевое слово мы можем использовать для методов, свойств, индексаторов, событий для переопределения в производном классе. Вот некоторые особенности при работе с виртуальным свойствами:

- Виртуальный метод в базовом классе должен быть реализован в отличии от абстрактнго класса.
- Но как и в случае с abstract мы тоже должны использовать ключевое слово overide при переопределнии виртуального метода у производного класса.
- Также надо помнить - невозможно использовать virtual в статическом свойстве
- Переопределение виртуального мтеода в производном классе не обязательно в отличии от абстрактного мтеода.

```C#
public class Shape
{ 
	public virtual double GetS()
	{
		return 0;
	}
}
public class Rectangular : Shape 
{ 

}
public class Circle : Shape
{
	public double R;

	public Circle(double r) {
		R = r;
	}

	public override double GetS()
	{
		return 3.14 * this.R * this.R;
	}
}
```

--- 

###<a name='Recursion'>Рекурсия</a>

===

Существует два вида рекурсии: ***прямая*** и ***не прямая***

***Прямая*** рекурсия - метод вызывает сам себя.

***Не прямая*** рекурсия - вызов метода по кругу. Метод вызывает другой метод, который вызывает первый.

Рассмотрим пример рекурсивной функции для вычисления числа Фиббоначи. Для начала нужно знать что это такое. n-й член последовательности фибоначи вычисляется по формуле - f(n)=f(n-1) + f(n-2). Где f(0)=f(1)=1.

```C#
static int Fibonachi(int n)
{
	if (n == 0)
		return 0;
	else if (n == 1)
		return 1;
	else
	{
		return Fibonachi(n - 1) + Fibonachi(n - 2);
	}
}


static void Main(string[] args)
{
	for (int i = 0; i < 55; i++)
	{
		Console.WriteLine(i + " - " + Fibonachi(i));
	}
	Console.ReadLine();
}
```

На практике не всегда хорошо использовать рекурсию, так как она достаточно сложная, долгая и тяжеловесная. В данном примере чтобы распечатать ряд чисел фибоначи до 55го элемента уже на 40 элементе программа начинает задумываться. Поэтому, наверное лучше обойтись при помощи цикла и массива или списка для хранения чисел фибоначи. 

Но есть другие примеры где невозоможно обойтись без рекурсии. Когда результат зависит только от полученного выражения. 

---

###<a name='Using'> Конструкция Using</a>

===

На собеседованиях часто спрашивают про конструкцию Using. Зачем она, во что превращает ее компилятор, как с ней жить, что за объекты которые реализуют интерфейс IDisposable. 

- using упрощает работу с такими объектами, тоесть не надо задумываться об очистки памяти после выполнения работы с такими объектами.
- вообще интерфейс IDisposable содержит только один метод - Dispose().  И в конструкции using нам не надо думать о нем. Компилятор все сделает за нас.
- ну и собственно во что превращается using компилятором

```C#
using (SqlConnection con = new SqlConnection())
{
	//запросы к базе
}
```

генерируется следующий код компилятором

```C#
SqlConnection con = new SqlConnection();
try
{
	//запросы к базе
}
finally
{
	if (conn != null) ((IDisposable)conn).Dispose();
}
```


