using Sheep.Core.Application.Sheep.Contracts;
using Sheep.Core.Domain.Sheep.Entities;
using Sheep.Framework.Application.Cotrats.Data;
using Sheep.Framework.Application.Operation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sheep.Core.Application.Category.Contracts
{
    public interface ICategoryRepository : IRepository<CategoryEntity>
    {
        Task<OperationResult<GetCategoryQouery>> GetAll(CancellationToken cancellationToken);
    }
}
