

using Sheep.Core.Application.Sheep.SheepFullPrice.Contracts;
using Sheep.Core.Domain.Sheep.Entities;
using Sheep.Framework.Application.Operation;

namespace Sheep.Core.Application.Sheep.SheepFullPrice
{
    public class FullPriceSheepApplication : IFullPriceSheepApplication
    {
        private readonly IFullPriceSheepRepository _repository;

        public FullPriceSheepApplication(IFullPriceSheepRepository repository)
        {
            _repository = repository;
        }

        public async Task<OperationResult<bool>> ThreeSixCreate(CreateCommand Command, CancellationToken cancellationToken)
        {
            SheepFullPriceEntity sheepFullPriceEntity = new SheepFullPriceEntity(Command.PriceSheep, Command.Unabsorbedcosts,Command.SheepId,Command.Calcuted);
          await  _repository.AddAsync(sheepFullPriceEntity, cancellationToken,false);
            return  OperationResult<bool>.SuccessResult(true);
        }

        public async Task<SheepFullPriceEntity> GetSheepBySheepId(Guid Id, CancellationToken cancellationToken)
        {
           return await _repository.GetSheepBySheepId(Id, cancellationToken);
        }
    }
}
