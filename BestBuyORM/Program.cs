using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System.Data;
using System.Drawing.Printing;

namespace BestBuyORM
{
    public class Program
    {
        static void Main(string[] args)
        {
            #region Configuration

            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
           
            string connString = config.GetConnectionString("DefaultConnection");
            
            #endregion

            IDbConnection connection = new MySqlConnection(connString);
            var Prod = new DapperProductRepository(connection);

            Prod.CreateProduct("New Stuff", 20, 1);
            var products = Prod.GetAllProducts();
            foreach (var product in products)
            {
                Console.WriteLine($"{product.ProductID} {product.Name}");}
            }



           


        }

       
    }
}