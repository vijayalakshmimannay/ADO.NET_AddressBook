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
        /*public void GetAddressbook()
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
                        model.NAME = reader.GetString(1);
                        model.LASTNAME = reader.GetString(2);
                        model.ADDRESS = reader.GetString(3);
                        model.CITY = reader.GetString(4);
                        model.STATE = reader.GetString(5);
                        model.ZIP = reader.GetString(6);
                        model.PHONENO = reader.GetString(7);
                        model.EMAIL = reader.GetString(8);
                        Console.WriteLine("ID: " + model.ID + "\nNAME: " + model.NAME + "\nLastName: " + model.LASTNAME +
                               "\nAddress" + model.ADDRESS + "\nCity: " + model.CITY + "\nState:" + model.STATE + "\nZipCode: " + model.ZIP
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
        }*/

        public void CreateNewContact()
        {
            SqlConnection connect = new SqlConnection(dbpath);
            using (connect)
            {
                connect.Open();
                AddressBookSystem.ModelClass model = new AddressBookSystem.ModelClass();
                Console.WriteLine("Enter First Name");
                model.FIRSTNAME = Console.ReadLine();
                Console.WriteLine("Enter Last Name");
                model.LASTNAME = Console.ReadLine();
                Console.WriteLine("Enter Address ");
                model.ADDRESSs = Console.ReadLine();
                Console.WriteLine("Enter City ");
                model.CITY = Console.ReadLine();
                Console.WriteLine("Enter State ");
                model.STATE = Console.ReadLine();
                Console.WriteLine("Enter Zip Code ");
                model.ZIP = Console.ReadLine();
                Console.WriteLine("Enter Phone ");
                model.PHONENO = Console.ReadLine();
                Console.WriteLine("Enter Email ");
                model.EMAIL = Console.ReadLine();
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


    }
}
