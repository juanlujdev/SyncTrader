using System;
using System.Collections.Generic;

namespace SyncTrader.Models;

public partial class ActionType
{
    public int ActionTypeId { get; set; }

    public string TypeName { get; set; } = null!;

    public virtual ICollection<Action> Actions { get; set; } = new List<Action>();
}
