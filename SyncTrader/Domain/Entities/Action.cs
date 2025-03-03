using System;
using System.Collections.Generic;

namespace SyncTrader.Domain.Entities;

public partial class Action
{
    public int ActionId { get; set; }

    public int UserId { get; set; }

    public DateOnly ActionDate { get; set; }

    public string CompanyName { get; set; } = null!;

    public string CompanyId { get; set; } = null!;

    public decimal Amount { get; set; }

    public decimal Percentage { get; set; }

    public int StatusId { get; set; }

    public bool ActionChoice { get; set; }

    public int ActionTypeId { get; set; }

    public decimal? OrderTime { get; set; }

    public virtual ActionType ActionType { get; set; } = null!;

    public virtual LoggingAction? LoggingAction { get; set; }

    public virtual StatusAction Status { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
