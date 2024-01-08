using System.Reflection;
using Wake.Commerce.Application;
using Wake.Commerce.Application.DataServices;
using Wake.Commerce.Shared.Middleware;

public class Program 
{
    public static async Task Main(string[] args) 
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddApplicationServices(builder.Configuration);
        builder.Services.AddControllers();

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();

        builder.Services.AddSwaggerGen(options => 
        {
            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            options.IncludeXmlComments(xmlPath);
        });

        //services cors
        builder.Services.AddCors(p => p.AddPolicy("CorsConfig", builder =>
        {
            builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
        }));

        builder.Services.AddTransient<GlobalExceptionHandlerMiddleware>();

        var app = builder.Build();

        var scopedFactory = app.Services.GetService<IServiceScopeFactory>();

        // configuração da carga inicial de dados
        using (var scope = scopedFactory?.CreateScope())
        {
            var service = scope?.ServiceProvider.GetService<DataSeeder>();

            if (service != null)
                await service.SeedAsync();
        }

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.UseCors("CorsConfig");
        app.UseAuthorization();

        app.MapControllers();

        app.UseGlobalExceptionHandlerMiddleware();

        app.Run();
    }
}