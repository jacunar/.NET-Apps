using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;

namespace NorthWind.WebExceptionsPresenter {
    public class ApiExceptionFilterAttribute : ExceptionFilterAttribute {
        readonly IDictionary<Type, IExceptionHandler> ExceptionsHandlers;

        public ApiExceptionFilterAttribute(IDictionary<Type, IExceptionHandler> exceptionsHandlers) =>
            ExceptionsHandlers = exceptionsHandlers;

        public override void OnException(ExceptionContext context) {
            Type ExceptionType = context.Exception.GetType();
            if (ExceptionsHandlers.ContainsKey(ExceptionType)) {
                ExceptionsHandlers[ExceptionType].Handle(context);
            } else {
                new ExceptionHandlerBase().SetResult(context,
                    StatusCodes.Status500InternalServerError, 
                    "Ha ocurrido un error al procesar la respuesta.", "");
            }
            base.OnException(context);
        }
    }
}