﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.VisualBasic.CompilerServices;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace YourBestPWrBack.Models
{
    public class User: IEquatable<User>
    {
        [System.Runtime.Serialization.IgnoreDataMember]
        [JsonIgnore]
        [BsonId]
        public BsonObjectId Id { get; init; }
        [NotNull]
        [Required]
        public string UserName { get; init; }
        [NotNull]
        [Required]
        public string PasswordHash { get; set; }
        [NotNull]
        [Required]
        public AccessType AccessType { get; set; }

        public static bool operator==(User user1, User user2)
        {
            return user1?.UserName == user2?.UserName;
        }

        public static bool operator!=(User user1, User user2)
        {
            return user1?.UserName != user2?.UserName;
        }

        public override int GetHashCode()
        {
            return UserName.GetHashCode();
        }

        public override bool Equals(object other)
        {
            if (other is User user)
            {
                return UserName == user.UserName;
            }

            return false;
        }

        public bool Equals([AllowNull] User other)
        {
            return UserName == other?.UserName;
        }
    }
}
