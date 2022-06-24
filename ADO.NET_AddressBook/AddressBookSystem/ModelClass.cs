// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookSystem
{
    internal class ModelClass
    {
        public int ID { get; set; }
        public string NAME { get; set; }
        public string LASTNAME { get; set; }
        public string ADDRESS { get; set; }
        public string CITY { get; set; }
        public string STATE { get; set; }
        public string ZIP { get; set; }
        public string PHONENO { get; set; }
        public string EMAIL { get; set; }
    }
}