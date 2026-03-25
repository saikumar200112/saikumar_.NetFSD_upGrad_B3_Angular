using System;
using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.IO;

internal class Program
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
            Console.WriteLine("\n PRODUCT MANAGEMENT (DISCONNECTED-Model)");
            Console.WriteLine("1. Insert | 2. View All | 3. View by ID | 4. Update | 5. Delete | 6. Exit");
            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            if (choice == "6")
            {
                break;
            }

            using (SqlConnection conn = new SqlConnection(connStr))
            {

                SqlDataAdapter adapter = new SqlDataAdapter();
                DataTable dt = new DataTable();

                if (choice == "1")
                {
                    Console.Write("Name: ");
                    string name = Console.ReadLine();
                    Console.Write("Category: ");
                    string cat = Console.ReadLine();
                    Console.Write("Price: ");
                    decimal price = decimal.Parse(Console.ReadLine());

                    SqlCommand cmd = new SqlCommand("sp_InsertProduct", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@ProductName", SqlDbType.VarChar) { Value = name });
                    cmd.Parameters.Add(new SqlParameter("@Category", SqlDbType.VarChar) { Value = cat });
                    cmd.Parameters.Add(new SqlParameter("@Price", SqlDbType.Decimal) { Value = price });

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    Console.WriteLine("Inserted!");
                }
                else if (choice == "2")
                {
                    SqlCommand cmd = new SqlCommand("sp_GetAllProducts", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    adapter.SelectCommand = cmd;
                    adapter.Fill(dt);

                    Console.WriteLine("\nID | Name | Category | Price");
                    foreach (DataRow row in dt.Rows)
                    {
                        Console.WriteLine($"{row["ProductId"]} | {row["ProductName"]} | {row["Category"]} | {row["Price"]}");
                    }
                }
                else if (choice == "3")
                {
                    Console.Write("Enter ID: ");
                    int id = int.Parse(Console.ReadLine());

                    SqlCommand cmd = new SqlCommand("sp_GetProductById", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ProductId", id);

                    adapter.SelectCommand = cmd;
                    adapter.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        DataRow r = dt.Rows[0];
                        Console.WriteLine($"Result: {r["ProductName"]} ({r["Category"]}) - INR.{r["Price"]}");
                    }
                    else { Console.WriteLine("Not found."); }
                }
                else if (choice == "4")
                {
                    Console.Write("ID to Update: ");
                    int id = int.Parse(Console.ReadLine());
                    Console.Write("New Name: ");
                    string name = Console.ReadLine();
                    Console.WriteLine("New Category:");
                    string cat = Console.ReadLine();
                    Console.Write("New Price: ");
                    decimal price = decimal.Parse(Console.ReadLine());

                    SqlCommand cmd = new SqlCommand("sp_UpdateProduct", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@ProductId", SqlDbType.Int) { Value = id });
                    cmd.Parameters.Add(new SqlParameter("@ProductName", SqlDbType.VarChar) { Value = name });
                    cmd.Parameters.Add(new SqlParameter("@Category", SqlDbType.VarChar) { Value = cat });
                    cmd.Parameters.Add(new SqlParameter("@Price", SqlDbType.Decimal) { Value = price });

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    Console.WriteLine("Updated!");
                }
                else if (choice == "5") 
                {
                    Console.Write("ID to Delete: "); int id = int.Parse(Console.ReadLine());

                    SqlCommand cmd = new SqlCommand("sp_DeleteProduct", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ProductId", id);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    Console.WriteLine("Deleted!");
                }

            }
        }

    }
}