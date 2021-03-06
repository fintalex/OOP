##<a name='OGL'> Оглавление </a>

---

1. [Интерфейс](#Interface)
1. [Делегаты](#Delegat)
1. [Обобщенные делегаты](#SharedDelegate)
1. [Инкапсуляция Наследование, Полиморфизм](#IncInhPol)
1. [Перегрузка и переопределение](#OveridingOverloading)
1. [Ключевое слово abstract](#Abstract)
1. [Ключевое слово virtual](#Virtual)
1. [Рекурсия](#Recursion)
1. [Конструкция Using](#Using)
1. [Конструкторы и дуструкторы](#ConstDest)
1. [Обобщения](#Generic)
1. [Индексаторы](#Indexer)
1. [Разделяемые классы](#PartialClass)

---

##<a name='Pattern'>Паттерны</a>

1. [Singleton](#Singleton)

---

##[Интересные вопросы](#Interesting)

1. [Что нужно чтобы класс работал с foreach](#ForeachForClass)
1. [Логирование](#logs)


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

Интерфейсы также поддерживают наследование. Тоесть если мы реализовали интерфейс для какого либо класса , а этот интерфейс наследуется от другого интерфейса, то в классе нам нужно будет определить все методы обоих интерфейсов.

#### Способы реализации общего метода


- Если организовать класс с пересекающимися атрибутами, один общий класс - то это будет помойка. У трех каких то классов например Animal, Ship, House будет один общий класс ScrapHeap (), и в нем реализуем метод  GetProductinCost()  и  GetSpeed().  Но эти методы не нужны для всех подчиненных классов (Дома не имеют скорости, животные не имеют производительную стоимость).
- Можно использовать множественное наследование, но не все языки это поддерживают.
- А можно реализовать два интерфейса  ISpeedObject и IProductionObject. Соответственно в них будет методы   GetSpeed() и GetProductinCost()

---

###<a name='Delegat'>Делегаты и события</a>

===

***Сигнатура*** - тип и порядок его входных и выходных параметров. Например одинаковые сигнатуры для таких методов: public string Move(int step)  и public string Speed(int i).
***Делегат*** - тип данных по ссылке. Делегат это такой тип который может хранить ссылку на метод который имеет такую же сигнатуру. В примере ниже делегат CountDelegate может хранить ссылку на методы GetCount и GetCountSymbolA, так как у них одинаковая сигнатура ( int (string) ). Так как делегат является классом мы можем создать переменную этого типа, тоесть переменные d1 и d2. Значениями этих переменных являются ссылки на методы, которые соответствуют сигнатуре. Переменную d3 нам не даст объявить компилятор.

```C#
class Program
{
	static void Main(string[] args)
	{
		StringHelper helper = new StringHelper();

		CountDelegate d1 = helper.GetCount;
		CountDelegate d2 = helper.GetCountSymbolA;
		//CountDelegate d3 = helper.GetCountSymbol;
	}
}
	
public delegate int CountDelegate ( string message);

public class StringHelper
{
	public int GetCount(string inputString)
	{
		return inputString.Length;
	}
	public int GetCountSymbolA(string input)
	{
		return input.Count(c => c == 'A');
	}
	public int GetCountSymbol(string intputString, char symbol)
	{
		return intputString.Count(c => c == symbol);
	}
}
```

Вот как они работают. Создадим вспомогательный метод TestMethod ( любой, не завися от сигнатуры), но у него будут первый входной параметр это ссылка на наш метод, тоесть делегат CountDelegate, а второй входная строка. Сделаем два вызова метода TestMethod: в первом передадим ссылку на метод d1 - GetCount, во втором d2 - GetCountSymbolA. 

```C#
static void Main(string[] args)
{
	StringHelper helper = new StringHelper();

	CountDelegate d1 = helper.GetCount;
	CountDelegate d2 = helper.GetCountSymbolA;
	//CountDelegate d3 = helper.GetCountSymbol;

	string testString = "МАФИЯ";

	Console.WriteLine("Количество символов в строке:{0}",  TestMethod(d1, testString));
	Console.WriteLine("Количество символов A в строке:{0}", TestMethod(d2, testString));

	Console.ReadLine();
}

// вспомогательный метод
static int TestMethod(CountDelegate method, string curString)
{
	return method(curString);
}
```

---

Но вот если мы имеем такой класс и метода: 

```C#
class Program
{
	static void Main(string[] args)
	{
		Car car = new Car();
		car.Move(20);
	}
}
public class Car
{
	public void Move(int distance)
	{
		for (int i = 0; i < distance; i++)
		{
			Thread.Sleep(1000);
			Console.WriteLine("Проехал {0} километров", i);
		}
	}
}
```

Но предположим если этот класс Car находится на удаленном сервере, и мы хотим получать данные не на консоль а через интернет. Или мы делаем Window приложение. Тоесть нам нужно сделать метод Move таким образом чтобы можно было получать от него сообщение независимо от способа вывода. 
Сначала объявим делегат void ShowMessage(string message),  добавим в метод Move новый параметр - ссылку на метод совпадающий с нашей сигнатурой метода. И заменим вывод на консоль на новый параметр - на ссылку. Таким образом мы избавились от только одного способа вывода.

```C#
public delegate void ShowMessage(string message);
public class Car
{
	public void Move(int distance, ShowMessage method)
	{
		for (int i = 0; i < distance; i++)
		{
			Thread.Sleep(1000);
			method(string.Format( "Проехал {0} километров", i) );
		}
	}
}
```

Какже теперь воспользоваться этой лабудой. В нужном нам классе создадим вспомогательный метод который будет выводить как либо нам сообщение на экран, но с той же синатурой что и у нашего делегата. В Void Main создадим переменную нашего делегат -  ссылку на этот метод. И передедим ее вторым параметром в метод Move. Все работает как и прежде. 
***В итоге, делегаты нам нужны для построения более высоких уровней абстракции***

```C#
class Program
{
	static void Main(string[] args)
	{
		Car car = new Car();
		ShowMessage showMethod = Show;
		car.Move(20, showMethod);
	
		Console.ReadLine();
	}
	static void Show (string mess)
	{
		Console.WriteLine(mess);
	}

}
```

----------------------------------------------------------------------------------------------------------------------------

###<a name='SharedDelegate'>Обобщенныу делегаты</a>

===

Вот если у нас присутствует объявление делегатов у которых синатура одна и та же - зачем нам плодить их - можно воспользоваться обобщенным делегатом. 

Есть два вида обобщенных делегатов: 

***Action<T1, T2, T...>*** - делегат ссылающийся на метод без выходных параметров. Пимер ```Action<string, int>``` , ```Action<int, bool, int>```.

***Func<T1, T2, T... , T out>*** - делегат ссылающийся на метод с выходным параметром, тип которого определяется последним элементом последовательности. Пример ```Func<string, string, int>```  ,  ```Func<string, int, bool>```

Можем попробовать заменить наш делегат обобщенным делегатом.

```C#
class Program
{
	static void Main(string[] args)
	{
		Car car = new Car();
		Action<string> showMethod = Show;
		car.Move(20, showMethod);
	
		Console.ReadLine();
	}
	static void Show (string mess)
	{
		Console.WriteLine(mess);
	}

}

public class Car
{
	public void Move(int distance, Action<string> method)
	{
		for (int i = 0; i < distance; i++)
		{
			Thread.Sleep(1000);
			method(string.Format( "Проехал {0} километров", i) );
		}
	}
}
```

Плюс в том что нам уже не требуется объявление делегата ShowMessage, код становится короче. Минус только в том что мы потеряли имя нашего входного параметра (теперь он называется obj). Ну да и фиг с ним.

Но если мы хотим сделать опционально получение сообщений от метода Move. Для этого нужно сделать следующее: создать свойство дополнительное Moving - которое будем задавать или нет (car.Moving = showMethod;). Тоесть это уже переход к событиям - хотим подписываемся, хотим нет.

```C#
class Program
{
	static void Main(string[] args)
	{
		Car car = new Car();
		Action<string> showMethod = Show;
		car.Moving = showMethod;
		car.Move(20);
	}
	static void Show (string mess)
	{
		Console.WriteLine(mess);
	}
}
public class Car
{
	public void Move(int distance)
	{
		for (int i = 0; i < distance; i++)
		{
			Thread.Sleep(1000);
			if (Moving !=null)
				Moving(string.Format("Проехал {0} километров", i));
		}
	}
	public Action<string> Moving { get; set; }
}
```

----------------------------------------------------------------------------------------------------------------------------

###<a name='IncInhPol'>Инкапсуляция, Наследование и Полиморфизм</a>

===

***Инкапсуляция*** - это способность языка скрывать излишние детали реализации от пользователей. 
Этот принцип ООП упрощает жизнь программистам, так как не приходится думать о том что за код работает "за кулисами". 

С инкапсуляцией также связано понятие защиты данных. Например можно данные состояния объекта специфицировать с помощью ключевых слов private или protected, данные которых будут доступны только для других частей этого объекта.  

***Наследование*** - способность строить новые классы на основе предыдущих, родительских. Наследование позволяет расширить поведение дочернего класса, используя при этом основную функциональность базового класса. ***Что дает нам наследование?*** - позволяет избегать дублируемости кода.

***Полиморфизм*** - в двух словах - один метод - множество реализаций. В качестве примера можно взять класс фигура. У которого есть абстрактный метод GetS() вычислить площадь. У производных классов мы можем переопеределить это метод используя ключевое слово overide. Таким образом у нас будут несколько классов с одинаковым методом GetS() , но разной реализацией, каждый вычиляющий площадь необходимой фигуры. Полиморфизм выражется не только через абстрактные классы и методы. Но и если мы просто переопределяем родительский виртуальный метод. 

Как яркий пример можно в любом классе переопределить виртуальный метод ToString(). Так как все наши классы будет унаслелованными от одного базового класса System.Object.

###[Оглавление](#OGL)
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

###[Оглавление](#OGL)

---

###<a name='Abstract'>Ключевое слово abstract</a>

===

***Abstract*** - это ключевое слово может использоваться с методами, свойствами, индексаторами и событиями. Но в отличии от virtual - еще может использоваться и с классами. И это означает - что реализация данного объекта является неполной или отсутствует. Это также означает что данный класс необходим только для использования в качестве базового класса для других классов. 

***Абстрактный метод*** - это метод базового класса (обязательно абстрактного класса), который не реализует каких-либо действий, а предлагает только сигнатуру для производных классов.  Если наш производный класс наследуется от базового, в котором определен абстрактный метод, то этот метод обязательно должен быть реализован-переопределен в нашем производном классе, используя при этом знакомое нам клечевое слово overide. 
И кстати мы не можем создавать экземпляры абстрактного класса. На фиг он тогда нужен нам?????


###[Оглавление](#OGL)

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

###[Оглавление](#OGL)

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

###[Оглавление](#OGL)

---

###<a name='Using'> Конструкция Using</a>

===

>Ну то что using позволяет использовать типы из пространства имен без указания этого пространства, мы не буде писать, это и так все знают.

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

- SqlConnection является представителем управляемых типов, имеющих доступ к неуправляемым ресурсам. Но существуют еще и другие такие типы, которые инкапсулируют в себе неуправляемые эти ресурсы. И все подобные типы должны реализовывать интерфейс IDisposable.  
- И еще один маленький нюанс. Внутри оператора using может быть объявлено несколько экземпляров типов. Например

```C#
using(Font font1 = new Font("Arial", 10),
	   font2 = new Font("Arial", 12))
{
	//используем font1 и font2
}
```

###[Оглавление](#OGL)

###<a name='ConstDest'> Конструкторы и деструкторы </a>

***Конструкторы***

- Конструкторы это функция которая вызывается автоматически при инициализации объекта класса. 
- Конатрукторы имеют такой же название как и класс.
- Конструкторы не имеют типа возврата.
- Конструкторы помогают инициализировать поля класса.
- Статический конструктор будет вызываться только один раз.

Есть некоторые особенности в этих конструкторах. 

- Если мы вызываем конструктор какого-то унаследованного класса, то сначала вызывается конструктор родительского класса, а затем конструктор нашего используемого класса. 
- У конструкторов подчиненных классов мы можем приписать такую консрукцию public TransportShip() : base() {}. Что указывает на экземпляр родительского класса. 
- То-есть если в родительском классе мы напишем один конструктор с параметрами, а в унаследованном - без параметров, то компилятор выдаст нам ошибку. Такую ошибку можно обойти прописам какое нибудь значение в base.

```
// вместо инициализации объекта мы можем использовать Bunny конструктор с опциональными параметрами
	public class Bunny
	{
		public string Name;
		public bool LikesCarrots;
		public bool LikesHumans;

		public Bunny(string name, bool likesCarrots = true, bool likesHumman = false) 
		{
			Name = name;
			LikesCarrots = likesCarrots;
		}
	}

	class Program
	{
		static void Main()
		{
			Bunny b = new Bunny(name: "Buny", likesHumman: true);
			Bunny b2 = new Bunny(name: "Buny");
		}
	}
```

Статические поля вызываются до вызова статического конструктора

```
class Foo
	{
		static Foo()
		{
			X = 5;
			Y = 6;
		}
		public static int X = Y;    // 0
		public static int Y = 3;    // 3
	}

	class Program
	{
		static void Main()
		{
			Console.WriteLine(Foo.X);	// 0
			Console.WriteLine(Foo.Y);	// 3
		}
	}
```

***Деструкторы***

- В C# можно определить метод - деструктор, который будет вызываться перед тем как объект будет уничтожен системой сборки мусора. 
- Необходим чтобы гарантировать четкое окончание срока действия объекта.
- Деструктор вызывается непосредственно перед сборкой мусора
- Общая форма деструктора 

```C#
~имя класса(){
	//код деструктора
}
```

===

###<a name='Singleton'>Singleton</a>

При первом обращении к типу вызовется статик конструктор (который вызывается только один раз за приложение), который как раз и создаст новый и единственный экземплят класса. И чтобы получить этот экземпляр мы будем обращаться к свойству Instance.

```C#
class Program
    {
        static void Main(string[] args)
        {
            Singleton singleton = Singleton.Instance;

            singleton.Count = 111;

            TestMethod();

            Console.ReadLine();
        }
        static void TestMethod()
        {
            Singleton singleton = Singleton.Instance;

            Console.WriteLine(singleton.Count);
        }
    }

    public class Singleton
    {
        private static Singleton _singleton;
        static Singleton()
        {
            _singleton = new Singleton(); // внутри ничего не мещает создать экземпляр
        }
        // запрещает создание экземпляра извне
        private Singleton()
        {

        }
        public static Singleton Instance
        {
            get { return _singleton; }
        }
        public int Count { get; set; }
    }
```

В Main обращаемся к экземпляру класса через указанное свойство Instanse. И устанавливает значение свойства Count = 111. Далее работаем с совершенно другим методом, который может вызываться в совершенно другом месте.  Там опять же обращаемся к свойству Instance которое возвращает нам тот же экземпляр класса. В итоге мы получим значение Count = 111, которое установили изначально.

---

###<a name='Generic'>Обощения</a>

***Обобщения*** - переменный тип данных.

Я бы сказал так, чтобы не делать кучу прегруженных методов с просто разными типами входных параметров, мы можем указать тип входных параметров object. Но в этом случае есть дополнительные расходы: упаковки, распаковки. (получается лучше не использоват object).

Тогда нужно использовать обобщенный метод 

```C#
static void Method<T1,T2>(T1 x, T2 y)
{
	Console.WriteLine("first param x = {0}, second param y={1}", x,y);
}
```

После названия метода в угловых скобках мы указываем тип параметра с которым мы будем работать (общепринято называть их T, но назвать мы их можем хоть по русски). А далее мы можем этот тип использовать для входных параметров - использовать обобщенный тип. Этот же обобщенный тип мы можем использовать и в качестве возвращаемого значения. 

```C#
static T1 SecondMethod<T1, T2>(T1 x, T2 y)
{
	Console.WriteLine("first param x = {0}, second param y={1}", x, y);
	return x;
}
```

Но также метод может быть и без выходных и без входных параметров. Но в таком случае при вызове этого метода обязательно надо указывать тип значения этот обобщенного метода.

```C#
static void DetectType<T>()
{
	Console.WriteLine(typeof(T).Name);
}
```

Теперь сажем как использовать такие методы. Используем их также как и обычные методы только после названия метода в угловых скобках указываем тип данных которые мы собираемся передавать в метод. Но можно и не указывать тип данных, за исключение случаев когда нет входных параметров. А вообще лучше их всегда использовать и использовать название для них как T, T1, T2...

```C#
Method<int,double>(5, 43.5);
Method<string, int>("asdf", 4);

int x = SecondMethod(45, "3434sdf"); // можно и не указывать тип в угловых скобках
Console.WriteLine(x);

DetectType<string>(); // обязательно указываем тип
DetectType<float>(); // обязательно указываем тип
```

Как я уже написал можно обходится и без generic, используя тип object. Но так как object является базовым типом для всех остальных классов, и это можно было делать еще в версии .NET 2.0.  Но для работы с ним требовалось постоянное приведение типов данных, и это могло послужить источником для ошибок если приведение выполнено неверно. 

Преимущества обобщений: 

- Производительность. Так как при работе с типом object происходит процесс упаковки (boxing) и распаковки (unboxing).  При преобразовании в ссылочный тип и обратно. (Так как класс - ссылочный тип).  И так как типы значение сохраняются в стеке, а типы ссылок - в куче. Упаковка это процесс из object в класс какой-нибудь, распаковка - обратный процесс.
- Безопасность. О которой уже написано. В ходе работы с такими операциями отпадаем необходимость приведения типов вручную.
- Повторное использование кода. Об этом тоже слегка упомянуто. Обобщенный класс может быть написан однажды, а на его основе можно содавать кучу разных экземпляров, разных типов. Или в случае с методом - не плодить кучу переопределенных методов.


####Обобщенные классы и интерфейсы

```C#
public interface IContainer< out T>
{
	//void SetItem(T item);
	T GetItem();
}

public class Container<T> : IContainer<T>
{
	static void Main(string[] args)
	{
		IContainer<Shape> container = new Container<Circle>(new Circle());

		//IContainer<Shape> list = GetList();

		Console.ReadKey();
	}

	public static IContainer<Shape> GetList()
	{
		return new Container<Circle>(new Circle());
	}

	private T item;

	public Container(T item)
	{
		this.item = item;
	}

	public T GetItem()
	{
		return item;
	}
}


public class Shape
{ 

}

public class Circle : Shape
{ 

}
```

Container - это класс который может быть контейнером для любого типа. И он реализует обобщенный интерфейс IContainer с одним метода T GetItem(). Если в интерфейсе указано ключевое слово out перед T, то это значит ковариантность. Это говорит компилятору что люблой IContainer<T> может принимть подобный тип или более конкретный (дочерний). Но если мы указали ключевое слово out то в интерфейсе мы сможем только вернуть этот тип, но не использовать в качестве передаваемых параметров.
По умолчанию не поддерживается приведение типов обобщения в интерфейсах. Поэтому и надо делать сомому ковариантность или контрвариантность.

Контрваринтность это приведение родительского типа к дочернему.  IContainer<Circle> container = new Container<Shape>(new Shape());. Для этого в интерфейсе необходимо указать вместо ref - in. Также как и ковариантность, контрвариантость накладывает ограничения на интерфейс. В интерфейсе не может быть сигнатур с возвращаемыми типами. Только методы типа void, но можно передавать параметры.

===

---


###<a name='Interesting'> Интересные вопросы </a>

=== 

###<a name='ForeachForClass'> Что нужно чтобы класс работал с foreach </a>
	
Один из вопросов на собеседованиях. И ответ на него - "Необходимо реализовать IEnumerable" - правильный но не полный. 
Для того чтобы наш класс работал с foreach нужно чтобы он имел метод GetEnumerator, который будет возвращать объект у которого есть метод MoveNext и свойство Current.

```C#
public class Container
{
    public Enumerator GetEnumerator()
    {
        return new Enumerator();
    }
}
public class Enumerator
{
    public bool MoveNext()
    {
        return false;
    }

    public object Current
    {
        get { return null; }
    }
}
```

###[Оглавление](#logs)
--- 

###<a name='logs'>Логирование</a>
---

1. [Логирование в файл RollingFileAppender] (http://megadarja.blogspot.ru/2008/04/log4net.html)
1. [Решение которое я искал по универсальному логгеру] (http://www.codeproject.com/Tips/381212/log-Net-logging-framework)
1. [Разные насройки конфигов] (http://logging.apache.org/log4net/release/config-examples.html)

Если описать такую ситуацию. Мы создаем универсальную библиотеку классов Infrastructure.Logging (Log4NetLibrary). Создаем там собственный config файл для регулирования мест записи в логи (база или файл). 

И если у нас будет один интерфейс ILogService и два класса для его реализации: DBLogService и FileLogService. 

В итоге в любом проекте мы настраиваем IoC так чтобы один интерфейс отвечал одной реализации. ОК. 

```
container.Register(Classes.FromAssemblyNamed("Infrastructure.Logging").Pick().WithService.DefaultInterfaces().LifestyleTransient());
```

Но возникает вопрос. А если мы в проекте хотим одновременно записывать логи и в файл и в базу???


###[Оглавление](#OGL)
---

###<a name='Indexer'>Индексаторы</a>

- синтаксическое средство, позволяющее создать класс, структуру или интерфейс где доступ будет подобен массиву.
- нужен для типов где главная цель - инкапсулировать коллекцию или массив.
- можно образом получается более простой доступ к элементам массива экземпляра класса, и класс делается интитивно понятным.
- Чтобы объявить индексатор для класса или структуры, используйте ключевое слово this

```
class Sentence
	{
		string[] words = "The quick brown fox".Split();

		public string this[int wordNum]      // indexer
		{
			get { return words[wordNum]; }
			set { words[wordNum] = value; }
		}
	}
	class Program
	{
		static void Main()
		{
			Sentence s = new Sentence();
			Console.WriteLine(s[3]);       // fox
			s[3] = "kangaroo";
			Console.WriteLine(s[3]);       // kangaroo
			Console.WriteLine(s[7]);       // exception
		}
	}
```

Или вот еще пример

```
// Using a string as an indexer value
class DayCollection
{
    string[] days = { "Sun", "Mon", "Tues", "Wed", "Thurs", "Fri", "Sat" };

    // The get accessor returns an integer for a given string
    public int this[string day]
    {
        get
        {
            return (GetDay(day));
        }
    }
}
```

###[Оглавление](#OGL)
---

###<a name='PartialClass'>Разделяемые классы</a>

- имеем возможность разделять класс, метод или интерфейс между несколькими файлами
- все части объединяются после компиляции
- используется модификатор partial

```
partial class PaymentForm { public int X; }
	partial class PaymentForm { public int Y; }

	class Program
	{
		static void Main()
		{
			new PaymentForm {X = 5, Y = 99};
		}
	}
```
