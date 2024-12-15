using Transactly.Core.Interfaces;
using Transactly.Core.Services;
using Transactly.Data.Data.Contexts;
using Transactly.Data.Data.Repositories;
using Transactly.Data.Interfaces;

namespace Transactly.Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Add CORS policy
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowLocalhost",
                    policy =>
                    {
                        policy.WithOrigins("http://localhost:65105", "https://localhost:65105") // Adjust the origin(s) as needed
                              .AllowAnyMethod()
                              .AllowAnyHeader()
                              .AllowCredentials();
                    });
            });

            // Add database context
            builder.Services.AddDbContext<TransactlyDbContext>();

            // Add scoped dependencies
            builder.Services.AddScoped<IBaseRepository, BaseRepository>();
            builder.Services.AddScoped<UserRepository>();
            builder.Services.AddScoped<AccountRepository>();
            builder.Services.AddScoped<CardRepository>();
            builder.Services.AddScoped<CurrencyRepository>();

            builder.Services.AddScoped<IBaseService, BaseService>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<ICardService, CardService>();
            builder.Services.AddScoped<IAccountService, AccountService>();
            builder.Services.AddScoped<ICurrencyService, CurrencyService>();

            var app = builder.Build();

            // Use default files and static files
            app.UseDefaultFiles();
            app.UseStaticFiles();

            // Enable CORS
            app.UseCors("AllowLocalhost");

            // Configure the HTTP request pipeline
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseRouting();

            app.UseAuthorization();

            // Map controllers
            app.MapControllers();

            // Fallback for single-page applications (SPAs)
            app.MapFallbackToFile("/index.html");

            app.Run();
        }
    }
}
