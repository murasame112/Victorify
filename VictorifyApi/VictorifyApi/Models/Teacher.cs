namespace VictorifyApi.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Nickname { get; set; }
        public string Email { get; set; }
        //public Game Games { get; set; } // enum
        //public int Rank { get; set; } // enum?
        public decimal HourlyRate { get; set; }
        public ICollection<Lesson> Lessons { get; set; }
    }

    public class UpdateTeacherDto
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Nickname { get; set; }
        public string? Email { get; set; }
        public decimal? HourlyRate { get; set; }
    }

    public class CreateTeacherDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Nickname { get; set; }
        public string Email { get; set; }
        public decimal HourlyRate { get; set; }
    }
}
