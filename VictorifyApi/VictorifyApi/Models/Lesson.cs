namespace VictorifyApi.Models
{
    public class Lesson
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int TeacherId { get; set; }
        public int LessonId { get; set; }
        //public Game Game { get; set; } // enum
        bool Current { get; set; } // if lesson happend
    }
}
