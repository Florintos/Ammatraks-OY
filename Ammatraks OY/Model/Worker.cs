using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ammatraks_OY.Model
{
    public class Worker : User
    {
        public string Name { get; set; }
        public int ID { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public Worker() { }

        public Worker(string username, string password, string name, int id, string phoneNumber, string email)
        {
            Username = username;
            Password = password;
            Name = name;
            ID = id;
            PhoneNumber = phoneNumber;
            Email = email;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
