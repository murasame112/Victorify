using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using VictorifyReports.Models;

namespace VictorifyReports.Services
{
    public class TeacherService
    {
        private readonly HttpClient _httpClient;

        public TeacherService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Teacher>> GetTeachersAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync("api/Teachers");
                response.EnsureSuccessStatusCode();

                var jsonResponse = await response.Content.ReadAsStringAsync();

                var teachers = JsonSerializer.Deserialize<List<Teacher>>(jsonResponse, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                return teachers;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching teachers: {ex.Message}");
                return new List<Teacher>();
            }
        }
    }
}
