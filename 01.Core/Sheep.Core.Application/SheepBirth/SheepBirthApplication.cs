using DNTPersianUtils.Core;
using Sheep.Core.Application.SheepBirth.Contracts;
using Sheep.Core.Domain.Sheep.Entities;
using Sheep.Framework.Application.Operation;


namespace Sheep.Core.Application.SheepBirth
{
    public class SheepBirthApplication : ISheepBirthApplication
    {
        private readonly ISheepBirthRepository _sheepRepository;
        public SheepBirthApplication(ISheepBirthRepository sheepRepository)
        {
            _sheepRepository = sheepRepository;
        }
        public async Task<OperationResult<bool>> Create(CreateCommand command, CancellationToken cancellationToken)
        {
            if( await _sheepRepository.Exists(x=>x.SheepNumber==command.SheepNumber))
                return  OperationResult<bool>.FailureResult(command.SheepNumber,ApplicationMessages.DuplicatedRecord);
            SheepEntity entity = new SheepEntity(command.SheepNumber, command.SheepbirthDate.ToGregorianDateTime(),
                command.SheepshopDate.ToGregorianDateTime(),
                command.ParentId, command.SheepState, command.Gender,command.SheepSellDate.ToGregorianDateTime(),
                command.SheepwastedDate.ToGregorianDateTime());
            await _sheepRepository.AddAsync(entity, cancellationToken);
            return OperationResult<bool>.SuccessResult(true);
        }

        public async Task<OperationResult<bool>> Delete(Guid id, CancellationToken cancellationToken)
        {
            var sheep = await _sheepRepository.GetByIdAsync(cancellationToken, id);
            sheep.Delete();
            await _sheepRepository.UpdateAsync(sheep, cancellationToken);
            return OperationResult<bool>.SuccessResult(true);
        }

        public  async Task<OperationResult<bool>> Edit(EditCommand command, CancellationToken cancellationToken)
        {
            if((command.PastId != command.Id))
            {
                if (await _sheepRepository.Exists(x => x.SheepNumber == command.SheepNumber))
                    return OperationResult<bool>.FailureResult(command.SheepNumber, ApplicationMessages.DuplicatedRecord);
            }
            var sheep=await _sheepRepository.GetByIdAsync(cancellationToken,command.Id);
            sheep.Edit(command.SheepNumber, command.SheepbirthDate.ToGregorianDateTime(), command.SheepshopDate.ToGregorianDateTime(), command.ParentId,
                command.SheepState, command.Gender, command.SheepSellDate.ToGregorianDateTime(), command.SheepwastedDate.ToGregorianDateTime());
            await _sheepRepository.UpdateAsync(sheep, cancellationToken);
            return OperationResult<bool>.SuccessResult(true);
        }

        public async Task<GetSheepQuery> GetAllSheep(CancellationToken cancellationToken, int pageId = 1, string trim = "")
        {
            return await _sheepRepository.GetAll(cancellationToken, pageId, trim);
        }

        public async Task<OperationResult<bool>> IsExistSheep(CreateCommand createCommand, CancellationToken cancellationToken)
        {
            return await _sheepRepository.IsExistSheep(createCommand, cancellationToken);
        }

        public  async Task<EditCommand> GetDetails(Guid id, CancellationToken cancellationToken)
        {
            var sheep=await _sheepRepository.GetByIdAsync(cancellationToken,id);
            EditCommand editCommand = new EditCommand()
            {
                Id=sheep.Id,
                SheepbirthDate=sheep.SheepbirthDate.ToShortPersianDateString(),
                SheepNumber=sheep.SheepNumber,  
                SheepSellDate= sheep.SheepSellDate.ToShortPersianDateString(),
                SheepshopDate=sheep.SheepshopDate.ToShortPersianDateString(),
                SheepwastedDate=sheep.SheepwastedDate.ToShortPersianDateString(),
                SheepState=sheep.SheepState,
                Gender=sheep.Gender,
                ParentId=sheep.ParentId,
                PastId=sheep.Id
            };
            return editCommand;
        }

    }
}
