﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YourBestPWrBack.Models;

namespace YourBestPWrBack.Services
{
    public interface IUserRepo
    {
        public void AddUser(User user);
        public void RemoveUser(string username);
        public User GetUser(string username);
    }
}
