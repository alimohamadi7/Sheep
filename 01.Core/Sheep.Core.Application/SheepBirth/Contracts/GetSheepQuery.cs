using Sheep.Core.Domain.Sheep.Entities;
using Framework.Application.Entity;


namespace Sheep.Core.Application.SheepBirth.Contracts
{
    public class GetSheepQuery : BasePagging
    {
        public List<SheepEntity> sheepEntities { get; set; }
        public string trim { get; set; }
    }
}
