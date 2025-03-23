using System.Text.Json;
using EvaluationCrm.Models.entity;

namespace EvaluationCrm.service;

public class BudgetService
{
    private readonly HttpClient _httpClient;
    private readonly string _baseUrl = "http://localhost:8080/api";

    public BudgetService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public List<Budget>? GetBudgets()
    {
        var content =  _httpClient.GetFromJsonAsync<List<Budget>>("http://localhost:8080/api/management/budget").Result;
        return content;
    }

    public List<Budget>? GetBudgetsByCustomer(Int16 customer)
    {
        var content =  _httpClient.GetFromJsonAsync<List<Budget>>($"http://localhost:8080/api/management/budget/customer/{customer}").Result;
        return content;
    }

    public IDictionary<string, double> GetBudgetByCustomer()
    {
        try
        {
            var response = _httpClient.GetAsync($"{_baseUrl}/budgets/by-customer").Result;
            if (response.IsSuccessStatusCode)
            {
                var content = response.Content.ReadAsStringAsync().Result;
                return JsonSerializer.Deserialize<Dictionary<string, double>>(content) 
                       ?? new Dictionary<string, double>();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error fetching budgets: {ex.Message}");
        }
        return new Dictionary<string, double>();
    }

    public double GetTotalBudget()
    {
        try
        {
            var response = _httpClient.GetAsync($"{_baseUrl}/budgets/total").Result;
            if (response.IsSuccessStatusCode)
            {
                var content = response.Content.ReadAsStringAsync().Result;
                return JsonSerializer.Deserialize<double>(content);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error fetching total budget: {ex.Message}");
        }
        return 0;
    }
}