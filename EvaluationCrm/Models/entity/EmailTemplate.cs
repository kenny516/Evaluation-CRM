using System;
using System.Collections.Generic;

namespace EvaluationCrm.Models.entity;

public partial class EmailTemplate
{
    public uint TemplateId { get; set; }

    public string? Name { get; set; }

    public string? Content { get; set; }

    public int? UserId { get; set; }

    public string? JsonDesign { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual ICollection<ContractSetting> ContractSettingAmountEmailTemplateNavigations { get; set; } = new List<ContractSetting>();

    public virtual ICollection<ContractSetting> ContractSettingDescriptionEmailTemplateNavigations { get; set; } = new List<ContractSetting>();

    public virtual ICollection<ContractSetting> ContractSettingEndEmailTemplateNavigations { get; set; } = new List<ContractSetting>();

    public virtual ICollection<ContractSetting> ContractSettingStartEmailTemplateNavigations { get; set; } = new List<ContractSetting>();

    public virtual ICollection<ContractSetting> ContractSettingStatusEmailTemplateNavigations { get; set; } = new List<ContractSetting>();

    public virtual ICollection<ContractSetting> ContractSettingSubjectEmailTemplateNavigations { get; set; } = new List<ContractSetting>();

    public virtual ICollection<LeadSetting> LeadSettingMeetingEmailTemplateNavigations { get; set; } = new List<LeadSetting>();

    public virtual ICollection<LeadSetting> LeadSettingNameEmailTemplateNavigations { get; set; } = new List<LeadSetting>();

    public virtual ICollection<LeadSetting> LeadSettingPhoneEmailTemplateNavigations { get; set; } = new List<LeadSetting>();

    public virtual ICollection<LeadSetting> LeadSettingStatusEmailTemplateNavigations { get; set; } = new List<LeadSetting>();

    public virtual ICollection<TicketSetting> TicketSettingDescriptionEmailTemplateNavigations { get; set; } = new List<TicketSetting>();

    public virtual ICollection<TicketSetting> TicketSettingPriorityEmailTemplateNavigations { get; set; } = new List<TicketSetting>();

    public virtual ICollection<TicketSetting> TicketSettingStatusEmailTemplateNavigations { get; set; } = new List<TicketSetting>();

    public virtual ICollection<TicketSetting> TicketSettingSubjectEmailTemplateNavigations { get; set; } = new List<TicketSetting>();

    public virtual User? User { get; set; }
}
