

using Sheep.Core.Application.Category.Contracts;
using Sheep.Core.Application.Sheep.SheepCategory.Contracts;
using Sheep.Core.Domain.Sheep.Entities;
using Sheep.Framework.Application.Operation;
using Sheep.Framework.Domain.Entities;
using System.Linq.Expressions;
using System.Xml.Linq;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
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
            command.Start_Zero_Three = command.Birthdate;
            command.End_Zero_Three = command.Birthdate.AddDays(Ninety);
            command.End_Three_Six = command.Birthdate.AddDays(One_hundred_eighty);
            command.End_Six_Eighteen = command.Birthdate.AddDays(Five_hundred_forty);
            command.ActiveCategory = OutCategory(command.Age,command.Gender);
            var categoryEntity = await _categoryApplication.GetCategoryByCategoryType(command.ActiveCategory, cancellationToken);
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

        public async Task CalculateSheepCategory(CancellationToken cancellationToken)
        {
            var sheepCategoryCount = await _SheepCategoryrepository.GetCount();
            IEnumerable<int> numbers = Enumerable.Range(1, sheepCategoryCount);
            IEnumerable<int[]> chunks = numbers.Chunk(100);
            var sheepcategory = _SheepCategoryrepository.GetsheepForCategory(cancellationToken, chunks.First(), chunks.Last());

            foreach (int[] chunk in chunks)
            {

            }
        }
        public CategoryType OutCategory(int Age, GenderType Gender)
        {
            CategoryType categoryType = CategoryType.none;
            if (Enumerable.Range(One, Ninety).Contains(Age))
            {
              return  categoryType = CategoryType.Zero_Three;
            }
            else if (Enumerable.Range(Ninety + One, One_hundred_eighty).Contains(Age))
            {
               return categoryType = CategoryType.Three_Six;
            }
            else if (Enumerable.Range(One_hundred_eighty + One, Five_hundred_forty).Contains(Age))
            {
              return  categoryType = CategoryType.Six_Eighteen;
            }
            else if ((Age > Five_hundred_forty) && (Gender == GenderType.Male))
            {
               return categoryType = CategoryType.Ram;
            }
            else if ((Age > Five_hundred_forty) && (Gender == GenderType.Female))
            {
              return  categoryType = CategoryType.Ewe;
            }
            return categoryType;
        }
    }
}
