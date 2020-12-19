using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YourBestPWrBack.Migrations
{
    public class AddUsersMigration : Migration
    {
        public override void Down()
        {
            Delete.Table("Users");
        }

        public override void Up()
        {
            Create.Table("Users")
                .WithColumn("Id").AsInt32().Identity().PrimaryKey()
                .WithColumn("Username").AsString(32)
                .WithColumn("PasswordHash").AsFixedLengthString(64)
                .WithColumn("GenderId").AsInt32().ForeignKey("Genders", "Id");
            Execute.Sql("ALTER TABLE Users ADD AccessType ENUM('N','U','A') NOT NULL;");
        }
    }
}
