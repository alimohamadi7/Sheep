using MediatR;
using Sheep.Core.Application.Sheep.Contracts.Repository;
using Sheep.Framework.Application.Operation;


namespace Sheep.Core.Application.Sheep.Queries
{
    public class GetSheepQueryHandler : IRequestHandler<GetSheepQuery, OperationResult<GetSheepQuery>>
    {
        private readonly ISheepRepository _sheepRepository;
        public GetSheepQueryHandler(ISheepRepository sheepRepository)
        {
            _sheepRepository = sheepRepository;
        }

        public async Task<OperationResult<GetSheepQuery>> Handle(GetSheepQuery request, CancellationToken cancellationToken)
        {
            var result = await _sheepRepository.GetAll(cancellationToken,request.PageId,request.trim);
            return OperationResult<GetSheepQuery>.SuccessResult(result);
        }


    }
}
