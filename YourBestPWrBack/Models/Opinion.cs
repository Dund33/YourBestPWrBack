using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace YourBestPWrBack.Models
{
    public class Opinion
    {
        public int Rating { get; }
        public string Description { get; }
        public Opinion(int rating, string description) => (Rating, Description) = (rating, description);
    }
}
