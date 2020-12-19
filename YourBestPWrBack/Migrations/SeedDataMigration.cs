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
            Delete.FromTable("Opinions").AllRows();
            Delete.FromTable("LecturersCourses").AllRows();
            Delete.FromTable("Courses").AllRows();
            Delete.FromTable("Lecturers").AllRows();
            Delete.FromTable("Users").AllRows();
            Delete.FromTable("Genders").AllRows();
        }

        public override void Up()
        {
            Insert.IntoTable("Genders").Row(new {GenderDescription = "K" });
            Insert.IntoTable("Genders").Row(new { GenderDescription = "M" });
            Insert.IntoTable("Users").Row(new { Username = "John", PasswordHash = "9ed1515819dec61fd361d5fdabb57f41ecce1a5fe1fe263b98c0d6943b9b232e", 
                GenderId = 1, AccessType = AccessType.User}); //haslo pizza
            Insert.IntoTable("Users").Row(new { Username = "someUser", PasswordHash = "5e884898da28047151d0e56f8dc6292773603d0d6aabbdd62a11ef721d1542d8", 
                GenderId = 2, AccessType = AccessType.User}); //haslo password
            Insert.IntoTable("Lecturers").Row(new { FirstName = "John", LastName = "Smith", Title = "Doktor" });
            Insert.IntoTable("Lecturers").Row(new { FirstName = "Jan", LastName = "Kowalski", Title = "Profesor" });
            Insert.IntoTable("Courses").Row(new { CourseName = "Databases" });
            Insert.IntoTable("Opinions").Row(new { Rating = 3, Description = "good", Date = DateTime.Now, LecturerId = 1, UserId = 2, CourseId = 1 });
            
            
        }
    }
}
