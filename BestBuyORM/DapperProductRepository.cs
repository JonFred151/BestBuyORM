using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestBuyORM
{
    public class DapperProductRepository: IProductRepository
    {
        public readonly IDbConnection  _connection;
        public DapperProductRepository(IDbConnection connection) 
        {
            _connection = connection;
        }

         public IEnumerable<Product> GetAllProducts()
        {
            return _connection.Query<Product>("SELECT * FROM products;");

        }
        public void CreateProduct(string name, double price, int categoryID) 
        {
            _connection.Execute("INSERT INTO products (Name, Price, CategoryID) VALUES (@name, @price, @categoryID);",
                new { name = name, price = price, categoryID = categoryID });
        }

        
    }
}
