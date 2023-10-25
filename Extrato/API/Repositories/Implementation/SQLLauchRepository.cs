using Extrato.API.Data;
using Extrato.API.Models.Domain;
using Extrato.API.Repositories.Interface;

namespace Extrato.API.Repositories.Implementation
{
    public class SQLLauchRepository : ILauchRepository
    {
        private readonly ExtractDbContext dbcontext;

        public SQLLauchRepository(ExtractDbContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }

        public async Task<Extract> CreateAsync(Extract extract)
        {
            await dbcontext.AddAsync(extract);
            await dbcontext.SaveChangesAsync();

            return extract; 
        }
    }
}
