using System;
using MySql.Data.MySqlClient;
using System.Windows.Controls;

namespace Database
{
    struct Student
    {
        
        public int id;
        public string name;
        public DateTime dob;
        public string father_name;
        public string mother_name;
        public string guardian_name;
        public string roll_no;
        public string guardian_contact;
        public string address;
    }
    struct Teacher
    {
        int id;
        string name;
        DateTime dob;
        string father_name;
        string mother_name;
        string id_no;
        string address;
        string email_address;
        string contact;

    }
    public class Connection

    {

        static string userName="root";
        static string password="Sunita50655496";
        static string hostAddress="localhost";

        public MySqlConnection MySqlConnection {get; }

        public Connection(string databaseName)
        {
            string connectionString = "server=" + hostAddress + ";userid=" + userName + ";password=" + password + ";database=" + databaseName;
            this.MySqlConnection = new MySqlConnection();
        }
    }

    public static  class Interface
    {
        static string AddStudent(Student student)
        {
            Connection connection = new Connection("student");
            try
            {
                
                MySqlCommand command = new MySqlCommand(
                    @"insert into student(name,dob,father_name,mother_name,guardian_contact,guardian_name,address,roll_no) values(@name,@dob,@father_name,@mother_name,@guardian_contact,@guardian_name,@address,@roll_no", connection.MySqlConnection);
                command.Prepare();
                command.Parameters.AddWithValue("@name", student.name);
                command.Parameters.AddWithValue("@name", student.dob);
                command.Parameters.AddWithValue("@father_name", student.father_name);
                command.Parameters.AddWithValue("@mother_name", student.mother_name);
                command.Parameters.AddWithValue("@guardian_name", student.guardian_name);
                command.Parameters.AddWithValue("@guardian_contact", student.guardian_name);
                command.Parameters.AddWithValue("@address", student.address);
                command.Parameters.AddWithValue("@roll_no", student.roll_no);
                command.ExecuteNonQuery();
                
                
            }
            catch(MySqlException exception)
            {
                System.Console.Error.WriteLine(exception.ToString());
            }
            finally
            {
                connection.MySqlConnection.Close();
            }
            return null;
        }
        static string FindStudent(string query,DataGrid grid)
        {
            return null;
        }
    }
}