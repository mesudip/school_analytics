using System;
using MySql.Data.MySqlClient;
using System.Windows.Controls;
using System.Data;

namespace Database
{
    public struct Student
    {
        
        public int id { get; }
        public string name { set; get; }
        public DateTime dob { set; get; }
        public string father_name { set; get; }
        public string mother_name { set; get; }
        public string guardian_name { set; get; }
        public string roll_no { set; get; }
        public string guardian_contact { set; get; }
        public string address { set; get; }
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
        static string password="toor";
        static string hostAddress="localhost";

        public MySqlConnection MySqlConnection {get; }
        public Connection()
        {
            try
            {
                Console.WriteLine("The values are:" + userName + password + hostAddress);
                string connectionString = "server=" + hostAddress + ";userid=" + userName + ";password=" + password + ";database=schoolmanagement";
                this.MySqlConnection = new MySqlConnection(connectionString);
                this.MySqlConnection.Open();
            }
            catch (Exception e)
            {
                Console.Error.WriteLine("This is severe error :" + e.ToString());
            }
        }
        public Connection(string databaseName)
        {
            try
            {
                Console.WriteLine("The values are:" + userName + password + hostAddress);
                string connectionString = "server=" + hostAddress + ";userid=" + userName + ";password=" + password + ";database=" + databaseName;
                this.MySqlConnection = new MySqlConnection(connectionString);
                this.MySqlConnection.Open();
            }
            catch(Exception e)
            {
                Console.Error.WriteLine("This is severe error :" + e.ToString());
            }
        }
    }

    public static  class Interface
    {
        static public string AddStudent(Student student)
        {
            Connection connection = new Connection("schoolmanagement");
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
                //connection.MySqlConnection.Close();
            }
            return null;
        }
        public static string FindStudent(string query,DataGrid grid)
        {
            Connection connection = new Connection();
            Console.WriteLine("This line is executed");
            try
            {
                
                string command = "select * from student where name like @query_string";
                MySqlCommand mysql_command = new MySqlCommand(command,connection.MySqlConnection);

                mysql_command.Prepare();
                mysql_command.Parameters.AddWithValue("@query_string",'%' + query + '%');
                MySqlDataAdapter adaptor = new MySqlDataAdapter(mysql_command);
                DataTable table = new DataTable("Student_Search_Result");
                adaptor.Fill(table);
                grid.ItemsSource = table.DefaultView;
                Console.WriteLine("This line is also executed");
            }
            catch (Exception ex)
            {
                
                Console.WriteLine(Convert.ToString(ex));
                return ex.Message;
            }
            finally
            {
                //connection.MySqlConnection.Close();
            }
            return null;
        }
        public static string UpdateStudent(Student student)
        {
            Connection connection = new Connection("student");
            try
            {

                MySqlCommand command = new MySqlCommand(
                    @"update student set name=@name dob,father_name=@father_name,mother_name=@mother_name,guardian_contact=@guardian_contact,guardian_name=@guardian_name,address=@address,roll_no@roll_no where id= @id", connection.MySqlConnection);
                command.Prepare();
                command.Parameters.AddWithValue("@name", student.name);
                command.Parameters.AddWithValue("@dob", student.dob);
                command.Parameters.AddWithValue("@father_name", student.father_name);
                command.Parameters.AddWithValue("@mother_name", student.mother_name);
                command.Parameters.AddWithValue("@guardian_name", student.guardian_name);
                command.Parameters.AddWithValue("@guardian_contact", student.guardian_name);
                command.Parameters.AddWithValue("@address", student.address);
                command.Parameters.AddWithValue("@roll_no", student.roll_no);
                command.Parameters.AddWithValue("@id", student.id);                 
                command.ExecuteNonQuery();


            }
            catch (MySqlException exception)
            {
                System.Console.Error.WriteLine(exception.ToString());
            }
            finally
            {
                connection.MySqlConnection.Close();
            }
            return null;
        }

        
    }
}