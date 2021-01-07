using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FakeXiecheng.API.Database;
using FakeXiecheng.API.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace FakeXiecheng.API
{
    public class Startup
    {
        // 配置依赖注入服务，创建一个私有变量存储配置信息。
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers(setupAction => {
                setupAction.ReturnHttpNotAcceptable = true; // 内容协商（HTTP 请求头）
                //setupAction.OutputFormatters.Add(
                //new XmlDataContractSerializerOutputFormatter() // 方式1：添加对XML的Output的支持
                //);
            }).AddXmlDataContractSerializerFormatters(); //  方式2：添加对XML的Output和Input的支持
            // 注册数据仓库的服务依赖
            services.AddTransient<ITouristRouteRepository, TouristRouteRepository>();
            // 向IOC容器中注入Db对象
            services.AddDbContext<AppDbContext>(option => {
                //option.UseSqlServer("server=localhost; Database=FakeXiechengDb; User Id=sa; Password=PaSSword12!;");
                option.UseSqlServer(Configuration["DbContext:ConnectionString"]);
                //option.UseMySql(Configuration["DbContext:MySQLConnectionString"]);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
