using System;
using System.Collections.Generic;

namespace EvaluationCrm.Models.entity;

public partial class OauthUser
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public string AccessToken { get; set; } = null!;

    public DateTime AccessTokenIssuedAt { get; set; }

    public DateTime AccessTokenExpiration { get; set; }

    public string RefreshToken { get; set; } = null!;

    public DateTime RefreshTokenIssuedAt { get; set; }

    public DateTime? RefreshTokenExpiration { get; set; }

    public string? GrantedScopes { get; set; }

    public string? Email { get; set; }

    public virtual User? User { get; set; }
}
