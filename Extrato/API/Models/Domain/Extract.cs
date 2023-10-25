﻿namespace Extrato.API.Models.Domain
{
    public enum LaunchStatus
    {
        Valid,
        Canceled
    }
    public class Extract
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public DateTime DateTime { get; set; } = DateTime.UtcNow;
        public decimal Value { get; set; }
        public string Miscellaneous { get; set; }
        public LaunchStatus Status { get; set; } = LaunchStatus.Valid;
    }
}