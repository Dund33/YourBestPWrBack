﻿using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YourBestPWrBack.Migrations
{
    [Migration(1, "Init")]
    public class InitMigration : Migration
    {
        public override void Down()
        {
            Delete.Table("Users");
            Delete.Table("Genders");
            Delete.Table("Opinions");
            Delete.Table("Courses");
            Delete.Table("Lecturers");
            Delete.Table("LecturersCourses");
        }

        public override void Up()
        {

            Create.Table("Genders")
                .WithColumn("Id").AsInt32().Identity().PrimaryKey()
                .WithColumn("GenderDescription").AsString(45);

            Create.Table("Opinions")
                .WithColumn("Id").AsInt32().Identity().PrimaryKey()
                .WithColumn("Rating").AsInt32()
                .WithColumn("Description").AsString(1024).Nullable()
                .WithColumn("Date").AsDateTime()
                .WithColumn("LecturerId").AsInt32()
                .WithColumn("UserId").AsInt32()
                .WithColumn("CourseId").AsInt32();

            Create.Table("Courses")
                .WithColumn("Id").AsInt32().Identity().PrimaryKey()
                .WithColumn("CourseName").AsString(64);

            Create.Table("Lecturers")
                 .WithColumn("Id").AsInt32().Identity().PrimaryKey()
                 .WithColumn("FirstName").AsString(64)
                 .WithColumn("LastName").AsString(64)
                 .WithColumn("Title").AsString(64);

            Create.Table("LecturersCourses")
                .WithColumn("LecturerId").AsInt32().PrimaryKey()
                .WithColumn("CourseId").AsInt32().PrimaryKey();

            Create.Table("Users")
                .WithColumn("Id").AsInt32().Identity().PrimaryKey()
                .WithColumn("Username").AsString(32)
                .WithColumn("PasswordHash").AsFixedLengthString(64)
                .WithColumn("GenderId").AsInt32().Nullable().ForeignKey("Genders", "Id");
            Execute.Sql("ALTER TABLE Users ADD AccessType ENUM('N','U','A') NOT NULL;");

            Create.ForeignKey("fkLecturerId")
                .FromTable("Opinions").ForeignColumn("LecturerId")
                .ToTable("Lecturers").PrimaryColumn("Id");

            Create.ForeignKey("fkUserId")
                .FromTable("Opinions").ForeignColumn("UserId")
                .ToTable("Users").PrimaryColumn("Id");

            Create.ForeignKey("fkCourseId")
                .FromTable("Opinions").ForeignColumn("CourseId")
                .ToTable("Courses").PrimaryColumn("Id");
        }
    }
}
