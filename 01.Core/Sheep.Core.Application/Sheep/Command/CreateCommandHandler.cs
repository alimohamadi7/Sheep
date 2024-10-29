using MediatR;
using Sheep.Core.Application.Sheep.Contracts.Repository;
using Sheep.Core.Domain.Sheep.Entities;
using Sheep.Framework.Application.Cotrats.Data;
using Sheep.Framework.Application.Operation;
using System.IO.Pipes;


namespace Sheep.Core.Application.Sheep.Command
{
    public class CreateCommandHandler : IRequestHandler<CreateCommand, OperationResult<bool>>
    {
        private readonly ISheepRepository  _repository;
        public CreateCommandHandler(ISheepRepository repository) { _repository = repository; }
        public async Task<OperationResult<bool>> Handle(CreateCommand request, CancellationToken cancellationToken)
        {
            SheepEntity sheepEntity = new SheepEntity(request.SheepNumber,request.SheepbirthDate,request.Sheepshop,request.ParentId,
                request.SheepState, request.Gender);

          await  _repository.AddAsync(sheepEntity, cancellationToken);
            return OperationResult<bool>.SuccessResult(true);
        }
    }
}
