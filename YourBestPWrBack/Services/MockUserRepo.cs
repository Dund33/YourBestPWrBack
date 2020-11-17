﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YourBestPWrBack.Models;

namespace YourBestPWrBack.Services
{
    public class MockUserRepo: IUserRepo
    {
        private readonly List<User> _users = new List<User>
        {
            new User
            {
                AccessType = AccessType.Admin,
                Name = "Adi2024",
                PasswordHash = "5f4dcc3b5aa765d61d8327deb882cf99", // password
            },
            new User
            {
                AccessType = AccessType.User,
                Name = "Manyana",
                PasswordHash = "1f82cdf9195b31244721c6026587fb78" //password23
            },
            new User{
                AccessType = AccessType.Basic,
                Name = "Skid",
                PasswordHash = "a21992c8f0aca8b8961b06c8e30eff6c" //password234
            }
        };

        public void AddUser(User user)
        {
            if (_users.Contains(user))
                return;
            _users.Add(user);
        }

        public void RemoveUser(User user)
        {
            if (!_users.Contains(user))
                return;
            _users.Remove(user);
        }

        public User GetUser(string username) 
            => _users.FirstOrDefault(user => user.Name == username);
    }
}
