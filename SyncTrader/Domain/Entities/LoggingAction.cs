using System;
using System.Collections.Generic;

namespace SyncTrader.Domain.Entities;

public partial class LoggingAction
{
    public int LoggingActionsId { get; set; }

    public int UserId { get; set; }

    public int? ActionId { get; set; }

    public decimal Amount { get; set; }

    public decimal Percentage { get; set; }

    public string? ErrorAction { get; set; }

    public bool AutomaticAction { get; set; }

    public virtual Action? Action { get; set; }

    public virtual User User { get; set; } = null!;
}
