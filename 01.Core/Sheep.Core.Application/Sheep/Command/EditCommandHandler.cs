using MediatR;
using Sheep.Framework.Application.Operation;


namespace Sheep.Core.Application.Sheep.Command
{
    public class EditCommandHandler : IRequestHandler<EditCommand, OperationResult<bool>>
    {
        public Task<OperationResult<bool>> Handle(EditCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
