using Microsoft.AspNetCore.Builder;

namespace PHOTOnline.Web.Config
{
    public static class MvcConfig
    {
        public static void UsePHOTOnlineMvc(this IApplicationBuilder app)
        {
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default_api_route",
                    template: "api/{controller}/{action}/{id?}");
				// routes.MapRoute(
                    // name: "default_api_route",
                    // template: "api/{controller}/{action}/{file?}");
                routes.MapRoute(
                    name: "default_route",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}