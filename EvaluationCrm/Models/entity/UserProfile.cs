using System;
using System.Collections.Generic;

namespace EvaluationCrm.Models.entity;

public partial class UserProfile
{
    public uint Id { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Phone { get; set; }

    public string? Department { get; set; }

    public decimal? Salary { get; set; }

    public string? Status { get; set; }

    public string? OauthUserImageLink { get; set; }

    public byte[]? UserImage { get; set; }

    public string? Bio { get; set; }

    public string? Youtube { get; set; }

    public string? Twitter { get; set; }

    public string? Facebook { get; set; }

    public int? UserId { get; set; }

    public string? Country { get; set; }

    public string? Position { get; set; }

    public string? Address { get; set; }

    public virtual User? User { get; set; }
}
