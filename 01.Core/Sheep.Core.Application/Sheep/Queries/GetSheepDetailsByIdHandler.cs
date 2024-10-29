using MediatR;
using Sheep.Core.Application.Sheep.Command;
using Sheep.Core.Application.Sheep.Contracts.Repository;
using Sheep.Core.Domain.Sheep.Entities;
using Sheep.Framework.Application.Cotrats.Data;
using Sheep.Framework.Application.Operation;


namespace Sheep.Core.Application.Sheep.Queries
{
    public class GetSheepDetailsByIdHandler : IRequestHandler<GetSheepDetailsByIdQuery, OperationResult<EditCommand>>
    {
        private readonly ISheepRepository _sheepRepository;
        public GetSheepDetailsByIdHandler(ISheepRepository sheepRepository)
        {
            _sheepRepository = sheepRepository;
        }

        public async Task<OperationResult<EditCommand>> Handle(GetSheepDetailsByIdQuery request, CancellationToken cancellationToken)
        {
            SheepEntity result = await _sheepRepository.GetByIdAsync(cancellationToken, request.Id);
            EditCommand getSheepDetailsByIdQuery = new EditCommand()
            {
                Id = result.Id,
                Gender = result.Gender,
                ParentId = result.ParentId,
                SheepbirthDate = result.SheepbirthDate,
                SheepNumber = result.SheepNumber,
                Sheepshop = result.Sheepshop,
                SheepState = result.SheepState,
                 
            };

            return OperationResult<EditCommand>.SuccessResult(getSheepDetailsByIdQuery);
        }
    }
}
