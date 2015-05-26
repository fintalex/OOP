using DomainModel.Abstract;
using DomainModel.Entities;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Concrete
{
    public class SqlProductRepository : IProductsRepository
    {
        private Table<Product> productsTable;
        //public SqlProductRepository(string connectionString)
        //{
        //    productsTable = (new DataContext(connectionString)).GetTable<Product>();
        //}
        string connString = @"Data Source=ALEX-PC\SQLEXPRESS;Initial Catalog=SportStore;Integrated Security=True";
        public SqlProductRepository()
        {
            productsTable = (new DataContext(connString)).GetTable<Product>();
        }
        public IQueryable<Entities.Product> Products
        {
            get { return productsTable; }
        }
    }
}
