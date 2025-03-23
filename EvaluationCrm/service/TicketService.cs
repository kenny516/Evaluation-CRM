using EvaluationCrm.Models.entity;

namespace EvaluationCrm.service;

public class TicketService
{
    private readonly HttpClient _httpClient;
    
    public TicketService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    
    public List<Ticket>? GetTickets()
    {
        var content =  _httpClient.GetFromJsonAsync<List<Ticket>>("http://localhost:8080/api/expense/ticket").Result;
        return content;
    }

    public void DeleteTicket(Int16 ticketId)
    {
        _httpClient.DeleteAsync($"http://localhost:8080/api/expense/delete-ticket?ticketId={ticketId}");
    }
}