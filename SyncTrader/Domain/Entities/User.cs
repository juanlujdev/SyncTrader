using SyncTrader.Domain.ValueObjects;

namespace SyncTrader.Domain.Entities;

public partial class User
{
    public int UserId { get; set; }
    public string Name { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public DateTime RegistrationDate { get; set; }

    public bool ActuallyUser { get; set; }

    public DateTime? UnuscriptionDate { get; set; }

    public bool Admin { get; set; }

    public decimal Amount { get; set; }

    public string Password { get; set; } = null!;

    public int? BrokerId { get; set; }

    public bool AutomaticAction { get; set; }

    public bool UserMaster { get; set; }

    public virtual ICollection<Action> Actions { get; set; } = new List<Action>();

    public virtual Broker? Broker { get; set; }

    public virtual Broker? BrokerNavigation { get; set; }

    public virtual ICollection<LoggingAction> LoggingActions { get; set; } = new List<LoggingAction>();
}
