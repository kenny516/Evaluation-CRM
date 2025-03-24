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

    public async Task<User?> Login(string email, string password)
    {
        var formData = new Dictionary<string, string>
        {
            { "email", email },
            { "password", password }
        };
        
        var content = new FormUrlEncodedContent(formData);

        // Envoyer la requête POST
        var response = await _httpClient.PostAsync("http://localhost:8080/api/user/login", content);

        // Vérifier si la réponse est réussie
        if (response.IsSuccessStatusCode)
        {
            var res = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<User>(res);
        }
        else
        {
            return null;
        }
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