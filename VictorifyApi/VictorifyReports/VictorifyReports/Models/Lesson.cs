using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VictorifyReports.Models
{
    public class Lesson
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public bool Current { get; set; }
        public int TeacherId { get; set; }
        public int StudentId { get; set; }
    }
}

