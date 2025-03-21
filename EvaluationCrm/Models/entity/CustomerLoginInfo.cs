using System;
using System.Collections.Generic;

namespace EvaluationCrm.Models.entity;

public partial class CustomerLoginInfo
{
    public int Id { get; set; }

    public string? Password { get; set; }

    public string? Username { get; set; }

    public string? Token { get; set; }

    public bool? PasswordSet { get; set; }

    public virtual ICollection<ContractSetting> ContractSettings { get; set; } = new List<ContractSetting>();

    public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();

    public virtual ICollection<LeadSetting> LeadSettings { get; set; } = new List<LeadSetting>();

    public virtual ICollection<TicketSetting> TicketSettings { get; set; } = new List<TicketSetting>();
}
