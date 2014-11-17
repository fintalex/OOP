1. [Интерфейс](#Interface)
2. [Инкапсуляция Наследование, Полиморфизм](#IncInhPol)

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
 Overiding and Overloading
===

***Перегрузка*** (Overloading) - определение двух методов с одинаковым именем в пределах одного класса но имеющих разную сигнатуру.

***Переопределение*** (Overiding) - определение метода который определен в родительском классе. Метод имеет ту же  сигнатуру.

