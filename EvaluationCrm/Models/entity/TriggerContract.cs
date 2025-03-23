using System;
using System.Collections.Generic;

namespace EvaluationCrm.Models.entity;

public partial class TriggerContract
{
    public uint ContractId { get; set; }

    public string? Subject { get; set; }

    public string? Status { get; set; }

    public string? Description { get; set; }

    public DateOnly? StartDate { get; set; }

    public DateOnly? EndDate { get; set; }

    public decimal? Amount { get; set; }

    public bool? GoogleDrive { get; set; }

    public string? GoogleDriveFolderId { get; set; }

    public uint? LeadId { get; set; }

    public int? UserId { get; set; }

    public uint? CustomerId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual ICollection<File> Files { get; set; } = new List<File>();

    public virtual ICollection<GoogleDriveFile> GoogleDriveFiles { get; set; } = new List<GoogleDriveFile>();

    public virtual Lead? Lead { get; set; }

    public virtual User? User { get; set; }
}
