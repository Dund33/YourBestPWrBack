using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YourBestPWrBack.Migrations
{
    public class AddGendersMigration : Migration
    {
        public override void Down()
        {
            Delete.Table("Genders");
        }

        public override void Up()
        {
            Create.Table("Genders")
                .WithColumn("Id").AsInt32().Identity().PrimaryKey()
                .WithColumn("GenderDescription").AsString(45);
        }
    }
}
