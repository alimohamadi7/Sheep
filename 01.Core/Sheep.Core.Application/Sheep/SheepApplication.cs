﻿using DNTPersianUtils.Core;
using Sheep.Core.Application.Sheep.Contracts;
using Sheep.Core.Application.Sheep.Contracts.Repository;
using Sheep.Core.Domain.Sheep.Entities;
using Sheep.Framework.Application.Operation;
using Sheep.Framework.Domain.Entities;


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
            if(command.SheepParentId != null)
            {
                if (!await _sheepRepository.Exists(x => x.SheepNumber == command.SheepParentId))
                    return OperationResult<bool>.FailureResult(command.SheepNumber, ApplicationMessages.NotSheepFound);
                var sheepEntity = await _sheepRepository.GetSheepBySheepNumber(command.SheepParentId, cancellationToken);
                if (sheepEntity.Gender ==GenderType.Male )
                {
                    return OperationResult<bool>.FailureResult(command.SheepNumber, ApplicationMessages.SheepMale);
                }
                command.ParentId= sheepEntity.Id;
            }
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
            if((command.PastSheepNumber != command.SheepNumber))
            {
                if (await _sheepRepository.Exists(x => x.SheepNumber == command.SheepNumber))
                    return OperationResult<bool>.FailureResult(command.SheepNumber, ApplicationMessages.DuplicatedRecord);
            }
            if (command.SheepParentId != null)
            {      
                //check sheep mother is exists
                if (!await _sheepRepository.Exists(x => x.SheepNumber == command.SheepParentId))
                    return OperationResult<bool>.FailureResult(command.SheepNumber, ApplicationMessages.NotSheepFound);
                var sheepEntity = await _sheepRepository.GetSheepBySheepNumber(command.SheepParentId, cancellationToken);
                //not add child for gender male
                if (sheepEntity.Gender == GenderType.Male)
                {
                    return OperationResult<bool>.FailureResult(command.SheepNumber, ApplicationMessages.SheepMale);
                }
                command.ParentId = sheepEntity.Id;
                //check not add new sheepid and lastsheepid add to sheepmother
                if (sheepEntity.Id == command.ParentId)
                {
                    return OperationResult<bool>.FailureResult(command.SheepNumber, ApplicationMessages.SheepParentIdChangeTosheepNumber);

                }
            }
            //check sheep has child gender not change to male
            if(await _sheepRepository.SheepIsParent(command.Id, cancellationToken) &&(command.Gender==GenderType.Male))
            {
                return OperationResult<bool>.FailureResult(command.SheepNumber, ApplicationMessages.SheepIsParentNotMale);

            }
            //check sheep is parent not change sheepnumber
            if (await _sheepRepository.SheepIsParent(command.Id, cancellationToken))
            {
                return OperationResult<bool>.FailureResult(command.SheepNumber, ApplicationMessages.SheepIsParentChangesheepNumber);

            }
            //check not same sheepnumber and sheepMothernumber
            if (CheckSameSheepNumberandMotherNumber(command.SheepNumber,command.SheepParentId))
            {
                return OperationResult<bool>.FailureResult(command.SheepNumber, ApplicationMessages.NotSameNumber);

            }

            var sheep =await _sheepRepository.GetByIdAsync(cancellationToken,command.Id);
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
                Id =sheep.Id,
                SheepbirthDate=sheep.SheepbirthDate.ToShortPersianDateString(),
                SheepNumber=sheep.SheepNumber,  
                SheepSellDate= sheep.SheepSellDate.ToShortPersianDateString(),
                SheepshopDate=sheep.SheepshopDate.ToShortPersianDateString(),
                SheepwastedDate=sheep.SheepwastedDate.ToShortPersianDateString(),
                SheepState=sheep.SheepState,
                Gender=sheep.Gender,
                ParentId=sheep.ParentId,
                PastSheepNumber = sheep.SheepNumber,
            };
            if (sheep.ParentId != null)
            {
               SheepEntity entity = await _sheepRepository.GetByIdAsync(cancellationToken, sheep.ParentId);
                editCommand.SheepParentId = entity.SheepNumber;
            }
            return editCommand;
        }

        public bool CheckSameSheepNumberandMotherNumber(string sheepnumber, string? sheepmothernunber)
        {
            var result = false;
            if (sheepnumber == sheepmothernunber) result=true;
            return result;

        }
    }

}
