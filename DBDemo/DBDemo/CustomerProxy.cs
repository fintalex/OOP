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
    public class CustomerProxy
    {
        public int Id { get; set; }
        public string Name { get; set; }

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
