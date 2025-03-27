using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EvaluationCrm.Models.entity;

public partial class Expense
{
    public uint ExpenseId { get; set; }

    [Required(ErrorMessage = "Le montant est requis.")]
    [Range(0.01, double.MaxValue, ErrorMessage = "Le montant doit être supérieur à 0.")]
    public decimal Amount { get; set; }

    public DateOnly DateExpense { get; set; }

    public string? Description { get; set; }

    public uint? BudgetId { get; set; }
    
    public virtual Budget Budget { get; set; } = null;
    public virtual Customer Customer { get; set; } = null!;

    public virtual ICollection<Lead> TriggerLeads { get; set; } = new List<Lead>();

    public virtual ICollection<Ticket> TriggerTickets { get; set; } = new List<Ticket>();
}
