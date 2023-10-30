using Extrato.API.Data;
using Extrato.API.Models.Domain;
using Extrato.API.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace Extrato.API.Repositories.Implementation
{
    public class SQLTransactionRepository : ITransactionRepository
    {
        private readonly ExtractDbContext dbcontext;

        public SQLTransactionRepository(ExtractDbContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }

        public async Task<Extract> CreateAsync(Extract extract)
        {
            await dbcontext.AddAsync(extract);
            await dbcontext.SaveChangesAsync();

            return extract;
        }

        public async Task<IEnumerable<Extract>> GetTransactionsForDataRange(DateTime dayInit, DateTime dayEnd)
        {
            DateTime startDate = dayInit;
            DateTime endDate = dayEnd.AddMinutes(1439).AddSeconds(59);

            var dataRange = await dbcontext.Extracts
                .Where(x => x.DateTime >= startDate && x.DateTime <= endDate)
                .ToListAsync();


            return dataRange;
        }

        public async Task<Extract> GetTransactionById(Guid id)
        {
            var existingTransaction = await dbcontext.Extracts.FirstOrDefaultAsync(x => x.Id == id);

            if (existingTransaction == null)
            {
                return null;
            }

            return existingTransaction;
        }


        public async Task<Extract> UpdateTransactionAsync(Guid id, Extract extract)
        {
            var existingTransaction = await dbcontext.Extracts.FirstOrDefaultAsync(x => x.Id == id && x.IsAdHoc == true && x.Status == 0);

            if(existingTransaction == null)
            {
                return null;
            }

            existingTransaction.DateTime = extract.DateTime;
            existingTransaction.Value = extract.Value;


            await dbcontext.SaveChangesAsync();

            return existingTransaction;
        }

        public async Task<Extract> CancelTransaction(Guid id, Extract extract)
        {
            var existingTransaction = await dbcontext.Extracts.FirstOrDefaultAsync(x => x.Id == id);

            if (existingTransaction == null) 
            {
                return null;
            }

            existingTransaction.Status = extract.Status;

            await dbcontext.SaveChangesAsync();

            return existingTransaction;
        }

        public async Task<decimal> SumTransactions()
        {
            var sumTransaction = await dbcontext.Extracts.Where(x => x.Status == 0).SumAsync(x => x.Value);

            return sumTransaction;
        }

        public async Task<Extract> CreateTransactionNotAdHoc()
        {
            Extract extract = new Extract();

            Random randomNumber = new Random();
            var num = (decimal)randomNumber.NextDouble() * 1000;

            extract.Id = Guid.NewGuid();
            extract.Description = DateTime.UtcNow.ToString("yyyy-MM-dd") + " Not Ad Hoc";
            extract.IsAdHoc = false;
            extract.Status = 0;
            extract.Value = Math.Round(num, 2);

            await dbcontext.AddAsync(extract);
            await dbcontext.SaveChangesAsync();

            return extract;
            
        }
    }
}
