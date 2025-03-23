using System;
using System.Collections.Generic;

namespace EvaluationCrm.Models.entity;

public partial class Budget
{
    public uint BudgetId { get; set; }

    public string Title { get; set; } = null!;

    public decimal Amount { get; set; }

    public DateOnly StartDate { get; set; }

    public DateOnly EndDate { get; set; }

    public uint CustomerId { get; set; }

    public virtual Customer Customer { get; set; } = null!;

    public virtual ICollection<Expense> Expenses { get; set; } = new List<Expense>();
}
