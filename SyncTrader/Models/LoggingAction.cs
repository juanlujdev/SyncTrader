using System;
using System.Collections.Generic;

namespace SyncTrader.Models;

public partial class LoggingAction
{
    public int LoggingActionsId { get; set; }

    public int UserId { get; set; }

    public int? ActionId { get; set; }

    public decimal AutomaticAmount { get; set; }

    public decimal AutomaticPercentage { get; set; }

    public decimal ManualAmount { get; set; }

    public decimal ManualPercentage { get; set; }

    public string? ErrorAction { get; set; }

    public virtual Action? Action { get; set; }

    public virtual User User { get; set; } = null!;
}
