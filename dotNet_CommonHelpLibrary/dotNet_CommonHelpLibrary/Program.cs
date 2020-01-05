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
            //��������HTTP����
            //build��run��������IWebHost���󣬸Ķ����й�Ӧ�ò���ʼ����Http����
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
        //����webӦ�ó�������
        /*
           webHostBuilder��useStartup����Ϊ���Ӧ��ָ��startUp��
           Startup�����������������ܵ�������Ӧ����Ҫ�ķ���Startup������ǹ�����public��,���ұ���������·�����ConfigureServices��  Configure
           ConfigureServices�������ڶ������Ӧ����ʹ�õķ�������ASP.NET Core MVC��EntityFramework Core��Identity�ȣ�
           Configure �������ڶ����������ܵ��е��м��
         */

    }
}
