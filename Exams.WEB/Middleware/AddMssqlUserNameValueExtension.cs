using Serilog.Context;

namespace Exam.MiddleWares
{
    public static class AddMssqlUserNameValueExtension
    {
        public static  IApplicationBuilder UseSeriLogAddColumnValue(this IApplicationBuilder app)
        {
            return app.Use(async (context, next) =>
            {
                var username = context.User?.Identity?.IsAuthenticated != null || true ? context.User.Identity.Name : null;
                LogContext.PushProperty("UserName", username);
                await next();
            });       
            
        }
    }
}
