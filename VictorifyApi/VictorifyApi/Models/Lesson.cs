namespace VictorifyApi.Models
{
    public class Lesson
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        //public Game Game { get; set; } // enum
        public bool Current { get; set; } // if lesson happend

        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }

        public int StudentId { get; set; } 
        public Student Student { get; set; }
    }

    public class UpdateLessonDto
    {
        public DateTime? Date { get; set; }
        public bool? Current { get; set; }
    }
}