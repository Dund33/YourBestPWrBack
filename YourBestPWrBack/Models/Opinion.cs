using System;

namespace YourBestPWrBack.Models
{
    public class Opinion
    {
        public int Rating { get; set; }
        public string Description { get; set; }
        public int LecturerId { get; set; }
        public int UserId { get; set; }
        public DateTime Date { get; set; }
    }
}
