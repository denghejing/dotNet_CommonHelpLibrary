using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace dotNet_CommonHelpLibrary
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //启动监听HTTP请求
            //build和run方法生成IWebHost对象，改对象托管应用并开始侦听Http请求
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
        //创建web应用程序宿主
        /*
           webHostBuilder的useStartup方法为你的应用指定startUp类
           Startup类可用来定义请求处理管道和配置应用需要的服务，Startup类必须是公开（public）,并且必须包含以下方法：ConfigureServices、  Configure
           ConfigureServices方法用于定义你的应用所使用的服务（例如ASP.NET Core MVC、EntityFramework Core、Identity等）
           Configure 方法用于定义你的请求管道中的中间件
         */

    }
}
