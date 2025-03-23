using System.Net.Http;
using System.Text.Json;
using EvaluationCrm.Models.entity;

namespace EvaluationCrm.service;

public class UserService
{
    private readonly HttpClient _httpClient;

    public UserService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<User?> GetUserByEmail(string email)
    {
        try
        {
            var response = await _httpClient.GetAsync($"http://localhost:8080/api/user/login?email={email}");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<User>(content);
            }
            return null;
        }
        catch
        {
            return null;
        }
    }
}