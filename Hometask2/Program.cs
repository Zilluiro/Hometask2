using BusinessLayer.Services.Implementations;
using BusinessLayer.Services.Interfaces;
using DataAccessLayer;
using DataAccessLayer.Repositories.Implementations;
using DataAccessLayer.Repositories.Interfaces;
using Hometask2.Configurations;
using Hometask2.Middlewares;
using Microsoft.AspNetCore.HttpLogging;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using static System.Net.Mime.MediaTypeNames;

namespace Hometask2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseInMemoryDatabase("RadencyHomeTask2"));
            builder.Services.AddControllers();

            builder.Services.AddScoped<IBookRepository, BookRepository>();
            builder.Services.AddScoped<IReviewRepository, ReviewRepository>();
            builder.Services.AddScoped<IRatingRepository, RatingRepository>();

            builder.Services.AddScoped<IRecommendationsService, RecommendationsService>();
            builder.Services.AddScoped<IBookService, BookService>();
            builder.Services.AddScoped<IReviewService, ReviewService>();
            builder.Services.AddScoped<IRatingService, RatingService>();

            using var serviceProvider = builder.Services.BuildServiceProvider();
            DataGenerator.Initialize(serviceProvider);

            var confSection = builder.Configuration.GetSection("Secrets");
            builder.Services.Configure<SecretsConfiguration>(confSection);

            builder.Services.AddHttpLogging(httpLogging =>
            {
                httpLogging.LoggingFields = HttpLoggingFields.All;
            });

            var app = builder.Build();

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.ConfigureExceptionHandler();
            app.UseHttpLogging();

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            app.Run();
        }
    }
}