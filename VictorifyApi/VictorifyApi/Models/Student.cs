namespace VictorifyApi.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Nickname { get; set; }
        public string Email { get; set; }
        //public Game Game { get; set; } // enum
        //public int Rank { get; set; } // enum?
        public ICollection<Lesson> Lessons { get; set; }
    }

    public class UpdateStudentDto
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Nickname { get; set; }
        public string? Email { get; set; }
    }
}
