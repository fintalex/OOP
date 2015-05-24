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
            #region Низкоуровневая работа с базой
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
            #endregion

            #region Выделили в статический метод
            // ================  вывод с помощью статического метода и класса прокси ===================================
            //var customers = GetCustomers();
            //foreach (var cust in customers)
            //{
            //    Console.WriteLine("Идентификатор: {0}\tИмя:{1}", cust.Id, cust.Name);
            //} 
            #endregion


            // ================  вывод с помощью EF ===================================
            var customers = GetCustomersEf();
            foreach (var cust in customers)
            {
                Console.WriteLine("Идентификатор: {0}\tИмя:{1}", cust.CustomerId, cust.CustomerName);
            }

            Console.ReadLine();
        }

        private static List<Customer> GetCustomersEf()
        {
            var context = new TestDbContext();

            var customers = context.Customers.ToList();

            return customers;
        }

        public static List<CustomerProxy> GetCustomers()
        {
            using (IDbConnection connection = new SqlConnection(Settings.Default.DbConnect))
            {
                IDbCommand command = new SqlCommand("Select * from t_customer");

                command.Connection = connection;

                connection.Open();

                IDataReader reader = command.ExecuteReader();

                List<CustomerProxy> customers = new List<CustomerProxy>();

                while (reader.Read())
                {
                    CustomerProxy customer = new CustomerProxy();
                    customer.Id = reader.GetInt32(0);
                    customer.Name = reader.GetString(1);

                    customers.Add(customer);
                }

                return customers;
            }


        }
    }
}
