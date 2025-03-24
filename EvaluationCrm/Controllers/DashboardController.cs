using EvaluationCrm.Models.entity;
using EvaluationCrm.service;
using Microsoft.AspNetCore.Mvc;

namespace EvaluationCrm.Controllers;

public class DashboardViewModel
{
    public IDictionary<string, double> TicketExpensesByCustomer { get; set; }
    public IDictionary<string, double> LeadExpensesByCustomer { get; set; }
    public IDictionary<string, double> BudgetByCustomer { get; set; }
    public double TotalTicketExpenses { get; set; }
    public double TotalLeadExpenses { get; set; }
    public double TotalBudget { get; set; }
}

public class DashboardController : Controller
{
    private readonly TicketService _ticketService;
    private readonly LeadService _leadService;
    private readonly ExpenseService _expenseService;
    private readonly BudgetService _budgetService;

    public DashboardController(
        TicketService ticketService,
        LeadService leadService,
        ExpenseService expenseService,
        BudgetService budgetService)
    {
        _ticketService = ticketService;
        _leadService = leadService;
        _expenseService = expenseService;
        _budgetService = budgetService;
    }

    public IActionResult Index()
    {
        var viewModel = new DashboardViewModel
        {
            TicketExpensesByCustomer = _expenseService.GetTicketExpensesByCustomer(),
            LeadExpensesByCustomer = _expenseService.GetLeadExpensesByCustomer(),
            BudgetByCustomer = _budgetService.GetBudgetByCustomer(),
            TotalTicketExpenses = _expenseService.GetTotalTicketExpenses(),
            TotalLeadExpenses = _expenseService.GetTotalLeadExpenses(),
            TotalBudget = _budgetService.GetTotalBudget()
        };

        return View(viewModel);
    }
}