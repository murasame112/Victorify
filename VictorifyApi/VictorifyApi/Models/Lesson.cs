using System.Text.Json.Serialization;

namespace VictorifyApi.Models
{
    public class Lesson
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        //public Game Game { get; set; } // enum
        public bool Current { get; set; } // if lesson happend

        public int TeacherId { get; set; }
        [JsonIgnore]
        public Teacher Teacher { get; set; }

        public int StudentId { get; set; }
        [JsonIgnore]
        public Student Student { get; set; }
    }

    public class UpdateLessonDto
    {
        public DateTime? Date { get; set; }
        public bool? Current { get; set; }
        public int? TeacherId { get; set; }
        public int? StudentId { get; set; }
    }

    public class CreateLessonDto
    {
        public DateTime Date { get; set; }
        public bool Current { get; set; }
        public int TeacherId { get; set; }
        public int StudentId { get; set; }
    }
}