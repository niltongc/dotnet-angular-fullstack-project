using Extrato.API.Models.Domain;

namespace Extrato.API.Repositories.Interface
{
    public interface ILauchRepository
    {
        Task<Extract> CreateAsync(Extract extract);
    }
}
