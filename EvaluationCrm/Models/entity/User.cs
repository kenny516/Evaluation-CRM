using System;
using System.Collections.Generic;

namespace EvaluationCrm.Models.entity;

public partial class User
{
    public int Id { get; set; }

    public string Email { get; set; } = null!;

    public string? Password { get; set; }

    public DateTime? HireDate { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public string Username { get; set; } = null!;

    public string? Status { get; set; }

    public string? Token { get; set; }

    public bool? IsPasswordSet { get; set; }

    public virtual ICollection<ContractSetting> ContractSettings { get; set; } = new List<ContractSetting>();

    public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();

    public virtual ICollection<EmailTemplate> EmailTemplates { get; set; } = new List<EmailTemplate>();

    public virtual ICollection<LeadSetting> LeadSettings { get; set; } = new List<LeadSetting>();

    public virtual ICollection<OauthUser> OauthUsers { get; set; } = new List<OauthUser>();

    public virtual ICollection<TicketSetting> TicketSettings { get; set; } = new List<TicketSetting>();

    public virtual ICollection<TriggerContract> TriggerContracts { get; set; } = new List<TriggerContract>();

    public virtual ICollection<TriggerLead> TriggerLeadEmployees { get; set; } = new List<TriggerLead>();

    public virtual ICollection<TriggerLead> TriggerLeadUsers { get; set; } = new List<TriggerLead>();

    public virtual ICollection<TriggerTicket> TriggerTicketEmployees { get; set; } = new List<TriggerTicket>();

    public virtual ICollection<TriggerTicket> TriggerTicketManagers { get; set; } = new List<TriggerTicket>();

    public virtual ICollection<UserProfile> UserProfiles { get; set; } = new List<UserProfile>();

    public virtual ICollection<Role> Roles { get; set; } = new List<Role>();
}
