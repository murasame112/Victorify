namespace VictorifyApi.Models
{
    public class Lesson
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        //public Game Game { get; set; } // enum
        bool Current { get; set; } // if lesson happend
        public ICollection<Student> Students { get; set; }
        public ICollection<Teacher> Teachers { get; set; }
    }
}
