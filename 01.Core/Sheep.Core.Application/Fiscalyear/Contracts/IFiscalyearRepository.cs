

using Sheep.Core.Application.Wages_overheads;
using Sheep.Core.Domain.Fiscalyear;
using Sheep.Framework.Application.Cotrats.Data;

namespace Sheep.Core.Application.Fiscalyear.Contracts
{
    public interface IFiscalyearRepository:IRepository<FiscalyearEntity>
    {
        Task<GetFiscalyearQuery> GetAll(CancellationToken cancellationToken);

    }
}
