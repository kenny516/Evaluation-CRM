using System.Text.Json;
using EvaluationCrm.Models.entity;

namespace EvaluationCrm.service;

public class CustomerService
{
    private readonly HttpClient _httpClient;
    private readonly string _baseUrl = "http://localhost:8080/api";

    public CustomerService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
}