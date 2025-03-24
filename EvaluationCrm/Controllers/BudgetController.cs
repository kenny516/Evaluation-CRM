using EvaluationCrm.Models.entity;
using EvaluationCrm.service;
using Microsoft.AspNetCore.Mvc;

namespace EvaluationCrm.Controllers;

public class BudgetController : Controller
{
    private readonly BudgetService _budgetService;

    public BudgetController(BudgetService budgetService)
    {
        _budgetService = budgetService;
    }

    public IActionResult Index()
    {
        List<Budget>? budgets = _budgetService.GetBudgets();
        return View(budgets);
    }
}