using Extrato.API.Models.Domain;

namespace Extrato.API.Repositories.Interface
{
    public interface ITransactionRepository
    {
        Task<Extract> CreateAsync(Extract extract);
        Task<IEnumerable<Extract>> GetTransactionsForDataRange(DateTime startDay, DateTime endDay);
        Task<Extract> GetTransactionById(Guid id);
        Task<Extract> UpdateTransactionAsync(Guid id, Extract extract);
        Task<Extract> CancelTransaction(Guid id, Extract extract);

        Task<decimal> SumTransactions();
        Task<Extract> CreateTransactionNotAdHoc();
    }
}
