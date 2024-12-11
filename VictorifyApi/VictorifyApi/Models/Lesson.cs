namespace VictorifyApi.Models
{
    public class Lesson
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        //public Game Game { get; set; } // enum
        public bool Current { get; set; } // if lesson happend
        public ICollection<Student> Students { get; set; }
        public ICollection<Teacher> Teachers { get; set; }
    }

    public class UpdateLessonDto
    {
        public DateTime? Date { get; set; }
        public bool? Current { get; set; }
    }
}
