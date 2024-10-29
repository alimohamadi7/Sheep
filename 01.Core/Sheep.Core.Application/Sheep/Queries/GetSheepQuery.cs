using MediatR;
using Sheep.Core.Domain.Sheep.Entities;
using Sheep.Framework.Application.Entity;
using Sheep.Framework.Application.Operation;


namespace Sheep.Core.Application.Sheep.Queries
{
    public class GetSheepQuery : BasePagging, IRequest<OperationResult<GetSheepQuery>>
    {
        public List<SheepEntity> sheepEntities { get; set; }
        public string trim { get; set; }
    }
}
