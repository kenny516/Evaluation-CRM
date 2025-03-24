using System.Text.Json;
using EvaluationCrm.Models.entity;

namespace EvaluationCrm.service;

public class ExpenseService
{
    private readonly HttpClient _httpClient;
    private readonly string _baseUrl = "http://localhost:8080/api"; // URL de l'API Spring

    public ExpenseService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public Expense? GetExpenseById(Int16 expenseId)
    {
        return _httpClient.GetFromJsonAsync<Expense>("http://localhost:8080/api/expense/" + expenseId).Result;
    }

    public List<Expense>? GetExpenses()
    {
        return _httpClient.GetFromJsonAsync<List<Expense>>("http://localhost:8080/api/expense").Result;
    }
 
    public async Task<Expense> UpdateExpense(Expense expense)
    {
        try
        {
            var jsonContent = JsonContent.Create(expense);
            var response =
                await _httpClient.PutAsync("http://localhost:8080/api/expense/update-expense", jsonContent);
            if (response.IsSuccessStatusCode)
            {
                var updatedExpense = await response.Content.ReadFromJsonAsync<Expense>();
                return updatedExpense;
            }
            throw new HttpRequestException($"Erreur HTTP : {response.StatusCode}");
        }
        catch (HttpRequestException ex)
        {
            throw new Exception("Erreur lors de la communication avec l'API Java.", ex);
        }
    }
// Dashboard
    public IDictionary<string, double> GetTicketExpensesByCustomer()
    {
        try
        {
            var response = _httpClient.GetAsync($"{_baseUrl}/expenses/tickets/by-customer").Result;
            if (response.IsSuccessStatusCode)
            {
                var content = response.Content.ReadAsStringAsync().Result;
                return JsonSerializer.Deserialize<Dictionary<string, double>>(content) 
                       ?? new Dictionary<string, double>();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error fetching ticket expenses: {ex.Message}");
        }
        return new Dictionary<string, double>();
    }

    public IDictionary<string, double> GetLeadExpensesByCustomer()
    {
        try
        {
            var response = _httpClient.GetAsync($"{_baseUrl}/expenses/leads/by-customer").Result;
            if (response.IsSuccessStatusCode)
            {
                var content = response.Content.ReadAsStringAsync().Result;
                return JsonSerializer.Deserialize<Dictionary<string, double>>(content) 
                       ?? new Dictionary<string, double>();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error fetching lead expenses: {ex.Message}");
        }
        return new Dictionary<string, double>();
    }

    public double GetTotalTicketExpenses()
    {
        try
        {
            var response = _httpClient.GetAsync($"{_baseUrl}/expenses/tickets/total").Result;
            if (response.IsSuccessStatusCode)
            {
                var content = response.Content.ReadAsStringAsync().Result;
                return JsonSerializer.Deserialize<double>(content);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error fetching total ticket expenses: {ex.Message}");
        }
        return 0;
    }

    public double GetTotalLeadExpenses()
    {
        try
        {
            var response = _httpClient.GetAsync($"{_baseUrl}/expenses/leads/total").Result;
            if (response.IsSuccessStatusCode)
            {
                var content = response.Content.ReadAsStringAsync().Result;
                return JsonSerializer.Deserialize<double>(content);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error fetching total lead expenses: {ex.Message}");
        }
        return 0;
    }
}