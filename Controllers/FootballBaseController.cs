using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Runtime.CompilerServices;

namespace FootballAPI.Controllers
{
    public abstract class FootballBaseController : ControllerBase
    {
        protected readonly ILogger _logger;

        public FootballBaseController(ILogger logger)
        {
            _logger = logger;
        }

        protected void Do(Action todo, [CallerMemberName] string method = null)
        {
            try
            {
                _logger.LogTrace("Calling {Method}", method);
                todo();
                _logger.LogTrace("Calling {Method} complete", method);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }

        protected T Do<T>(Func<T> todo, [CallerMemberName] string method = null)
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
                throw;
            }
        }
    }
}
