using Microsoft.Extensions.DependencyInjection;
using System;
using VictorifyReports.Services;

class Program
{
    static async Task Main(string[] args)
    {
        // Konfiguracja Dependency Injection
        var services = new ServiceCollection();

        // Dodanie HttpClient do ServiceCollection
        services.AddHttpClient<LessonService>(client =>
        {
            client.BaseAddress = new Uri("https://localhost:8081/");
        });

        services.AddHttpClient<TeacherService>(client =>
        {
            client.BaseAddress = new Uri("https://localhost:8081/");
        });

        services.AddHttpClient<StudentService>(client =>
        {
            client.BaseAddress = new Uri("https://localhost:8081/");
        });

        // Rejestracja ReportService
        services.AddSingleton<ReportService>();

        // Zbudowanie ServiceProvider
        var serviceProvider = services.BuildServiceProvider();

        // Pobranie serwisów
        var lessonService = serviceProvider.GetRequiredService<LessonService>();
        var teacherService = serviceProvider.GetRequiredService<TeacherService>();
        var studentService = serviceProvider.GetRequiredService<StudentService>();
        var reportService = serviceProvider.GetRequiredService<ReportService>();

        // Generowanie raportu w formacie .txt
        string reportPath = Path.Combine(Directory.GetParent(AppContext.BaseDirectory).Parent.Parent.Parent.FullName, "Reports");

        await reportService.GenerateTxtReportAsync(reportPath);
        Console.WriteLine($"Report generated: {reportPath}");
    }
}
