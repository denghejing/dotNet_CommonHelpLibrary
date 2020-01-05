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
      Startup��Ӧ�ó������ڣ�entry-point��,���������������ã�Configure�������ҽ�Ӧ�ó���Ҫʹ�õķ�������������������Ա������Startup������������ܵ����ùܵ������ڴ���Ӧ�ó������������
    */
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // �˷���������ʱ���á�ʹ�ô˷�����������ӷ���
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        // �˷���������ʱ���á�ʹ�ô˷�������HTTP����ܵ���
        /*
          Configure��������ָ��ASP.NETӦ�ó��������Ӧÿһ��HTTP����
          Configure�����������һ��IApplicationBuilder������һЩ������񣬱���IHostEnvironment��ILoggerFactoryҲ���Ա�ָ�������������ǿ��õ�����£���Щ���񽫻ᱻ������ע�������
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
                //Ĭ�ϵ�HSTSֵ��30�졣������������������иı���һ�㣬
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles(); //��̬�ļ�

            app.UseRouting(); //·��

            app.UseAuthorization(); //�����֤

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
