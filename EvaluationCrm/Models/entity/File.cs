using System;
using System.Collections.Generic;

namespace EvaluationCrm.Models.entity;

public partial class File
{
    public int FileId { get; set; }

    public string? FileName { get; set; }

    public byte[]? FileData { get; set; }

    public string? FileType { get; set; }

    public uint? LeadId { get; set; }

    public uint? ContractId { get; set; }

    public virtual TriggerContract? Contract { get; set; }

    public virtual Lead? Lead { get; set; }
}
