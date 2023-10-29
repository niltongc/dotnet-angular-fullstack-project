namespace Extrato.API.Models.DTO
{
    
    public class AddTransactionDTO
    {
        public string Description { get; set; }
        public decimal Value { get; set; }
        public bool IsAdHoc { get; set; } = true;
        
    }
}
