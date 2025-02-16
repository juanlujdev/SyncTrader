using System;
using System.Collections.Generic;

namespace SyncTrader.Models;

public partial class StatusAction
{
    public int StatusActionId { get; set; }

    public string StatusActionName { get; set; } = null!;

    public virtual ICollection<Action> Actions { get; set; } = new List<Action>();
}
