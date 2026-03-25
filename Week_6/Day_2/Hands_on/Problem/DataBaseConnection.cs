using System;
using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
      
        var config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();

        
        string connStr = config.GetConnectionString("DefaultConnection");

        while (true)
        {
            Console.WriteLine("\n PRODUCT MANAGEMENT ");
            Console.WriteLine("1. Insert | 2. View | 3.ViewById| 4. Update | 5. Delete | 6. Exit");
            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            if (choice == "6") break;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                if (choice == "1")
                {
                    Console.Write("Product Name: ");
                    string name = Console.ReadLine();
                    Console.Write("Category: ");
                    string cat = Console.ReadLine();
                    Console.Write("Price: ");
                    decimal price = decimal.Parse(Console.ReadLine());

                    SqlCommand cmd = new SqlCommand("sp_InsertProduct", conn);
                    cmd.CommandType = CommandType.StoredProcedure;


                    SqlParameter p1 = new SqlParameter("@ProductName", SqlDbType.VarChar) { Value = name };
                    SqlParameter p2 = new SqlParameter("@Category", SqlDbType.VarChar) { Value = cat };
                    SqlParameter p3 = new SqlParameter("@Price", SqlDbType.Decimal) { Value = price };

                    cmd.Parameters.Add(p1);
                    cmd.Parameters.Add(p2);
                    cmd.Parameters.Add(p3);

                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Product inserted successfully!");
                }
                else if (choice == "2")
                {
                    SqlCommand cmd = new SqlCommand("sp_GetAllProducts", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        Console.WriteLine("\nID | Name | Category | Price");
                        while (reader.Read())
                        {
                            Console.WriteLine($"{reader["ProductId"]} | {reader["ProductName"]} | {reader["Category"]} | {reader["Price"]}");
                        }
                    }
                }
                else if (choice == "3") 
                {
                    Console.Write("Enter Product ID to search: ");
                    int id = int.Parse(Console.ReadLine());

                    SqlCommand cmd = new SqlCommand("sp_GetProductById", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@ProductId", SqlDbType.Int) { Value = id });

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {

                        if (reader.Read())
                        {
                            Console.WriteLine("\n Product Details ");
                            Console.WriteLine($"ID:       {reader["ProductId"]}");
                            Console.WriteLine($"Name:     {reader["ProductName"]}");
                            Console.WriteLine($"Category: {reader["Category"]}");
                            Console.WriteLine($"Price:    {reader["Price"]}");
                        }
                        else
                        {
                            Console.WriteLine("Product not found.");
                        }
                    }
                }


                else if (choice == "4")
                {
                    Console.Write("Enter Product ID to update: ");
                    int id = int.Parse(Console.ReadLine());
                    Console.Write("New Name: ");
                    string name = Console.ReadLine();
                    Console.Write("New Category: ");
                    string cat = Console.ReadLine();
                    Console.Write("New Price: ");
                    decimal price = decimal.Parse(Console.ReadLine());

                    SqlCommand cmd = new SqlCommand("sp_UpdateProduct", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("@ProductId", SqlDbType.Int) { Value = id });
                    cmd.Parameters.Add(new SqlParameter("@ProductName", SqlDbType.VarChar) { Value = name });
                    cmd.Parameters.Add(new SqlParameter("@Category", SqlDbType.VarChar) { Value = cat });
                    cmd.Parameters.Add(new SqlParameter("@Price", SqlDbType.Decimal) { Value = price });

                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Product updated!");
                }
                else if (choice == "5")
                {
                    Console.Write("Enter Product ID to delete: ");
                    int id = int.Parse(Console.ReadLine());

                    SqlCommand cmd = new SqlCommand("sp_DeleteProduct", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("@ProductId", SqlDbType.Int) { Value = id });

                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Product deleted!");
                }
            }
        }
    }
}