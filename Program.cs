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
        public static void ReadData()
        {
            Conn.Open();
            string sql = "SELECT * FROM datas";
            MySqlCommand cmd = new MySqlCommand(sql,Conn);
            MySqlDataReader dr = cmd.ExecuteReader();
            Conn.Close();
            while (dr.Read())
            {
                Console.WriteLine($"{dr.GetInt32(0)} {dr.GetString(1)} {dr.GetString(2)} {dr.GetString(3)} {dr.GetDateTime(5)}");
            }
        }
        public static void DeleteUser(int id)
        {
            Conn.Open();
            string sql = "DELETE FROM datas WHERE id = @id";
            MySqlCommand cmd = new MySqlCommand(sql, Conn);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
            Conn.Close();
        }

        public static void UpdateUser(int id, string name, string email, string password)
        {
            Conn.Open();
            string sql = "UPDATE datas SET name = @name, email = @email, password = @password WHERE id = @id";
            MySqlCommand cmd = new MySqlCommand(sql, Conn);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@password", password);
            cmd.ExecuteNonQuery();
            Conn.Close();
        }
        static void Main(string[] args)


        {
            Console.WriteLine("Válasz menüpontot");
            Console.WriteLine("1. lekérdezés");
            Console.WriteLine("2. beszúrás");
            Console.WriteLine("3. Módosítás");
            Console.WriteLine("4. törlés");

            byte menu = 0;

            do
            {
                menu = byte.Parse(Console.ReadLine());

            } while (menu <= 1 || menu > 4);

            switch (menu)
            {
                case 1:
                    {
                        ReadData();
                        break;
                    }
                case 2:
                    {
                        Console.WriteLine("Kérem a nevet");
                        string name = Console.ReadLine();
                        Console.WriteLine("Kérem az email címet");
                        string email = Console.ReadLine();
                        Console.WriteLine("Kérem a jelszót");
                        string password = Console.ReadLine();

                        InsertData(name, email, password);
                        break;
                    }
                case 3:
                    {
                        Console.WriteLine("Kérem a módosítandó user idjét");
                        int id = int.Parse(Console.ReadLine());
                        Console.WriteLine("Kérem a nevet");
                        string name = Console.ReadLine();
                        Console.WriteLine("Kérem az email címet");
                        string email = Console.ReadLine();
                        Console.WriteLine("Kérem a jelszót");
                        string password = Console.ReadLine();
                        UpdateUser(id, name, email, password);

                        break;
                    }
                case 4:
                    {
                        Console.WriteLine("Kérem a törlendő user idjét");
                        int id = int.Parse(Console.ReadLine());
                        DeleteUser(id);
                        break;
                    }


            }


        }
    }
}
