using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace YourBestPWrBack.Models
{
    public class Lecturer
    {
        public int Id { get; set; }
        public string FirstName { get; }
        public string LastName { get; } 
        public string Title { get; }
        public List<Opinion> Opinions { get; set; }
        public Lecturer(string firstName, string lastName, string title)
        {
            FirstName = firstName;
            LastName = lastName;
            Title = title;
        }
    }
}
