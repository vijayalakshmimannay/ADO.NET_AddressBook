// See https://aka.ms/new-console-template for more information
using System;
namespace AddressBookSystem
{
    class program
    {
        public static void Main(string[] args)
        {
            AddressBookSystem.AddressBook contact = new AddressBookSystem.AddressBook();
            //contact.GetAddressbook();
            //contact.CreateNewContact();
            //contact.UpdateRecord();
          

            List<ModelClass> list = new List<ModelClass>();
            Console.WriteLine("Enter number of contacts to Add");
            int number = Convert.ToInt32(Console.ReadLine());
            int i = 0;
            while (i < number)
            {
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
                list.Add(model);
                i++;
            }
            contact.AddMultipleEmployee(list);
        }
    }
}