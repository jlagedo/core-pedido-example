using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Pedido.Infra.Data;
using Pedido.Model.Services;
using Pedido.Infra.Repositories;
using Pedido.Model.Repositories;
using AutoMapper;
using Pedido.Model;
using Pedido.Service.Contracts;

namespace Pedido.Service
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc();

            services.AddDbContext<PedidoContext>(
                options => options.UseSqlServer(
                    Configuration.GetConnectionString("PedidoConn"),
                    b => b.MigrationsAssembly("Pedido.Service")
            ));

            services.AddMemoryCache();

            services.AddScoped<IPedidoCadastroService, PedidoCadastroService>();
            services.AddScoped<IPedidoRepository, PedidoRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();
            app.UseMvc();

            Mapper.Initialize(cfg => cfg.CreateMap<PedidoCadastro, PedidoCadastroDTO>());
        }
    }
}
