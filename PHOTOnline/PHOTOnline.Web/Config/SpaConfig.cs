using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using VueCliMiddleware;

namespace PHOTOnline.Web.Config
{
    public static class SpaConfig
    {
        public static void UsePHOTOnlineSpa(
            this IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseVueCli(npmScript: "serve", port: 8080);
                }
            });
        }
    }
}
