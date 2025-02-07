﻿using System.Collections.Generic;
using YourBestPWrBack.Models;

namespace YourBestPWrBack.Extensions
{
    public static class LecturerBasicExtensions
    {
        public static Lecturer ToLecturer(this LecturerBasic lecturerBasic)
            => new Lecturer
            {
                FirstName = lecturerBasic.FirstName,
                LastName = lecturerBasic.LastName,
                Title = lecturerBasic.Title,
                Opinions = new List<Opinion>()
            };
    }
}
