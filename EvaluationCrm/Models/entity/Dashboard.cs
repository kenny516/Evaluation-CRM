namespace EvaluationCrm.Models.entity;

public class Dashboard
{
    public IDictionary<string, double> TicketExpensesByCustomer { get; set; }
    public IDictionary<string, double> LeadExpensesByCustomer { get; set; }
    public IDictionary<string, double> BudgetByCustomer { get; set; }
    public double TotalTicketExpenses { get; set; }
    public double TotalLeadExpenses { get; set; }
    public double TotalBudget { get; set; }
}