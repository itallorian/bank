﻿namespace BANK.BUSINESSLOGIC.Models.Manager
{
    public class Manager
    {
        public decimal? UserId { get; set; }

        public bool Active { get; set; }

        public string? Name { get; set; }

        public string? UserName { get; set; }

        public string? Email { get; set; }

        public string? Password { get; set; }
    }
}
