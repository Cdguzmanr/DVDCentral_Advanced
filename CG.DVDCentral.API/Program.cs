using CG.DVDCentral.API.Hubs;
using CG.DVDCentral.PL2.Data;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

public class Program
{
    private static void Main(string[] args)
    {
        string user = "Carlos";
        string hubAddress = "https://localhost:7112/";

        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddSignalR()
            .AddJsonProtocol(options =>
             {
                options.PayloadSerializerOptions.PropertyNamingPolicy = null;
            });


        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo  
            { 
                Title = "DVDCentral API", 
                Version = "v1",
                Contact = new Microsoft.OpenApi.Models.OpenApiContact
                {
                    Name = "Carlos Guzman",
                    Email = "300083002@fvtc.edu",
                    Url = new Uri("https://www.fvtc.edu")
                }
            });


            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlpath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            c.IncludeXmlComments(xmlpath);


        });
        
        // Add connection string to the container
        builder.Services.AddDbContext<DVDCentralEntities>(options =>
        {
            options.UseSqlServer(builder.Configuration.GetConnectionString("DVDCentralConnection"));
            options.UseLazyLoadingProxies();
        }); 

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment() || true)
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.UseRouting(); // Add SignalR to the request pipeline
        app.UseAuthorization();

        //app.MapControllers();

        // Add SignalR to the request pipeline 
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
            endpoints.MapHub<BingoHub>("/bingoHub");
        });

        app.Run();
    }
}