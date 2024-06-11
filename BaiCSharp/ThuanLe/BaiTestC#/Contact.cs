using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTestC_
{
    public class Contact
    {
        public int ContactId { get; set; }

        public string FirstName { get; set; }
            
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {MiddleName} {LastName}";
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
            
        public bool Status { get; set; }
        

    }
}
