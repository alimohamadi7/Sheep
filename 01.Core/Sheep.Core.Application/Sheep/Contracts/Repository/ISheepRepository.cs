using Sheep.Core.Domain.Sheep.Entities;
using Sheep.Framework.Application.Cotrats.Data;


namespace Sheep.Core.Application.Sheep.Contracts.Repository
{
    public interface ISheepRepository : IRepository<SheepEntity>
    {
        Task<GetSheepQuery> GetAll(CancellationToken cancellationToken, int PageId = 1, string trim = "");
    }
}
