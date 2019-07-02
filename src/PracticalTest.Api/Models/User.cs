using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PracticalTestApi.Models
{
    public class User
    {
        public User()
        {
        }

        public User(int id, string name, int age, string address)
        {
            Id = id;
            Name = name;
            Age = age;
            Address = address;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
    }
}
