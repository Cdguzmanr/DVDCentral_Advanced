using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System.IO;

namespace CG.DVDCentral.PL.Test
{
    [TestClass]
    public class utBase
    {
        protected DVDCentralEntities dc;  // declare the DataContext
        protected IDbContextTransaction transaction;
        private IConfigurationRoot _configuration;
        private DbContextOptions<DVDCentralEntities> options;

        public utBase()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            _configuration = builder.Build();
            options = new DbContextOptionsBuilder<DVDCentralEntities>()
                .UseSqlServer(_configuration.GetConnectionString("DVDCentralConnection"))
                .UseLazyLoadingProxies()
                .Options;

            dc = new DVDCentralEntities(options);
        }


        [TestInitialize]
        public void TestInitialize()
        {
            transaction = dc.Database.BeginTransaction();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            transaction.Rollback();
            transaction.Dispose();
            dc = null;
        }
    }
}
