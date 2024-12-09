using Sheep.Core.Domain.Category;
using Sheep.Core.Domain.Wages_overheads;
using Sheep.Framework.Application.Cotrats.Data;
using Sheep.Framework.Domain.Entities;


namespace Sheep.Core.Application.Wages_overheads.Contracts
{
    public interface IWagesoverheadsRepository : IRepository<Wages_overheadsEntity>
    {
        Task<GetWagesOverheadQuery> GetAll(CancellationToken cancellationToken, string? start, string?end, int PageId = 1, string trim = "");
        Task<IQueryable<Wages_overheadsEntity>> GetWagesOverheadDate(CancellationToken cancellationToken, int PageId = 1);

    }
}
