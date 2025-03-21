using System;
using System.Collections.Generic;

namespace EvaluationCrm.Models.entity;

public partial class Employee
{
    public int Id { get; set; }

    public string Username { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string? Provider { get; set; }
}
