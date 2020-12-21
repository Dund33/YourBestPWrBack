using FluentMigrator;

namespace YourBestPWrBack.Migrations
{
    [Migration(4, "AddTriggers")]
    public class AddTriggersMigration: Migration
    {
        public override void Up()
        {
            Execute.Sql(@"CREATE TRIGGER update_average
    AFTER INSERT ON Opinions FOR EACH ROW BEGIN
    DECLARE avg_rating float;
    SELECT AVG(Opinions.Rating) INTO avg_rating
    FROM Opinions
    WHERE LecturerId = NEW.LecturerId AND CourseId = NEW.CourseId
    GROUP BY CourseId, LecturerId;
    UPDATE LecturersCourses LC SET AverageRating = avg_rating
    WHERE NEW.LecturerId = LC.LecturerId
      AND NEW.CourseId= LC.CourseId;
end;");
            
            Execute.Sql(@"CREATE TRIGGER update_average_on_update
    AFTER UPDATE ON Opinions FOR EACH ROW BEGIN
    DECLARE avg_rating float;
    SELECT AVG(Opinions.Rating) INTO avg_rating
    FROM Opinions
    WHERE LecturerId = NEW.LecturerId AND CourseId = NEW.CourseId
    GROUP BY CourseId, LecturerId;
    UPDATE LecturersCourses LC SET AverageRating = avg_rating
    WHERE NEW.LecturerId = LC.LecturerId
      AND NEW.CourseId= LC.CourseId;
end;");
        }

        public override void Down()
        {
            Execute.Sql("DROP TRIGGER IF EXISTS update_average_on_update");
            Execute.Sql("DROP TRIGGER IF EXISTS update_average");
        }
    }
}