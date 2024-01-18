using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System.Data;

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
            Console.WriteLine(connString);
            #endregion


            IDbConnection conn = new MySqlConnection(connString);
            DapperDepartmentRepository repo = new DapperDepartmentRepository(conn);

            //   Console.WriteLine("Hello user, here are the current departments:");
            // Console.WriteLine("Please press enter . . .");
            //Console.ReadLine();
            //var depos = repo.GetAllDepartments();
            //foreach (var depo in depos)
            //{
            //    Console.WriteLine($"Id: {depo.DepartmentID} Name: {depo.Name}");
            //}

        }
    }
}