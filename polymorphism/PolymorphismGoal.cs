using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Program
{
    static void Main(string[] args)
    {
        BaseShip ship = GetShip(ShipType.TransportShip);

        Console.WriteLine(ship.Fight());

        Console.ReadLine();
    }

    static BaseShip GetShip(ShipType type)
    {
        switch (type)
        {
            case ShipType.TransportShip:
                return new TransportShip();
            case ShipType.FightShip:
                return new FightShip();
            default:
                throw new Exception(" Неизвестный тип корабля");
        }
    }
}

public class BaseShip
{
    public virtual string Fight()
    {
        return "Идет бой";
    }
}

public class TransportShip : BaseShip
{
    public override string Fight()
    {
 	     return "Транспортный корабль не воюет";
    }
}

public class FightShip : BaseShip 
{
    public override string Fight()
    {
        return "Корабль вступил в бой";
    }
}

public enum ShipType
{
    TransportShip = 1,
    FightShip =2
}

