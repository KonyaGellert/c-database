using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace User
{
    internal class Program
    {
        public static string ConnectionString = "server=localhost;user=root;password=;database=users";
        public static MySqlConnection Conn = new MySqlConnection(ConnectionString);
        public static void InsertData(string name, string email, string password)
        {
           Conn.Open();
            string sql = "INSERT INTO data (name, email, password) VALUES (@name, @email, @password)";
            MySqlCommand cmd = new MySqlCommand(sql, Conn);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@password", password);
            cmd.ExecuteNonQuery();

            Conn.Close();
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Kérem a nevet");
            string name = Console.ReadLine();
            Console.WriteLine("Kérem az email címet");
            string email = Console.ReadLine();
            Console.WriteLine("Kérem a jelszót");
            string password = Console.ReadLine();

            InsertData(name, email, password);
        }
    }
}
