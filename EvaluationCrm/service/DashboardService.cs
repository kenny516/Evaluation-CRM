using EvaluationCrm.Models.entity;

namespace EvaluationCrm.service;

public class DashboardService
{
    private readonly HttpClient _httpClient;

    public DashboardService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public Dashboard? getDashboard()
    {
        var dashboard = _httpClient.GetFromJsonAsync<Dashboard>("http://localhost:8080/api/dashboard").Result;
        return dashboard;
    }
    
}