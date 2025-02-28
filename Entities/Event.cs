using System;
using System.Collections.Generic;

namespace RunForLive.Entities;

public partial class Event
{
    public int Id { get; set; }

    public string EventName { get; set; } = null!;

    public string? ImgPath { get; set; }

    public string? Place { get; set; }

    public TimeOnly? OpenTime { get; set; }

    public TimeOnly CloseTime { get; set; }

    public DateOnly? OpenDate { get; set; }

    public string? ScopePrice { get; set; }
}
