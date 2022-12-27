using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace WebAPI.Model.DBHelper
{
    public class DBManager
    {
        public DBManager() { }
        public void createUser(User user)
        {
            string connectionString = "Server=DESKTOP-U2K0EKM;Database=UserDB;User Id=sa;Password=shovondb;";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string Query = "insert into Users(Name, Email, DOB) values('" + user.Name + "', '" + user.Email + "', '" + user.DOB + "')";
            SqlCommand cmd = new SqlCommand(Query, connection);
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        public List<User> readUser()
        {
            string connectionString = "Server=DESKTOP-U2K0EKM;Database=UserDB;User Id=sa;Password=shovondb;";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlDataReader reader;
            reader = new SqlCommand("select ID, Name, Email, DOB from Users order by ID ASC", connection).ExecuteReader();
            List<User> users = new List<User>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    User user = new User(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3));
                    users.Add(user);
                }
            }
            else
            {
                Console.WriteLine("No rows found.");
            }
            connection.Close();
            return users;
        }

        public void updateUser(User user)
        {
            string connectionString = "Server=DESKTOP-U2K0EKM;Database=UserDB;User Id=sa;Password=shovondb;";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            string Query = "UPDATE Users SET Name = '" + user.Name + "', Email = '" + user.Email + "', DOB = '" + user.DOB + "' WHERE ID =" + user.ID;
            SqlCommand cmd = new SqlCommand(Query, connection);
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        public void removeUser(int id)
        {
            string connectionString = "Server=DESKTOP-U2K0EKM;Database=UserDB;User Id=sa;Password=shovondb;";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            string Query = "DELETE FROM Users where ID=" + id;
            Console.WriteLine("here : " + Query);
            SqlCommand cmd = new SqlCommand(Query, connection);
            cmd.ExecuteNonQuery();
            connection.Close();
        }
    }
}
