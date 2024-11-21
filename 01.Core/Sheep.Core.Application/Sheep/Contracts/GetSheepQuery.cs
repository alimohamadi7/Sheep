using Sheep.Core.Domain.Sheep.Entities;
using Framework.Application.Entity;
using Sheep.Framework.Application.Operation;


namespace Sheep.Core.Application.Sheep.Contracts
{
    public class GetSheepQuery : BasePagging
    {
        public List<SheepEntity> sheepEntities { get; set; }
        public string trim { get; set; }
    }
}
