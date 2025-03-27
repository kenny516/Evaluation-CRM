using EvaluationCrm.Models.entity;
using EvaluationCrm.service;
using Microsoft.AspNetCore.Mvc;

namespace EvaluationCrm.Controllers;

public class DashboardController : Controller
{
    // private readonly TicketService _ticketService;
    // private readonly LeadService _leadService;
    // private readonly ExpenseService _expenseService;
    // private readonly BudgetService _budgetService;
    private readonly DashboardService _dashboardService;

    public DashboardController(DashboardService dashboardService)
    {
        _dashboardService = dashboardService;
    }

    public IActionResult Index()
    {
        var viewModel = _dashboardService.getDashboard();
        return View(viewModel);
    }
}