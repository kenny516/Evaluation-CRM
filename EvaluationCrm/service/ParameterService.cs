using EvaluationCrm.Models.entity;

namespace EvaluationCrm.service;

public class ParameterService
{
    private readonly HttpClient _httpClient;

    public ParameterService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public Parameter? GetParameterThresholdAlert()
    {
        Parameter? parameter = _httpClient.GetFromJsonAsync<Parameter>("http://localhost:8080/api/management/threshold").Result;
        return parameter;
    }

    public Parameter? UpdateParameterThresholdAlert(Double value)
    {
        HttpResponseMessage response = _httpClient.PutAsync($"http://localhost:8080/api/management/threshold?value={value}", null).Result;
        Parameter? parameter = response.Content.ReadFromJsonAsync<Parameter>().Result;
        return parameter;
    }
    
    
    
}