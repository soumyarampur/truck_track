using WheelTrack.API.Helpers;

namespace WheelTrack.API.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseMiddleware(this IApplicationBuilder builder)
        {
            return builder
                 .UseMiddleware<HttpContextMiddleware>();
                
        }
    }
}
