using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YourBestPWrBack.Migrations
{
    public class AddLecturersMigration : Migration
    {
        public override void Down()
        {
            Delete.Column("Lecturers");
        }

        public override void Up()
        {
            Create.Table("Lecturers")
                 .WithColumn("Id").AsInt32().Identity().PrimaryKey()
                 .WithColumn("FirstName").AsString(64)
                 .WithColumn("LastName").AsString(64)
                 .WithColumn("Title").AsString(64);
        }
    }
}
