using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YourBestPWrFront.Models
{
    public class Opinion
    {
        public int Rating { get; set; }
        public string Description { get; set; }
        public int LecturerId { get; set; }
        public int UserId { get; set; }
        public int CourseId { get; set; }
        public DateTime Date { get; set; }
    }
}
