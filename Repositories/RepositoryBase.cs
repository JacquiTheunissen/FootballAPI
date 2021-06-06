using FootballAPI.Models.Common;
using Microsoft.Extensions.Logging;
using System;
using System.Runtime.CompilerServices;

namespace FootballAPI.Repositories
{
    public abstract class RepositoryBase
    {
        protected readonly ILogger _logger;

        public RepositoryBase(ILogger logger)
        {
            _logger = logger;
        }

        protected T Do<T>(Func<T> todo, [CallerMemberName] string method = null) where T : OperationOutcome, new()
        {
            try
            {
                _logger.LogTrace("Calling {Method}", method);
                T result = todo();
                _logger.LogTrace("Calling {Method} complete", method);
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return FailedOutcome<T>(ex.Message);
            }
        }

        protected T FailedOutcome<T>(string errors) where T : OperationOutcome, new()
        {
            return new T
            {
                IsSuccessful = false,
                Errors = errors,
            };
        }

        protected OperationOutcome SuccessfulOutcome()
        {
            return new OperationOutcome
            {
                IsSuccessful = true,
            };
        }

        protected CreateOperationOutcome SuccessfulCreatedOutcome(Guid generatedIdentifier)
        {
            return new CreateOperationOutcome
            {
                GeneratedIdentifier = generatedIdentifier,
                IsSuccessful = true,
            };
        }

        protected QueryOutcome<T> SuccessfulQuery<T>(T data)
        {
            return new QueryOutcome<T>
            {
                Data = data,
                IsSuccessful = true,
            };
        }
    }
}
