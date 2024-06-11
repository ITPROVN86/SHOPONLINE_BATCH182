using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quanlydanhba
{
    public class Contact
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public bool Status { get; set; }
        public override string ToString()
        {
            return $"ID : {Id} , Name: {FirstName} {MiddleName} {LastName} , Address: {Address} ,Phone: {PhoneNumber}, Status: {(Status ? "Active" : "Inactive")}";
        }
    }
}
