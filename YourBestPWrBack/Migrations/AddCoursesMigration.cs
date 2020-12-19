
using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YourBestPWrBack.Migrations
{
    public class AddCoursesMigration : Migration
    {
        public override void Down()
        {
            Delete.Table("Courses");
        }
        public override void Up()
        {
            Create.Table("Courses")
                .WithColumn("Id").AsInt32().Identity().PrimaryKey()
                .WithColumn("CourseName").AsString(64);
        }
    }
}
