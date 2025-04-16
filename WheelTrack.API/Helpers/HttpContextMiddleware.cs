using WheelTrack.Core.Common;
using WheelTrack.Core.DTO;
using WheelTrack.Core.ErrorManagement;

namespace WheelTrack.API.Helpers
{
    public class HttpContextMiddleware
    {
        private readonly RequestDelegate _next;

        public HttpContextMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {

            ActionContextDto _actionContext = new ActionContextDto();

            bool ret = false;

            ret = SetBasicParams(context, _actionContext);

            if (ret == false)
                return;

            SetActionContext(context, _actionContext);
            AddResponseHeaders(context, _actionContext);
            await _next.Invoke(context);
            
        }

        private bool SetBasicParams(HttpContext context, ActionContextDto _actionContext)
        {
            int org = 0;
            int user = 0;
            Error error = new Error();
            var orgHeader = context.Request.Headers[HttpHeaderKeys.Org];
            var loginUserHeader = context.Request.Headers[HttpHeaderKeys.User];
            var instanceCodeHeader = context.Request.Headers[HttpHeaderKeys.InstanceCode];

            string instanceCodeHeader_string = instanceCodeHeader;
            string orgHeader_string = orgHeader;
            string loginUserHeader_string = loginUserHeader;


            if (orgHeader_string == null || orgHeader == "")
            {
                context.Response.StatusCode = 400; //Bad Request  
                error.error_code = "PARAM_MISSED";
                error.error_message = "Org missed";
                
                context.Response.WriteAsJsonAsync(error);
                return false;
            }

            if (!int.TryParse(orgHeader, out org))
            {
                context.Response.StatusCode = 400; //Bad Request  
                error.error_code = "INVALID_PARAM";
                error.error_message = "Invalid Org";
                context.Response.WriteAsJsonAsync(error);
                return false;
            }

            if (loginUserHeader_string == null || loginUserHeader == "")
            {
                context.Response.StatusCode = 400; //Bad Request
                error.error_code = "PARAM_MISSED";
                error.error_message = "User missed";
                context.Response.WriteAsJsonAsync(error);
                return false;
            }

            if (!int.TryParse(loginUserHeader, out user) || user == 0)
            {
                //throw new Exception("Invalid User");
                context.Response.StatusCode = 400; //Bad Request  
                error.error_code = "INVALID_PARAM";
                error.error_message = "Invalid User";
                context.Response.WriteAsJsonAsync(error);
                return false;
            }

            if (instanceCodeHeader_string == null || instanceCodeHeader == "")
            {
                context.Response.StatusCode = 400; //Bad Request  
                error.error_code = "PARAM_MISSED";
                error.error_message = "Instance code missed";
                context.Response.WriteAsJsonAsync(error);
                return false;
            }

            

            _actionContext.Org = org;
            _actionContext.User = user;
            _actionContext.Instance_code = instanceCodeHeader_string;
            return true;
        }

        private void SetActionContext(HttpContext context, ActionContextDto _actionContext)
        {
            context.Items.Add(ConstantKeys.ActionContext, _actionContext);
        }

        private void AddResponseHeaders(HttpContext context, ActionContextDto _actionContext)
        {
            context.Response.OnStarting(() =>
            {
                context.Response.Headers.Add("unique-request-id", _actionContext.UniqueRequestId);
                return Task.FromResult(0);
            });
        }
    }
}
