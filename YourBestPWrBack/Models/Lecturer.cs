using System.Collections.Generic;

namespace YourBestPWrBack.Models
{
    public class Lecturer : LecturerBasic
    {
        public List<Opinion> Opinions { get; init; }
    }
}
