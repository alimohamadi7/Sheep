

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
        const int One = 1;
        const int Ninety = 90;
        const int One_hundred_eighty = 180;
        const int Five_hundred_forty = 540;
        public SheepCategoryApplication(ISheepCategoryRepository sheepCategoryrepository, ICategoryApplication categoryApplication)
        {
            _SheepCategoryrepository = sheepCategoryrepository;
            _categoryApplication = categoryApplication;
        }

        public async Task<OperationResult<bool>> Create(CreateSheepCategorCommand command, CancellationToken cancellationToken)
        {

            CategoryType categoryType = CategoryType.none;
            if (Enumerable.Range(One, Ninety).Contains(command.Age))
            {
                categoryType = CategoryType.Zero_Three;
            }
            else if (Enumerable.Range(Ninety + One, One_hundred_eighty).Contains(command.Age))
            {
                categoryType = CategoryType.Three_Six;
            }
            else if (Enumerable.Range(One_hundred_eighty+One,Five_hundred_forty).Contains(command.Age))
            {
                categoryType = CategoryType.Six_Eighteen;
            }
            else if ((command.Age >Five_hundred_forty)&& (command.Gender == GenderType.Male))
            {
                categoryType = CategoryType.Ram;
            }
            else if ((command.Age > Five_hundred_forty) && (command.Gender == GenderType.Female))
            {
                categoryType = CategoryType.Ewe;
            }
            command.Start_Zero_Three = command.Birthdate;
            command.End_Zero_Three = command.Birthdate.AddDays(Ninety);
            command.End_Three_Six = command.Birthdate.AddDays(One_hundred_eighty);
            command.End_Six_Eighteen = command.Birthdate.AddDays(Five_hundred_forty);
            command.ActiveCategory = categoryType;
            var categoryEntity = await _categoryApplication.GetCategoryByCategoryType(categoryType, cancellationToken);
            SheepCategoryEntity sheepCategoryEntity = new SheepCategoryEntity(command.SheepId, categoryEntity.Id,
                command.ActiveCategory, command.Start_Zero_Three, command.End_Zero_Three,command.End_Three_Six,
                command.End_Six_Eighteen);
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
