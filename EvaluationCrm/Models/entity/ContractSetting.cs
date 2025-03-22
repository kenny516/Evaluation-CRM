using System;
using System.Collections.Generic;

namespace EvaluationCrm.Models.entity;

public partial class ContractSetting
{
    public uint Id { get; set; }

    public bool? Amount { get; set; }

    public bool? Subject { get; set; }

    public bool? Description { get; set; }

    public bool? EndDate { get; set; }

    public bool? StartDate { get; set; }

    public bool? Status { get; set; }

    public int? UserId { get; set; }

    public uint? StatusEmailTemplate { get; set; }

    public uint? AmountEmailTemplate { get; set; }

    public uint? SubjectEmailTemplate { get; set; }

    public uint? DescriptionEmailTemplate { get; set; }

    public uint? StartEmailTemplate { get; set; }

    public uint? EndEmailTemplate { get; set; }

    public int? CustomerId { get; set; }

    public virtual EmailTemplate? AmountEmailTemplateNavigation { get; set; }

    public virtual CustomerLoginInfo? Customer { get; set; }

    public virtual EmailTemplate? DescriptionEmailTemplateNavigation { get; set; }

    public virtual EmailTemplate? EndEmailTemplateNavigation { get; set; }

    public virtual EmailTemplate? StartEmailTemplateNavigation { get; set; }

    public virtual EmailTemplate? StatusEmailTemplateNavigation { get; set; }

    public virtual EmailTemplate? SubjectEmailTemplateNavigation { get; set; }

    public virtual User? User { get; set; }
}
