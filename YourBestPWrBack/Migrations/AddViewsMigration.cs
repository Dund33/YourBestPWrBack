using FluentMigrator;
using MySqlX.XDevAPI.Relational;

namespace YourBestPWrBack.Migrations
{
    [Migration(3, "AddViews")]
    public class AddViewsMigration: Migration
    {
        public override void Up()
        {
            Execute.Sql(@"create definer = luke@`%` view LecturerAverageWithSubject as
select `LC`.`AverageRating`                             AS `AverageRating`,
       `CSS`.`CourseName`                               AS `CourseName`,
       `YourBestPWr_migrations`.`Lecturers`.`FirstName` AS `FirstName`,
       `YourBestPWr_migrations`.`Lecturers`.`LastName`  AS `LastName`,
       `YourBestPWr_migrations`.`Lecturers`.`Title`     AS `Title`
from ((`YourBestPWr_migrations`.`Lecturers` join `YourBestPWr_migrations`.`LecturersCourses` `LC` on ((`YourBestPWr_migrations`.`Lecturers`.`Id` = `LC`.`LecturerId`)))
         join `YourBestPWr_migrations`.`Courses` `CSS` on ((`LC`.`CourseId` = `CSS`.`Id`)));");
        }

        public override void Down()
        {
            Execute.Sql("DROP VIEW LecturerAverageWithSubject");
        }
    }
}