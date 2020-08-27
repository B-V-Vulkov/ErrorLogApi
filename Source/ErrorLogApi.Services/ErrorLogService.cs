namespace ErrorLogApi.Services
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Contracts;
    using Data;
    using ErrorLogApi.Services.Models.ErrorLog;

    public class ErrorLogService : IErrorLogService
    {
        private readonly IErrorLogDbContext dbContext;

        public ErrorLogService(IErrorLogDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task InsertErrorLogAsync(ErrorLogServiceModel errorLog)
        {
            await dbContext.LogCollection.InsertOneAsync(new Data.Models.ErrorLogDataModel()
            {
                ErrorDateTime = DateTime.UtcNow,
                Url = "http://api2.dnevnik.as/api/Exam/UpdateExam",
                SchoolId = "299999912",
                UserId = "67009012",
                ControllerName = "Exam",
                ActionName = "UpdateExamAsync",
                ExceptionMessage = "Invalid Database Operation",
                InnerExceptionMessage = @"Procedure or function 'ExamUpdate' expects parameter '@SessionId', which was not supplied.
 - StackTrace: at ClassBook.Services.DapperService.< ExecuteFirstAsync > d__0`1.MoveNext() in \\10.10.0.11\www\Classbook\ClassbookApi\ClassBook.Services\DapperService.cs:line 35
     -- - End of stack trace from previous location where exception was thrown-- -
     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()
     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
     at System.Runtime.CompilerServices.TaskAwaiter`1.GetResult()
     at ClassBook.Controllers.ExamController.< UpdateExamAsync > d__22.MoveNext() in \\10.10.0.11\www\Classbook\ClassbookApi\ClassBookApi\Controllers\ExamController.cs:line 190
     -- - End of stack trace from previous location where exception was thrown-- -
     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()
     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
     at System.Threading.Tasks.TaskHelpersExtensions.< CastToObject > d__1`1.MoveNext()
     -- - End of stack trace from previous location where exception was thrown-- -
     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()
     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
     at System.Web.Http.Controllers.ApiControllerActionInvoker.< InvokeActionAsyncCore > d__1.MoveNext()
     -- - End of stack trace from previous location where exception was thrown-- -
     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()
     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
     at System.Web.Http.Filters.ActionFilterAttribute.< CallOnActionExecutedAsync > d__6.MoveNext()
     -- - End of stack trace from previous location where exception was thrown-- -
     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()
     at System.Web.Http.Filters.ActionFilterAttribute.< CallOnActionExecutedAsync > d__6.MoveNext()
     -- - End of stack trace from previous location where exception was thrown-- -
     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()
     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
     at System.Web.Http.Filters.ActionFilterAttribute.< ExecuteActionFilterAsyncCore > d__5.MoveNext()
     -- - End of stack trace from previous location where exception was thrown-- -
     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()
     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
     at System.Web.Http.Controllers.ActionFilterResult.< ExecuteAsync > d__5.MoveNext()
     -- - End of stack trace from previous location where exception was thrown-- -
     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()
     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
     at System.Web.Http.Filters.AuthorizationFilterAttribute.< ExecuteAuthorizationFilterAsyncCore > d__3.MoveNext()
     -- - End of stack trace from previous location where exception was thrown-- -
     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()
     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
     at System.Web.Http.Controllers.AuthenticationFilterResult.< ExecuteAsync > d__5.MoveNext()
     -- - End of stack trace from previous location where exception was thrown-- -
     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()
     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
     at System.Web.Http.Controllers.ExceptionFilterResult.< ExecuteAsync > d__6.MoveNext()",
                RequestHeaders = new List<Data.Models.RequestHeaderDataModel>()
                {
                    { new Data.Models.RequestHeaderDataModel(){ Header =  "Cache-Control", Value = "no-cache" } }
                },
                RequestPeyload = @"dsgfgfdgdfgdfgdfgfdg"
            });
        }
    }
}
