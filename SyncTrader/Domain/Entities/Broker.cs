using System;
using System.Collections.Generic;

namespace SyncTrader.Domain.Entities;

public partial class Broker
{
    public int BrokerId { get; set; }

    public string Name { get; set; } = null!;

    public string ApiBroker { get; set; } = null!;

    public string Token { get; set; } = null!;

    public int? UserId { get; set; }

    public virtual User? User { get; set; }

    public virtual User? UserNavigation { get; set; }
}
