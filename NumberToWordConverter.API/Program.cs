
using NumberToWordConverter.API.Middleware;
using NumberToWordConverter.Application.IService;
using NumberToWordConverter.Application.Service;

namespace NumberToWordConverter.API
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.

			builder.Services.AddScoped<INumberToWordService, NumberToWordService>(p => {
				var config = p.GetRequiredService<IConfiguration>();
				var placeValues = new Dictionary<int, string>();
				config.GetSection("PlaceValues").Bind(placeValues);
				var numberToWordService = new NumberToWordService(placeValues);
				return numberToWordService;
			});

			builder.Services.AddControllers();
			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();
			builder.Services.AddExceptionHandler<NumberToWordExceptionHandler>();
			
			//builder.Services.AddCors(options =>
			//{
			//	options.AddPolicy(name: MyAllowSpecificOrigins,
			//			policy =>
			//			{
			//				policy.AllowAnyOrigin()   // Allow requests from any origin (use specific origins in production)
			//					.AllowAnyMethod()   // Allow all HTTP methods (GET, POST, etc.)
			//					.AllowAnyHeader();  // Allow all headers
			//			});
			//});

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}
			app.UseStaticFiles();
			app.UseExceptionHandler(_ => { });
			app.UseHttpsRedirection();

			app.UseCors(MyAllowSpecificOrigins);
			app.UseAuthorization();


			app.MapControllers();

			app.Run();
		}
	}
}
