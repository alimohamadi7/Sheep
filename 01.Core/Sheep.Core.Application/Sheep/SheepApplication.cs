using DNTPersianUtils.Core;
using Sheep.Core.Application.Sheep.Contracts;
using Sheep.Core.Application.Sheep.Contracts.Repository;
using Sheep.Core.Domain.Sheep.Entities;
using Sheep.Framework.Application.Operation;


namespace Sheep.Core.Application.Sheep
{
    public class SheepApplication : ISheepApplication
    {
        private readonly ISheepRepository _sheepRepository;
        public SheepApplication(ISheepRepository sheepRepository)
        {
            _sheepRepository = sheepRepository;
        }
        public async Task<OperationResult<bool>> Create(CreateCommand command, CancellationToken cancellationToken)
        {
            if( await _sheepRepository.Exists(x=>x.SheepNumber==command.SheepNumber))
                return  OperationResult<bool>.FailureResult(command.SheepNumber,ApplicationMessages.DuplicatedRecord);
            SheepEntity entity = new SheepEntity(command.SheepNumber, command.SheepbirthDate.ToGregorianDateTime(),
                command.Sheepshop.ToGregorianDateTime(),
                command.ParentId, command.SheepState, command.Gender,command.SheepSellDate.ToGregorianDateTime(),
                command.SheepwastedDate.ToGregorianDateTime());
            await _sheepRepository.AddAsync(entity, cancellationToken);
            return OperationResult<bool>.SuccessResult(true);
        }

        public Task<OperationResult<bool>> Delete(long id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<EditCommand>> Edit(EditCommand command, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<OperationResult<GetSheepQuery>> GetAllSheep(CancellationToken cancellationToken, int pageId = 1, string trim = "")
        {
            return await _sheepRepository.GetAll(cancellationToken, pageId, trim);
        }

        public async Task<OperationResult<bool>> IsExistSheep(CreateCommand createCommand, CancellationToken cancellationToken)
        {
            return await _sheepRepository.IsExistSheep(createCommand, cancellationToken);
        }

        public Task<OperationResult<EditCommand>> GetDetails(long id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
