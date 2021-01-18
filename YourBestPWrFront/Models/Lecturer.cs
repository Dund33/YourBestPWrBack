using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YourBestPWrFront.Models
{
    public class Lecturer : LecturerBasic
    {
        public List<Opinion> Opinions { get; init; }
    }
}
