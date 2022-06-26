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
            contact.DeleteRecord();

        }
    }
}