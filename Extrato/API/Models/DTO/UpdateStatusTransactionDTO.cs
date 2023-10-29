namespace Extrato.API.Models.DTO
{
  
        public enum TransactionStatus
        {
            Valid,
            Canceled
        }
        public class UpdateStatusTransactionDTO
        {
            public TransactionStatus Status { get; set; }
        }
    
}
