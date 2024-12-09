﻿

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

        public async Task<OperationResult<bool>> Create(CreateSheepCategoryCommand command, CancellationToken cancellationToken)
        {
            command.Start_Zero_Three = command.Birthdate;
            command.End_Zero_Three = command.Birthdate.AddDays(Ninety);
            command.Start_Three_Six = command.Birthdate.AddDays(Ninety +One);
            command.End_Three_Six = command.Birthdate.AddDays(One_hundred_eighty);
            command.Start_Six_Eighteen= command.Birthdate.AddDays(One_hundred_eighty+One);
            command.End_Six_Eighteen = command.Birthdate.AddDays(Five_hundred_forty);
            command.Start_Ram_Ewe= command.Birthdate.AddDays(Five_hundred_forty+One);
            command.ActiveCategory = OutCategory(command.Age, command.Gender);
            var categoryEntity = await _categoryApplication.GetCategoryByCategoryType(command.ActiveCategory, cancellationToken);
            SheepCategoryEntity sheepCategoryEntity = new SheepCategoryEntity(command.SheepId, categoryEntity.Id,
               command.Gender, command.ActiveCategory, command.Start_Zero_Three, command.End_Zero_Three, command.Start_Three_Six,command.End_Three_Six,
              command.Start_Six_Eighteen,command.End_Six_Eighteen,command.Start_Ram_Ewe);
            await _SheepCategoryrepository.AddAsync(sheepCategoryEntity, cancellationToken);
            return OperationResult<bool>.SuccessResult(true);
        }

        public async Task<OperationResult<bool>> Delete(Guid SheepId, CancellationToken cancellationToken)
        {
            var CategorySheepEntity = await _SheepCategoryrepository.GetSheepCategoryBySheepId(SheepId, cancellationToken);
            CategorySheepEntity.Delete();
        await    _SheepCategoryrepository.SaveChangesAsync(cancellationToken);
            return OperationResult<bool>.SuccessResult(true);
        }

        public async Task<OperationResult<bool>> Edit(EditSheepCategoryCommand command, CancellationToken cancellationToken)
        {
            command.Start_Zero_Three = command.Birthdate;
            command.End_Zero_Three = command.Birthdate.AddDays(Ninety);
            command.Start_Three_Six = command.Birthdate.AddDays(Ninety + One);
            command.End_Three_Six = command.Birthdate.AddDays(One_hundred_eighty);
            command.Start_Six_Eighteen = command.Birthdate.AddDays(One_hundred_eighty + One);
            command.End_Six_Eighteen = command.Birthdate.AddDays(Five_hundred_forty);
            command.Start_Ram_Ewe = command.Birthdate.AddDays(Five_hundred_forty + One);
            var categoryEntity = await _categoryApplication.GetCategoryByCategoryType(command.ActiveCategory, cancellationToken);
            var CategorySheepEntity=await _SheepCategoryrepository.GetSheepCategoryBySheepId(command.SheepId,cancellationToken);
            CategorySheepEntity.Edit(command.SheepId, categoryEntity.Id,
               command.Gender, command.ActiveCategory, command.Start_Zero_Three, command.End_Zero_Three, command.Start_Three_Six,command.End_Three_Six,
                command.Start_Six_Eighteen,command.End_Six_Eighteen,command.Start_Ram_Ewe);

          await  _SheepCategoryrepository.SaveChangesAsync(cancellationToken);
            return OperationResult<bool>.SuccessResult(true);
        }

        public Task<GetSheepCategoryQuery> GetAllSheep(CancellationToken cancellationToken, int pageId = 1, string trim = "")
        {
            throw new NotImplementedException();
        }

        public Task<EditSheepCategoryCommand> GetDetails(Guid id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<bool>> IsExistSheep(CreateSheepCategoryCommand createCommand, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task CalculateSheepCategory(CancellationToken cancellationToken)
        {
            //var sheepCategoryCount = await _SheepCategoryrepository.GetCount();
            //IEnumerable<int> numbers = Enumerable.Range(1, sheepCategoryCount);
            //IEnumerable<int[]> chunks = numbers.Chunk(100);
            var pageId = 1;
            IQueryable<SheepCategoryEntity> sheepcategory;
            for (int i = 0; i < pageId; i++)
            {
                sheepcategory = _SheepCategoryrepository.GetsheepForCategory(cancellationToken, pageId);
                foreach (var item in sheepcategory)
                {
                    var sheep=await _SheepCategoryrepository.GetByIdAsync(cancellationToken, item.Id);
                    switch (sheep.ActiveCategory)
                    {
                        case CategoryType.Zero_Three:
                            if (item.End_Zero_Three < DateTime.Now)
                                sheep.ActiveCategory = CategoryType.Three_Six;
                            break;
                        case CategoryType.Three_Six:
                            if (sheep.End_Three_Six.Date < DateTime.Now)
                                sheep.ActiveCategory = CategoryType.Six_Eighteen;
                            break;
                        case CategoryType.Six_Eighteen:
                            if (sheep.End_Six_Eighteen < DateTime.Now && sheep.Gender == GenderType.Male)
                                sheep.ActiveCategory = CategoryType.Ram;
                            else if(sheep.End_Six_Eighteen < DateTime.Now && sheep.Gender == GenderType.Female)
                               sheep.ActiveCategory = CategoryType.Ewe;
                            break;
                    }
                }
                if (sheepcategory.Any())
                {
                    pageId++;
                    await _SheepCategoryrepository.SaveChangesAsync(cancellationToken);
                }
            }
        }
        public CategoryType OutCategory(int Age, GenderType Gender)
        {
            CategoryType categoryType = CategoryType.none;
            if (Enumerable.Range(One, Ninety).Contains(Age))
            {
                return categoryType = CategoryType.Zero_Three;
            }
            else if (Enumerable.Range(Ninety + One, Ninety).Contains(Age))
            {
                return categoryType = CategoryType.Three_Six;
            }
            else if (Enumerable.Range(One_hundred_eighty + One, 360).Contains(Age))
            {
                return categoryType = CategoryType.Six_Eighteen;
            }
            else if ((Age > Five_hundred_forty) && (Gender == GenderType.Male))
            {
                return categoryType = CategoryType.Ram;
            }
            else if ((Age > Five_hundred_forty) && (Gender == GenderType.Female))
            {
                return categoryType = CategoryType.Ewe;
            }
            return categoryType;
        }
    }
}
