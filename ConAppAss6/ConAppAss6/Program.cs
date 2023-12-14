using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConAppAss6
{
    internal class Program
    {
      
        static SqlConnection con;
        static SqlCommand cmd;
        static SqlDataReader reader;

        static string constr = "server=ROJA;database= ProductInventoryDB;trusted_connection=true;";

        static void Main(string[] args)
        {
            try
            {
                con = new SqlConnection(constr);
                cmd = new SqlCommand
                {
                    Connection = con,
                };
                Console.WriteLine("choose operation from list: ");
                Console.WriteLine("1.view \n 2.add \n 3.update \n 4.remove");
                int op = int.Parse(Console.ReadLine());
                switch (op)
                {
                    case 1:
                        {
                            cmd.CommandText = "select * from Products";
                            con.Open();
                            reader = cmd.ExecuteReader();
                            while (reader.Read())
                            {
                                Console.WriteLine($"{reader["ProductId"]}\t\t{reader["ProductName"]}\t \t{reader["Price"]}\t {reader["Quantity"]}\t \t{reader["MfDate"]}\t {reader["ExpDate"]}");

                            }

                            break;
                        }
                    case 2:
                        {
                            cmd.CommandText = "insert into Products(ProductId,ProductName,Price,Quantity,MfDate,ExpDate) values (@id,@name,@price,@qty,@mdate,@edate)";
                            Console.WriteLine("enter product id: ");
                            cmd.Parameters.AddWithValue("@id", int.Parse(Console.ReadLine()));
                            Console.WriteLine("enter product name: ");
                            cmd.Parameters.AddWithValue("@name", Console.ReadLine());
                            Console.WriteLine("enter price: ");
                            cmd.Parameters.AddWithValue("@price", double.Parse(Console.ReadLine()));
                            Console.WriteLine("enter quantity: ");
                            cmd.Parameters.AddWithValue("@qty", Console.ReadLine());
                            Console.WriteLine("enter manufacture date: ");
                            cmd.Parameters.AddWithValue("@mfd", DateTime.TryParse(Console.ReadLine(), out DateTime mfd));
                            Console.WriteLine("enter exp date: ");
                            cmd.Parameters.AddWithValue("@mfd", DateTime.TryParse(Console.ReadLine(), out DateTime efd));
                            con.Open();
                            cmd.ExecuteNonQuery();
                            Console.WriteLine("record inserted");
                            break;

                        }
                    case 3:
                        {
                            cmd.CommandText = "update Products set ProductName=@name,Price=@price,Quantity=@qty,MfDate=@mfd,ExpDate=@exd where id=@ID";
                            Console.WriteLine("Enter product Id to update the record");
                            int id = int.Parse(Console.ReadLine());
                            cmd.Parameters.AddWithValue("@ID", id);
                            Console.WriteLine("Enter the product Name");
                            cmd.Parameters.AddWithValue("@name", Console.ReadLine());
                            Console.WriteLine("Enter price");
                            cmd.Parameters.AddWithValue("@price", double.Parse(Console.ReadLine()));
                            Console.WriteLine("enter quantity: ");
                            cmd.Parameters.AddWithValue("@qty", Console.ReadLine());
                            Console.WriteLine("enter manufacture date: ");
                            cmd.Parameters.AddWithValue("@mfd", DateTime.TryParse(Console.ReadLine(), out DateTime mfd));
                            Console.WriteLine("enter exp date: ");
                            cmd.Parameters.AddWithValue("@mfd", DateTime.TryParse(Console.ReadLine(), out DateTime efd));
                            con.Open();
                            int noe = cmd.ExecuteNonQuery();
                            if (noe > 0)
                            {
                                Console.WriteLine($"Record updated for id{id} !!!");
                            }
                            break;

                        }
                    case 4:
                        {
                            cmd.CommandText = "delete from Employee where Id=@id";
                            Console.WriteLine("enter employee id: ");
                            cmd.Parameters.AddWithValue("@id", int.Parse(Console.ReadLine()));
                            con.Open();
                            int noe = cmd.ExecuteNonQuery();
                            if (noe > 0)
                            {
                                Console.WriteLine("record deleted");
                            }
                            break;


                        }

                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("error!!!" + ex.Message);
                }
                finally
                {
                    con.Close();
                    Console.ReadKey();
                }
            }
        }
    }
