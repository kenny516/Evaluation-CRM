using System;
using System.Collections.Generic;

namespace EvaluationCrm.Models.entity;

public partial class Ticket
{
    public uint TicketId { get; set; }

    public string? Subject { get; set; }

    public string? Description { get; set; }

    public string? Status { get; set; }

    public string? Priority { get; set; }

    public uint CustomerId { get; set; }

    public int? ManagerId { get; set; }

    public int? EmployeeId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public uint? ExpenseId { get; set; }

    public virtual Customer Customer { get; set; } = null!;

    public virtual User? Employee { get; set; }

    public virtual Expense? Expense { get; set; }

    public virtual User? Manager { get; set; }
}
