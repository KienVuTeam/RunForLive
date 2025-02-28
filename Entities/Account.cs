using System;
using System.Collections.Generic;

namespace RunForLive.Entities;

public partial class Account
{
    public int Id { get; set; }

    public string? Mail { get; set; }

    public string? PhoneNumber { get; set; }

    public string? FullName { get; set; }

    public string? Password { get; set; }

    public string? Dob { get; set; }

    public bool? Gender { get; set; }

    public string? Province { get; set; }

    public string? District { get; set; }

    public string? Ward { get; set; }

    public DateTime? CreateAt { get; set; }

    public DateTime? UpdateAt { get; set; }
}
