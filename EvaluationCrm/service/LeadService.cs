using EvaluationCrm.Models.entity;

namespace EvaluationCrm.service;

public class LeadService
{
    private readonly HttpClient _httpClient;
    
    public LeadService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    
    public List<Lead>? GetLeads()
    {
        var content =  _httpClient.GetFromJsonAsync<List<Lead>>("http://localhost:8080/api/lead").Result;
        return content;
    }

    public void DeleteLead(Int16 leadId)
    {
        _httpClient.DeleteAsync($"http://localhost:8080/api/lead?leadId={leadId}");
    }
    
    
    // Dashboard Data
    
    public Decimal TotalLead(List<Lead> leads)
    {
        Decimal total = 0;
        foreach (var lead in leads)
        {
            total += lead.Expense?.Amount ?? 0 ;
        }
        return total;
    }
}