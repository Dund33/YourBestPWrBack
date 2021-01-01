using FluentMigrator;
using MySqlX.XDevAPI.Relational;

namespace YourBestPWrBack.Migrations
{
    [Migration(3, "AddViews")]
    public class AddViewsMigration: Migration
    {
        private const string _dbName = "YourBestPWr";
        public override void Up()
        {
            Execute.Sql($@"create definer = luke@`%` view LecturerAverageWithSubject as
select `LC`.`AverageRating`                             AS `AverageRating`,
       `CSS`.`CourseName`                               AS `CourseName`,
       `{_dbName}`.`Lecturers`.`FirstName` AS `FirstName`,
       `{_dbName}`.`Lecturers`.`LastName`  AS `LastName`,
       `{_dbName}`.`Lecturers`.`Title`     AS `Title`
from ((`{_dbName}`.`Lecturers` join `{_dbName}`.`LecturersCourses` `LC` on ((`{_dbName}`.`Lecturers`.`Id` = `LC`.`LecturerId`)))
         join `{_dbName}`.`Courses` `CSS` on ((`LC`.`CourseId` = `CSS`.`Id`)));");
        }

        public override void Down()
        {
            Execute.Sql("DROP VIEW LecturerAverageWithSubject");
        }
    }
}