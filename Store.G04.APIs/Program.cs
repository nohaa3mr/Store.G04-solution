using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Store.G04.APIs.Errors;
using Store.G04.APIs.ExtensionMethods;
using Store.G04.APIs.Middlewares;
using Store.G04.Core;
using Store.G04.Core.Entities;
using Store.G04.Core.Profiles;
using Store.G04.Core.Repositories.Contract;
using Store.G04.Core.Services.Contract;
using Store.G04.Repositories;
using Store.G04.Repositories.Data;
using Store.G04.Repositories.Data.Contexts;
using Store.G04.Repositories.Repositories;
using Store.G04.Service.Services.Products;

namespace Store.G04.APIs
{
	public class Program
	{
		public static async Task Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.

			builder.Services.AddControllers();
			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();
			builder.Services.AddDbContext<StoreDbContext>(options => { options.UseSqlServer(builder.Configuration.GetConnectionString(name: "DefaultConnection")); });
			builder.Services.ApplicationServer();

			var app = builder.Build();
		    using var Scope = app.Services.CreateScope();
			var services = Scope.ServiceProvider;
			var context = services.GetRequiredService<StoreDbContext>();
			var loggerFactory = services.GetRequiredService<ILoggerFactory>();

			try
			{
			  await	context.Database.MigrateAsync();
			  await StoreDbContextSeed.SeedAsync(context);
			}
			catch(Exception ex)
			{
				var Logger = loggerFactory.CreateLogger<Program>();
				Logger.LogError(ex,"There Are Problems During Execution.");
			}

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseMiddleware<ExceptionMiddleWare>();
				app.UseSwagger();
				app.UseSwaggerUI();
			}
			app.UseStaticFiles();
			app.UseHttpsRedirection();
			app.UseAuthorization();
			app.MapControllers();

			app.Run();
		}

		
	}
}
