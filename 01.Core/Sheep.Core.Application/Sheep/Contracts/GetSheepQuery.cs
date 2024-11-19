using Sheep.Core.Domain.Sheep.Entities;
using Sheep.Framework.Application.Entity;


namespace Sheep.Core.Application.Sheep.Contracts
{
    public class GetSheepQuery : BasePagging
    {
        public List<SheepEntity> sheepEntities { get; set; }
        public string trim { get; set; }
    }
}
