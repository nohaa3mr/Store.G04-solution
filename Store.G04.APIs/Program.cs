using Microsoft.EntityFrameworkCore;
using Store.G04.Repositories.Data.Contexts;

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

			var app = builder.Build();
		    using var Scope = app.Services.CreateScope();
			var services = Scope.ServiceProvider;
			var context = services.GetRequiredService<StoreDbContext>();
		await	context.Database.MigrateAsync();

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseHttpsRedirection();

			app.UseAuthorization();


			app.MapControllers();

			app.Run();
		}

		
	}
}
