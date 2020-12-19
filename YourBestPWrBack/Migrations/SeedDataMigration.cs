using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YourBestPWrBack.Migrations
{
    [Migration(2, "SeedData")]
    public class SeedDataMigration : Migration
    {
        public override void Down()
        {
            Delete.FromTable("Users");
            Delete.FromTable("Users");
            Delete.FromTable("Users");
            Delete.FromTable("Users");
            Delete.FromTable("Users");
        }

        public override void Up()
        {
            Insert.IntoTable("Genders").Row(new {GenderDescription = "K" });
            Insert.IntoTable("Genders").Row(new { GenderDescription = "M" });
            Insert.IntoTable("Lecturers").Row(new { FirstName = "John", LastName = "Smith", Title = "Doktor"});
            Insert.IntoTable("Lecturers").Row(new { FirstName = "Jan", LastName = "Kowalski", Title = "Profesor" });
            Insert.IntoTable("Users").Row(new { Username = "John", PasswordHash = "9ed1515819dec61fd361d5fdabb57f41ecce1a5fe1fe263b98c0d6943b9b232e", 
                GenderId = 1, AccessType = 'U'}); //haslo pizza
            Insert.IntoTable("Users").Row(new { Username = "someUser", PasswordHash = "9ed1515819dec61fd361d5fdabb57f41ecce1a5fe1fe263b98c0d6943b9b232e", 
                GenderId = 1, AccessType = 'U'});
            
            
        }
    }
}
