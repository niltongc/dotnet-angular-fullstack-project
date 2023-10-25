namespace Extrato.API.Models.DTO
{
    public enum LaunchStatus
    {
        Valid,
        Canceled
    }
    public class AddLauchDTO
    {
        public string Description { get; set; }
        public decimal Value { get; set; }
        public string Miscellaneous { get; set; }
        public LaunchStatus Status { get; set; } = LaunchStatus.Valid;
    }
}
