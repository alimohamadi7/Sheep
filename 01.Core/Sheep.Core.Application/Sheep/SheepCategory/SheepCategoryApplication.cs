using Sheep.Core.Application.Category.Contracts;
using Sheep.Core.Application.Sheep.SheepCategory.Contracts;
using Sheep.Core.Domain.Sheep.Entities;
using Sheep.Framework.Application.Entity;
using Sheep.Framework.Application.Operation;
using Sheep.Framework.Application.Utilities;
using Sheep.Framework.Domain.Entities;


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
            command.Zero_ThreeCalacute = command.Birthdate;
            command.End_Zero_Three = command.Birthdate.AddDays(Ninety);
            command.Start_Three_Six = command.Birthdate.AddDays(Ninety + One);
            command.Three_SixCalcute = command.Birthdate.AddDays(Ninety + One);
            command.End_Three_Six = command.Birthdate.AddDays(One_hundred_eighty);
            command.Start_Six_Eighteen = command.Birthdate.AddDays(One_hundred_eighty + One);
            command.Six_EighteenCalcute = command.Birthdate.AddDays(One_hundred_eighty + One);
            command.End_Six_Eighteen = command.Birthdate.AddDays(Five_hundred_forty);
            command.Start_Ram_Ewe = command.Birthdate.AddDays(Five_hundred_forty + One);
            command.Ram_EweCalcute = command.Birthdate.AddDays(Five_hundred_forty + One);
            command.ActiveCategory = OutCategory(command.Age, command.Gender);
            if (command.SheepshopDate != null)
            {
                var sheepshopDate = Convert.ToDateTime(command.SheepshopDate);
                var Days = Calculate.CalculateDateRange(command.Birthdate, sheepshopDate);
                command.Zero_ThreeCalacute = command.Birthdate.AddDays(Days);
                command.Three_SixCalcute = command.Birthdate.AddDays(Ninety + One + Days);
                command.Six_EighteenCalcute = command.Birthdate.AddDays(One_hundred_eighty + One + Days);
                command.Ram_EweCalcute = command.Birthdate.AddDays(Five_hundred_forty + One + Days);
            }
            var categoryEntity = await _categoryApplication.GetCategoryByCategoryType(command.ActiveCategory, cancellationToken);
            SheepCategoryEntity sheepCategoryEntity = new SheepCategoryEntity(command.SheepId, categoryEntity.Id,
               command.Gender, command.ActiveCategory, command.Start_Zero_Three,command.Zero_ThreeCalacute, command.End_Zero_Three,
               command.Start_Three_Six,command.Three_SixCalcute,command.End_Three_Six,
              command.Start_Six_Eighteen,command.Six_EighteenCalcute,command.End_Six_Eighteen,command.Start_Ram_Ewe,command.Ram_EweCalcute);
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
            command.Zero_ThreeCalacute = command.Birthdate;
            command.End_Zero_Three = command.Birthdate.AddDays(Ninety);
            command.Start_Three_Six = command.Birthdate.AddDays(Ninety + One);
            command.Three_SixCalcute = command.Birthdate.AddDays(Ninety + One);
            command.End_Three_Six = command.Birthdate.AddDays(One_hundred_eighty);
            command.Start_Six_Eighteen = command.Birthdate.AddDays(One_hundred_eighty + One);
            command.Six_EighteenCalcute= command.Birthdate.AddDays(One_hundred_eighty + One);
            command.End_Six_Eighteen = command.Birthdate.AddDays(Five_hundred_forty);
            command.Start_Ram_Ewe = command.Birthdate.AddDays(Five_hundred_forty + One);
            command.Ram_EweCalcute = command.Birthdate.AddDays(Five_hundred_forty + One);
            if (command.SheepshopDate != null)
            {
                var sheepshopDate = Convert.ToDateTime(command.SheepshopDate);
                var Days = Calculate.CalculateDateRange(command.Birthdate, sheepshopDate);
                command.Zero_ThreeCalacute = command.Birthdate.AddDays(Days);
                command.Three_SixCalcute = command.Birthdate.AddDays(Ninety + One + Days);
                command.Six_EighteenCalcute = command.Birthdate.AddDays(One_hundred_eighty + One + Days);
                command.Ram_EweCalcute = command.Birthdate.AddDays(Five_hundred_forty + One + Days);
            }
            command.ActiveCategory = OutCategory(command.Age, command.Gender);
            var categoryEntity = await _categoryApplication.GetCategoryByCategoryType(command.ActiveCategory, cancellationToken);
            var CategorySheepEntity=await _SheepCategoryrepository.GetSheepCategoryBySheepId(command.SheepId,cancellationToken);
            CategorySheepEntity.Edit(command.SheepId, categoryEntity.Id,
               command.Gender, command.ActiveCategory, command.Start_Zero_Three, command.Zero_ThreeCalacute,command.End_Zero_Three, command.Start_Three_Six,command.Three_SixCalcute,command.End_Three_Six,
                command.Start_Six_Eighteen,command.Six_EighteenCalcute,command.End_Six_Eighteen,command.Start_Ram_Ewe,command.Ram_EweCalcute);

          await  _SheepCategoryrepository.SaveChangesAsync(cancellationToken);
            return OperationResult<bool>.SuccessResult(true);
        }

        public Task<GetSheepCategoryQuery> GetAllSheepCategory(CancellationToken cancellationToken, int pageId = 1, string trim = "")
        {
            throw new NotImplementedException();
        }

        public async Task<EditSheepCategoryCommand> GetDetails(Guid id, CancellationToken cancellationToken)
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

        public Task<IQueryable<SheepCategoryEntity>> GetAllZeroThree(SheepCategoryQuery Command, CancellationToken cancellationToken)
        {
            return _SheepCategoryrepository.GetAllZeroThree(Command, cancellationToken); 
        }

        public IQueryable<SheepCategoryEntity> GetAllThreeSix(SheepCategoryQuery Command, CancellationToken cancellationToken, int PageId = 1)
        {
            return _SheepCategoryrepository.GetAllThreeSix(Command , cancellationToken, PageId);

        }

        public async Task<SheepCategoryEntity> GetSheepCategoryById(Guid id, CancellationToken cancellationToken)
        {
           return await _SheepCategoryrepository.GetByIdAsync(cancellationToken,id);
        }

        public Task<bool> CheckCaluteCategoryPeriod(Guid sheepId, CancellationToken cancellationToken)
        {
            return _SheepCategoryrepository.Exists(x =>x.SheepId==sheepId&&( x.Zero_ThreeCalacute > x.Start_Zero_Three || x.Three_SixCalcute > x.Start_Three_Six ||
            x.Six_EighteenCalcute > x.Start_Six_Eighteen||x.ActiveCategory==CategoryType.Ewe||x.ActiveCategory==CategoryType.Ram));
        }

        public async Task SaveChangeAsync(CancellationToken cancellationToken)
        {
           await _SheepCategoryrepository.SaveChangesAsync(cancellationToken);
        }

        public async Task<OperationResult<bool>> CalcuteSheepCategoryDate(Guid SheepId,DateTime Date , CancellationToken cancellationToken)
        {
            var result=await _SheepCategoryrepository.GetSheepCategoryBySheepId(SheepId, cancellationToken);
            var activeCategory=result.ActiveCategory;
            switch (activeCategory)
            {
                case CategoryType.none:
                    break;
                case CategoryType.Zero_Three:
                    result.End_Zero_Three = Date;
                    result.Three_SixCalcute = Date;
                    result.End_Three_Six = Date;
                    result.Six_EighteenCalcute = Date;
                    result.End_Six_Eighteen = Date;
                    result.Ram_EweCalcute= Date;
                    result.EndRam_Ewe= Date;
                    break;
                case CategoryType.Three_Six:
                    result.End_Three_Six = Date;
                    result.Six_EighteenCalcute = Date;
                    result.End_Six_Eighteen = Date;
                    result.Ram_EweCalcute = Date;
                    result.EndRam_Ewe = Date;
                    break;
                case CategoryType.Six_Eighteen:
                    result.End_Six_Eighteen = Date;
                    result.Ram_EweCalcute = Date;
                    result.Start_Ram_Ewe = Date;
                    break;
                case CategoryType.Ewe:
                    result.EndRam_Ewe = Date;
                    break;
                case CategoryType.Ram:
                    result.EndRam_Ewe = Date;
                    break;
            }
         await   _SheepCategoryrepository.SaveChangesAsync(cancellationToken);
            return OperationResult<bool>.SuccessResult(true);
        }
    }
}
