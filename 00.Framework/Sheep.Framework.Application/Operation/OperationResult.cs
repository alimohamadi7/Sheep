using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sheep.Framework.Application.Operation
{
    public interface IOperationResult
    {
        bool isSuccedded { get; set; }
        bool IsNotFound { get; set; }
        public string Message { get; set; }
        List<KeyValuePair<string, string>> ErrorMessages { get; set; }
    }
    public class OperationResult<TResult> : IOperationResult
    {
        public TResult? Result { get; set; }

        public bool isSuccedded { get; set; }
        public bool IsNotFound { get; set; }
        public string Message { get; set; }
        public List<KeyValuePair<string, string>> ErrorMessages { get; set; } = new();


        public static OperationResult<TResult> SuccessResult(TResult result, string message = "عملیات با موفقیت انجام شد")
        {
            return new OperationResult<TResult>()
            {
                Result = result,
                isSuccedded = true,
                Message = message
            };
        }

        public static OperationResult<TResult> FailureResult(string propertyName, string message)
        {
            var result = new OperationResult<TResult>
            {
                Result = default
            };

            result.ErrorMessages.Add(new(propertyName, message));
            return result;
        }

        public static OperationResult<TResult> FailureResult(List<KeyValuePair<string, string>> errors)
        {
            return new OperationResult<TResult>
            {
                Result = default,
                ErrorMessages = errors
            };
        }
        public static OperationResult<TResult> DomainFailureResult(string errorMessage)
        {
            return new OperationResult<TResult>
            {
                Result = default,
                ErrorMessages = new(new List<KeyValuePair<string, string>>() { new("DomainError", errorMessage) })
            };
        }


        public static OperationResult<TResult> NotFoundResult(string propertyName, string message)
        {
            var result = new OperationResult<TResult>
            {
                Result = default,
                IsNotFound = true
            };

            result.ErrorMessages.Add(new(propertyName, message));
            return result;
        }
    }
}
