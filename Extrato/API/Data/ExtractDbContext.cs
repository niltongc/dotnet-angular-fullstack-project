using Extrato.API.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Extrato.API.Data
{
    public class ExtractDbContext : DbContext
    {
        public ExtractDbContext(DbContextOptions<ExtractDbContext> options) : base(options)
        {


        }

        public DbSet<Extract> Extracts { get; set; }
    }
}
