using EvaluationCrm.Models.entity;

namespace EvaluationCrm.service
{
    public class ExpenseService
    {
        private readonly HttpClient _httpClient;

        public ExpenseService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }


        public  Expense? GetExpenseById(Int16 expenseId)
        {
            return _httpClient.GetFromJsonAsync<Expense>("http://localhost:8080/api/expense/" + expenseId).Result;
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
    }
}