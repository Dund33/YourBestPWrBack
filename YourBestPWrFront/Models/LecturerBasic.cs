using System.Text.Json.Serialization;

namespace YourBestPWrFront.Models
{
    public class LecturerBasic
    {
        public int Id { get; set; }
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public string Title { get; init; }
    }
}
