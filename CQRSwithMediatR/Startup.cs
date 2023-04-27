using CQRSwithMediatR.Context;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace CQRSwithMediatR
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

            //services.AddDbContext<ApplicationContext>();

            //services.AddControllers();
            //services.AddSwaggerGen(c =>
            //{
            //    c.SwaggerDoc("v1", new OpenApiInfo { Title = "CQRSwithMediatR", Version = "v1" });
            //    c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());

            //});

            //// Spójrzcie na implementacjê Poleceñ/Zapytañ ¿eby rozwiaæ wszelkie w¹tpliwoœci
            //services.AddScoped<IApplicationContext>(provider => provider.GetService<ApplicationContext>());

            //services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddDbContext<ApplicationContext>();

			services.AddControllers();
			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo { Title = "CQRSwithMediatR", Version = "v1" });
				c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
			});

			// Spójrzcie na implementacjê Poleceñ/Zapytañ ¿eby rozwiaæ wszelkie w¹tpliwoœci
			services.AddScoped<IApplicationContext>(provider => provider.GetService<ApplicationContext>());

			services.AddMediatR(Assembly.GetExecutingAssembly());

            // to generate
            services.AddSwaggerDocument();

			services.AddCors();

		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();

				//swagger usage 
				//app.UseSwagger();

				app.UseOpenApi(); // serve documents (same as app.UseSwagger())

				//app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CQRSwithMediatR v1"));

				app.UseSwaggerUI(c =>
				{
					c.SwaggerEndpoint("/swagger/v1/swagger.json", "CQRSwithMediatR v1"); //originally "./swagger/v1/swagger.json"
				});
			}

			app.UseHttpsRedirection();

			app.UseCors(builder =>
			{
				builder
				.AllowAnyOrigin()
				.AllowAnyMethod()
				.AllowAnyHeader();
			});

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
