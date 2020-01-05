using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace dotNet_CommonHelpLibrary
{
    /*
      Startup是应用程序的入口（entry-point）,这个类可以设置配置（Configure），并且将应用程序将要使用的服务连接起来。开发人员可以在Startup类中配置请求管道，该管道将用于处理应用程序的所有请求。
    */
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // 此方法由运行时调用。使用此方法向容器添加服务
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        // 此方法由运行时调用。使用此方法配置HTTP请求管道。
        /*
          Configure方法用于指定ASP.NET应用程序将如何相应每一个HTTP请求。
          Configure方法必须接受一个IApplicationBuilder参数。一些额外服务，比如IHostEnvironment或ILoggerFactory也可以被指定，并且在它们可用的情况下，这些服务将会被服务器注入进来。
        */
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                //默认的HSTS值是30天。你可能想在生产场景中改变这一点，
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles(); //静态文件

            app.UseRouting(); //路由

            app.UseAuthorization(); //身份验证

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
