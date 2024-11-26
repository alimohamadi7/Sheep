

using Sheep.Core.Application.Category.Contracts;
using Sheep.Core.Application.Sheep.SheepCategory.Contracts;
using Sheep.Core.Domain.Sheep.Entities;
using Sheep.Framework.Application.Operation;
using Sheep.Framework.Domain.Entities;
using System.Linq.Expressions;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace Sheep.Core.Application.Sheep.SheepCategory
{
    public class SheepCategoryApplication : ISheepCategoryApplication
    {
        private readonly ISheepCategoryRepository _SheepCategoryrepository;
        private readonly ICategoryApplication _categoryApplication;
        public SheepCategoryApplication(ISheepCategoryRepository sheepCategoryrepository, ICategoryApplication categoryApplication)
        {
            _SheepCategoryrepository = sheepCategoryrepository;
            _categoryApplication = categoryApplication;
        }

        public async Task<OperationResult<bool>> Create(CreateSheepCategorCommand command, CancellationToken cancellationToken)
        {
            const int One = 1;
            const int Ninety= 90;
            const int One_hundred_eighty =180;
            const int Five_hundred_forty = 540;
            CategoryType categoryType = CategoryType.none;
            if (Enumerable.Range(One, Ninety).Contains(command.Age))
            {
                command.Start = command.Birthdate;
                command.End = command.Birthdate.AddDays(Ninety);   
                categoryType = CategoryType.Zero_Three;
            }
            else if (Enumerable.Range(Ninety + One, One_hundred_eighty).Contains(command.Age))
            {
                command.Start = command.Birthdate.AddDays(Ninety +One);
                command.End = command.Birthdate.AddDays(One_hundred_eighty);
                categoryType = CategoryType.Three_Six;
            }
            else if (Enumerable.Range(One_hundred_eighty+One,Five_hundred_forty).Contains(command.Age))
            {
                command.Start = command.Birthdate.AddDays(One_hundred_eighty+One);
                command.End = command.Birthdate.AddDays(Five_hundred_forty);
                categoryType = CategoryType.Six_Eighteen;
            }
            else if ((command.Age >Five_hundred_forty)&& (command.Gender == GenderType.Male))
            {
                command.Start = command.Birthdate.AddDays(Five_hundred_forty+One);
                command.End = command.Start;
                categoryType = CategoryType.Ram;
            }
            else if ((command.Age > Five_hundred_forty) && (command.Gender == GenderType.Male))
            {
                command.Start = command.Birthdate.AddDays(Five_hundred_forty + One);
                command.End = command.Start;
                categoryType = CategoryType.Ewe;
            }

            var sheepcategoryactive = await _SheepCategoryrepository.GetAll(command.SheepId,cancellationToken);
            if (sheepcategoryactive != null)
            {
                foreach (var item in sheepcategoryactive)
                {
                    var sheepcategoryactivtrue = await _SheepCategoryrepository.GetByIdAsync(cancellationToken, item.id);
                    sheepcategoryactivtrue.ActiveCategory = false;
                    await _SheepCategoryrepository.UpdateAsync(sheepcategoryactivtrue, cancellationToken);
                }
            }
            command.ActiveCategory = true;
            var categoryEntity = await _categoryApplication.GetCategoryByCategoryType(categoryType, cancellationToken);
            SheepCategoryEntity sheepCategoryEntity = new SheepCategoryEntity(command.SheepId, categoryEntity.Id,
                command.ActiveCategory, command.Start, command.End);
            await _SheepCategoryrepository.AddAsync(sheepCategoryEntity, cancellationToken);
            return OperationResult<bool>.SuccessResult(true);
        }

        public Task<OperationResult<bool>> Delete(Guid id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<bool>> Edit(EditSheepCategoryCommand command, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<GetSheepCategoryQuery> GetAllSheep(CancellationToken cancellationToken, int pageId = 1, string trim = "")
        {
            throw new NotImplementedException();
        }

        public Task<EditSheepCategoryCommand> GetDetails(Guid id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<bool>> IsExistSheep(CreateSheepCategorCommand createCommand, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
