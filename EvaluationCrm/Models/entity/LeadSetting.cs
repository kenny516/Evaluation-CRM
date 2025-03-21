using System;
using System.Collections.Generic;

namespace EvaluationCrm.Models.entity;

public partial class LeadSetting
{
    public uint Id { get; set; }

    public bool? Status { get; set; }

    public bool? Meeting { get; set; }

    public bool? Phone { get; set; }

    public bool? Name { get; set; }

    public int? UserId { get; set; }

    public uint? StatusEmailTemplate { get; set; }

    public uint? PhoneEmailTemplate { get; set; }

    public uint? MeetingEmailTemplate { get; set; }

    public uint? NameEmailTemplate { get; set; }

    public int? CustomerId { get; set; }

    public virtual CustomerLoginInfo? Customer { get; set; }

    public virtual EmailTemplate? MeetingEmailTemplateNavigation { get; set; }

    public virtual EmailTemplate? NameEmailTemplateNavigation { get; set; }

    public virtual EmailTemplate? PhoneEmailTemplateNavigation { get; set; }

    public virtual EmailTemplate? StatusEmailTemplateNavigation { get; set; }

    public virtual User? User { get; set; }
}
