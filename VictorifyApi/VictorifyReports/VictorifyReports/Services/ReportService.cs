using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VictorifyReports.Services
{
    public class ReportService
    {
        private readonly LessonService _lessonService;
        private readonly TeacherService _teacherService;
        private readonly StudentService _studentService;

        public ReportService(LessonService lessonService, TeacherService teacherService, StudentService studentService)
        {
            _lessonService = lessonService;
            _teacherService = teacherService;
            _studentService = studentService;
        }

        public async Task GenerateTxtReportAsync(string directoryPath)
        {
            // Upewniamy się, że katalog istnieje
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            // Generowanie nazwy pliku
            string timestamp = DateTime.Now.ToString("ddMMyyHHmm");
            string fileName = $"Report_{timestamp}.txt";
            string filePath = Path.Combine(directoryPath, fileName);

            var lessons = await _lessonService.GetLessonsAsync();
            var teachers = await _teacherService.GetTeachersAsync();
            var students = await _studentService.GetStudentsAsync();

            var sb = new StringBuilder();
            sb.AppendLine($"Victorify Report - Generated on {DateTime.Now}");
            sb.AppendLine("=".PadRight(50, '='));
            sb.AppendLine();

            // Lista nauczycieli
            sb.AppendLine("Teachers:");
            foreach (var teacher in teachers)
            {
                sb.AppendLine($"- ID: {teacher.Id}, Name: {teacher.Name} {teacher.Surname}, Hourly Rate: {teacher.HourlyRate:C}");
            }
            sb.AppendLine();

            // Lista uczniów
            sb.AppendLine("Students:");
            foreach (var student in students)
            {
                sb.AppendLine($"- ID: {student.Id}, Name: {student.Name} {student.Surname}, Email: {student.Email}");
            }
            sb.AppendLine();

            // Lista lekcji z nazwiskami nauczycieli i uczniów
            sb.AppendLine("Lessons:");
            foreach (var lesson in lessons)
            {
                var teacher = teachers.FirstOrDefault(t => t.Id == lesson.TeacherId);
                var student = students.FirstOrDefault(s => s.Id == lesson.StudentId);

                sb.AppendLine($"- ID: {lesson.Id}, Date: {lesson.Date}, Current: {lesson.Current}");
                sb.AppendLine($"  Teacher: {(teacher != null ? $"{teacher.Name} {teacher.Surname}" : "Unknown")}");
                sb.AppendLine($"  Student: {(student != null ? $"{student.Name} {student.Surname}" : "Unknown")}");
            }

            File.WriteAllText(filePath, sb.ToString());
            Console.WriteLine($"Report generated: {filePath}");
        }

    }
}
