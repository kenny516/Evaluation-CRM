namespace EvaluationCrm.service;

public class ImportService
{
    private readonly HttpClient _httpClient;

    public ImportService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    
    
}