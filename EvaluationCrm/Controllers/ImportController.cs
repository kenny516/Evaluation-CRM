using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace EvaluationCrm.Controllers;

public class ImportController : Controller
{
    private readonly HttpClient _httpClient;
    private readonly IWebHostEnvironment _environment;

    public ImportController(HttpClient httpClient, IWebHostEnvironment environment)
    {
        _httpClient = httpClient;
        _environment = environment;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> UploadFile(IFormFile file)
    {
        if (file == null || file.Length == 0)
        {
            return BadRequest("Aucun fichier n'a été sélectionné");
        }

        if (!file.FileName.EndsWith(".json"))
        {
            return BadRequest("Le fichier doit être au format JSON");
        }

        try
        {
            using var reader = new StreamReader(file.OpenReadStream());
            var jsonContent = await reader.ReadToEndAsync();
            
            try
            {
                JsonDocument.Parse(jsonContent);
            }
            catch (JsonException)
            {
                return BadRequest("Le fichier n'est pas un JSON valide");
            }

            
            var content = new StringContent(jsonContent, System.Text.Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("http://localhost:8080/api/import", content);

            if (response.IsSuccessStatusCode)
            {
                TempData["Success"] = "Le fichier a été importé avec succès";
                return RedirectToAction("Index");
            }
            else
            {
                return BadRequest($"Erreur lors de l'envoi à l'API: {response.StatusCode}");
            }
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Une erreur est survenue: {ex.Message}");
        }
    }
}