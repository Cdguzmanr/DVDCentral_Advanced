using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using CG.DVDCentral.API.Hubs;
using CG.DVDCentral.PL2.Data;
using Microsoft.Azure.KeyVault;
using Microsoft.Azure.KeyVault.Models;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Ui.MsSqlServerProvider;
using Serilog.Ui.Web;
using System;
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

        string connectionString = GetSecret("DVDCentral-ConnectionString").Result;

        // Add connection string to the container

        builder.Services.AddDbContext<DVDCentralEntities>(options =>
        {
            //options.UseSqlServer(builder.Configuration.GetConnectionString("DVDCentralConnection"));
            options.UseSqlServer(connectionString);
            options.UseLazyLoadingProxies();
        });

        var configSettings = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();

        Log.Logger = new LoggerConfiguration()
            .ReadFrom.Configuration(configSettings)
            .CreateLogger();

        builder.Services
            .AddLogging(c => c.AddDebug())
            .AddLogging(c => c.AddSerilog())
            .AddLogging(c => c.AddEventLog())
            .AddLogging(c => c.AddConsole());

        var app = builder.Build();

        app.UseSerilogUi(options =>
        {
            options.RoutePrefix = "logs";
        });

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

    public static async Task<string> GetSecret(string secretName)
    {
        try
        {
            //const string secretName = "DVDCentral-ConnectionString";
            var keyVaultName = "kv-31590";
            var kvUri = $"https://{keyVaultName}.vault.azure.net";

            var client = new SecretClient(new Uri(kvUri), new DefaultAzureCredential());
            //using var client = GetClient();
            var secret = await client.GetSecretAsync(secretName);
            Console.WriteLine(secret.Value.Value.ToString());
            return secret.Value.Value.ToString();
            //return (await client.GetSecretAsync(kvUri, secretName)).Value.ToString();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return null;
        }
    }
}