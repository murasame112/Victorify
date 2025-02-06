using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using VictorifyReports.Models;

namespace VictorifyReports.Services
{
    public class LessonService
    {
        private readonly HttpClient _httpClient;

        public LessonService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Lesson>> GetLessonsAsync()
        {
            try
            {

                var response = await _httpClient.GetAsync("api/Lessons");
                response.EnsureSuccessStatusCode();

                var jsonResponse = await response.Content.ReadAsStringAsync();

                var lessons = JsonSerializer.Deserialize<List<Lesson>>(jsonResponse, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                return lessons;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching lessons: {ex.Message}");
                return new List<Lesson>();
            }
        }

    }
}
