using Framework.Application.Entity;
using Sheep.Core.Domain.Wages_overheads;


namespace Sheep.Core.Application.Wages_overheads
{
    public class GetWagesOverheadQuery : BasePagging
    {
        public List<Wages_overheadsEntity> wagesOverheads { get; set; }
        public string Salary { get; set; }
        public string Overhead { get; set; }
        public string? Start { get; set; }
        public string? End { get; set; }
    }
}
