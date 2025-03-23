using System.Dynamic;
using EvaluationCrm.Models.entity;
using EvaluationCrm.service;
using Microsoft.AspNetCore.Mvc;

namespace EvaluationCrm.Controllers;

public class EditExpenseViewModel
{
    public Int16? TicketId { get; set; }
    public Int16? LeadId { get; set; }
    public Expense Expense { get; set; }
}

public class ExpenseController : Controller
{
    private readonly ExpenseService _expenseService;
    private readonly TicketService _ticketService;
    private readonly LeadService _leadService;

    public ExpenseController(ExpenseService expenseService, TicketService ticketService, LeadService leadService)
    {
        _expenseService = expenseService;
        _ticketService = ticketService;
        _leadService = leadService;
    }

    [HttpGet("/getTicekt")]
    public List<Ticket>? GetTickets()
    {
        return _ticketService.GetTickets();
    }

    public IActionResult Index()
    {
        List<Expense>? expenses = _expenseService.GetExpenses();
        return View(expenses);
    }

    [HttpGet]
    public IActionResult Edit(Int16? ticketId, Int16? leadId, Int16 expenseId)
    {
        Expense? expense = _expenseService.GetExpenseById(expenseId);
        if (expense == null)
            return NotFound();
        var model = new EditExpenseViewModel
        {
            TicketId = ticketId,
            LeadId = leadId,
            Expense = expense
        };
        Console.WriteLine(model);
        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(EditExpenseViewModel model)
    {
        Expense expense = await _expenseService.UpdateExpense(model.Expense);
        if (model.TicketId != null)
        {
            return RedirectToAction("Index", "Ticket");
        }

        if (model.LeadId != null)
        {
            return RedirectToAction("Index", "Lead");
        }
        return RedirectToAction("Edit", "Expense");
    }
    
    // [HttpPost]
    // public IActionResult Delete(int id)
    // {
    //     var expense = _expenseService.GetExpenseById(id);
    //     if (expense == null)
    //         return NotFound();
    //
    //     _expenseService.DeleteExpense(id);
    //
    //     if (expense.TicketId.HasValue)
    //         return RedirectToAction(nameof(ByTicket), new { ticketId = expense.TicketId });
    //     else if (expense.LeadId.HasValue)
    //         return RedirectToAction(nameof(ByLead), new { leadId = expense.LeadId });
    //
    //     return RedirectToAction(nameof(Index));
    // }
}