using DBDemo.Properties;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // это все низкоуровневая работа с базой данных
            // Минусы:
            // 1- в С# коде используем sql запрос
            // 2- приходится заботится об открытии соединения
            // 3- работаем с нетипизированным набором данных (мы сами должны знать на какой позиции что должно быть) (раньше так и делали)

            //using (IDbConnection connection = new SqlConnection(Settings.Default.DbConnect))
            //{
            //    IDbCommand command = new SqlCommand("Select * from t_customer");

            //    command.Connection = connection;

            //    connection.Open();

            //    IDataReader reader = command.ExecuteReader();

            //    while (reader.Read())
            //    {
            //        Console.WriteLine("Идентификатор: {0}\Имя:{1}", reader.GetInt32(0), reader.GetString(1));
            //    }
            //}


            //var customers = CustomerProxy.GetCustomers();

            //foreach (var cust in customers)
            //{
            //    Console.WriteLine("Идентификатор: {0}\tИмя:{1}", cust.Id, cust.Name);
            //}

            //Console.ReadLine();
        }
    }
}
