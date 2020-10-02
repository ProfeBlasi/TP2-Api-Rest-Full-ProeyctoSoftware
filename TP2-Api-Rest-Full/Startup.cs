using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using AccesData.Context;
using AccesData.Queries;
using AccesData.Repositories;
using AccesData.Repositories.Base;
using Aplication.Services;
using Domain.Interfaces.Queries;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Repositories.Base;
using Domain.Interfaces.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using SqlKata.Compilers;

namespace TP2_Api_Rest_Full
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddMvc();

            var connectionString = Configuration.GetSection("ConnectionString").Value;

            //EF CORE
            services.AddDbContext<Contexto>(opcion => opcion.UseSqlServer(connectionString));


            //SQLKATA
            services.AddTransient<Compiler, SqlServerCompiler>();
            services.AddTransient<IDbConnection>(s =>
            {
                return new SqlConnection(connectionString);
            });

            //SWAGGER
            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new OpenApiInfo { Title = "REST", Version = "v1" });
            });

            services.AddTransient<ILibroRepository, LibroRepository>();
            services.AddTransient<IClienteRepository, ClienteRepository>();

            services.AddTransient<ILibroService, LibroService>();
            services.AddTransient<IClienteService, ClienteService>();

            services.AddTransient<ILibroQuery, LibroQuery>();
            services.AddTransient<IClienteQuery, ClienteQuery>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            //Habilitar swagger
            app.UseSwagger();
            //indica la ruta para generar la configuración de swagger
            app.UseSwaggerUI(s =>
            {
                s.SwaggerEndpoint("/swagger/v1/swagger.json", "REST V1");
                s.RoutePrefix = string.Empty;
            });
        }
    }
}
