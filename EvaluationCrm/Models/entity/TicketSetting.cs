using System;
using System.Collections.Generic;

namespace EvaluationCrm.Models.entity;

public partial class TicketSetting
{
    public uint Id { get; set; }

    public bool? Priority { get; set; }

    public bool? Subject { get; set; }

    public bool? Description { get; set; }

    public bool? Status { get; set; }

    public int? UserId { get; set; }

    public uint? StatusEmailTemplate { get; set; }

    public uint? SubjectEmailTemplate { get; set; }

    public uint? PriorityEmailTemplate { get; set; }

    public uint? DescriptionEmailTemplate { get; set; }

    public int? CustomerId { get; set; }

    public virtual CustomerLoginInfo? Customer { get; set; }

    public virtual EmailTemplate? DescriptionEmailTemplateNavigation { get; set; }

    public virtual EmailTemplate? PriorityEmailTemplateNavigation { get; set; }

    public virtual EmailTemplate? StatusEmailTemplateNavigation { get; set; }

    public virtual EmailTemplate? SubjectEmailTemplateNavigation { get; set; }

    public virtual User? User { get; set; }
}
