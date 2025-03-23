﻿using SyncTrader.Domain.ValueObjects;

namespace SyncTrader.Application.Dtos
{
    public class UserDto
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public decimal Amount { get; set; }
        public DateTime RegistrationDate { get; set; }
        public bool Admin { get; set; }
        public bool AutomaticAction { get; set; }
        public bool UserMaster { get; set; }
        public bool ActuallyUser { get; set; }

        public DateTime? UnuscriptionDate { get; set; }
    }

    public class CreateUserDto
    {
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
    }
}
