// See https://aka.ms/new-console-template for more information
using System;
using System.Data;
using System.Data.SqlClient;

namespace AddressBookSystem
{
    public class AddressBook
    {
        public static string dbpath = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=AddressBook";
        SqlConnection connect = new SqlConnection(dbpath);

        //retrieve data from table
        public void GetAddressbook()
        {
            AddressBookSystem.ModelClass model = new AddressBookSystem.ModelClass();
            SqlConnection connect = new SqlConnection(dbpath);
            using (connect)
            {
                connect.Open();
                string query = "Select * from Address_Book";
                SqlCommand command = new SqlCommand(query, connect);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    //Console.WriteLine("ID\tName\t\t\tSalary\t\t\tDate\t\t\t\tGender\n");
                    while (reader.Read())
                    {
                        model.ID = reader.GetInt32(0);
                        model.FIRSTNAME = reader.GetString(1);
                        model.LASTNAME = reader.GetString(2);
                        model.ADDRESSs = reader.GetString(3);
                        model.CITY = reader.GetString(4);
                        model.STATE = reader.GetString(5);
                        model.ZIP = reader.GetString(6);
                        model.PHONENO = reader.GetString(7);
                        model.EMAIL = reader.GetString(8);
                        Console.WriteLine("ID: " + model.ID + "\nNAME: " + model.FIRSTNAME + "\nLastName: " + model.LASTNAME +
                               "\nAddress" + model.ADDRESSs + "\nCity: " + model.CITY + "\nState:" + model.STATE + "\nZipCode: " + model.ZIP
                               + "\nPhone: " + model.PHONENO + "\nEmail: " + model.EMAIL + "\n");
                    }
                }
                else
                {
                    Console.WriteLine("Records not found in Database");
                }
                reader.Close();
            }
            connect.Close();
        }

     
        public void CreateNewContact(ModelClass model)
        {
            SqlConnection connect = new SqlConnection(dbpath);
            lock (this)
                using (connect)
                {
                    connect.Open();
                    SqlCommand sql = new SqlCommand("SPAddress_Book", connect);
                    sql.CommandType = CommandType.StoredProcedure;
                    sql.Parameters.AddWithValue("@FIRSTNAME", model.FIRSTNAME);
                    sql.Parameters.AddWithValue("@LASTNAME", model.LASTNAME);
                    sql.Parameters.AddWithValue("@ADDRESSs", model.ADDRESSs);
                    sql.Parameters.AddWithValue("@CITY", model.CITY);
                    sql.Parameters.AddWithValue("@STATE", model.STATE);
                    sql.Parameters.AddWithValue("@ZIP", model.ZIP);
                    sql.Parameters.AddWithValue("@PHONENO", model.PHONENO);
                    sql.Parameters.AddWithValue("@EMAIL", model.EMAIL);
                    sql.ExecuteNonQuery();
                    Console.WriteLine("Record created successfully.");
                    connect.Close();
                }
        }


        //Update table record
        public void UpdateRecord()
        {
            SqlConnection connect = new SqlConnection(dbpath);
            try
            {
                using (connect)
                {
                    Console.WriteLine("Enter name of Person:");
                    string name = Console.ReadLine();
                    Console.WriteLine("Enter phoneno to update:");
                    string phone = Console.ReadLine();
                    connect.Open();
                    string query = "update Address_Book set PHONENO =" + phone + "where FIRSTNAME='" + name + "'";
                    SqlCommand command = new SqlCommand(query, connect);
                    command.ExecuteNonQuery();
                    Console.WriteLine("Records updated successfully.");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("-------\nError:Records are not updated.\n-----");
            }
        }


        //Delete record from table
        public void DeleteRecord()

        {

            SqlConnection connect = new SqlConnection(dbpath);

            using (connect)

            {

                connect.Open();

                Console.WriteLine("Enter name of person to  delete from records:");

                string name = Console.ReadLine();

                string query = "delete from Address_Book where FirstName='" + name + "'"; ;

                SqlCommand command = new SqlCommand(query, connect);

                command.ExecuteNonQuery();
                Console.WriteLine("Record Deleted successfully.");

                connect.Close();

            }
        }
        public void AddMultipleEmployee(List<ModelClass> data)
        {
            data.ForEach(details =>
            {
                Thread thread = new Thread(() =>
                {
                    Console.WriteLine("Thread Start Time: " + DateTime.Now);
                    this.CreateNewContact(details);
                    Console.WriteLine("Contact Added: " + details.FIRSTNAME);
                    Console.WriteLine("Thread End Time: " + DateTime.Now);
                });
                thread.Start();
            });
        }
    }
}


