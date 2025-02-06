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
            client.BaseAddress = new Uri("http://victorifyapi:8080/");
        });

        services.AddHttpClient<TeacherService>(client =>
        {
            client.BaseAddress = new Uri("http://victorifyapi:8080/");
        });

        services.AddHttpClient<StudentService>(client =>
        {
            client.BaseAddress = new Uri("http://victorifyapi:8080/");
        });

        // Rejestracja ReportService
        services.AddSingleton<ReportService>();

        // Zbudowanie ServiceProvider
        var serviceProvider = services.BuildServiceProvider();

        // Pobranie serwisu ReportService
        var reportService = serviceProvider.GetRequiredService<ReportService>();

        // Generowanie raportu w formacie .txt
        string reportDirectory = "/app/Reports"; ; // Katalog w kontenerze
        Directory.CreateDirectory(reportDirectory); // Upewnij się, że katalog istnieje
        string reportPath = Path.Combine(reportDirectory, $"Report_{DateTime.Now:ddMMyyHHmm}.txt");

        Console.WriteLine("Starting report generation...");
        try
        {
            await reportService.GenerateTxtReportAsync(reportPath);
            Console.WriteLine($"Report generated successfully at: {reportPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error occurred during report generation: {ex.Message}");
        }
    }
}
