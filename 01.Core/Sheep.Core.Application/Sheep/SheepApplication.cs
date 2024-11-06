﻿using Sheep.Core.Application.Sheep.Contracts;
using Sheep.Core.Application.Sheep.Contracts.Repository;
using Sheep.Framework.Application.Operation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sheep.Core.Application.Sheep
{
    public class SheepApplication : ISheepApplication
    {
        private readonly ISheepRepository _sheepRepository;
        public SheepApplication( ISheepRepository sheepRepository)
        {
            _sheepRepository = sheepRepository;
        }
        public Task<OperationResult<bool>> Create(CreateCommand command, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<bool>> Delete(long id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<EditCommand>> Edit(EditCommand command, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<OperationResult<GetSheepQuery>> GetAllSheep(CancellationToken cancellationToken, int pageId = 1, string trim = "")
        {;
            return await _sheepRepository.GetAll(cancellationToken, pageId, trim);
        }

        public Task<OperationResult<EditCommand>> GetDetails(long id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
