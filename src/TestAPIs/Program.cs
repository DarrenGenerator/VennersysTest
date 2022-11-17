using TestAPIs.CustomerDb;
using TestAPIs.CustomerDb.Interfaces;
using TestAPIs.Interfaces;
using TestAPIs.Services;

namespace TestAPIs
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Links
            // Test on http://localhost:1051/WeatherForecast
            // Swagger http://localhost:1051/swagger/index.html
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            var allowedOrigins = "allowedOrigins";

            var builder = WebApplication.CreateBuilder(args);

            //local test db
            using (CustomerContext context = new())
            {
                context.Database.EnsureCreated();  
            };

            builder.Services.AddCors(options =>
            {
                options.AddPolicy(name: allowedOrigins,
                                  policy =>
                                  {
                                      policy.WithOrigins("https://localhost:7228");
                                      policy.AllowAnyHeader();
                                      policy.AllowAnyMethod();
                                  });
            });


            // Add services
            builder.Services.AddTransient<ICustomerContext, CustomerContext>();
            builder.Services.AddTransient<ICustomerServices, CustomerServices>();

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            app.UseCors(allowedOrigins);

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