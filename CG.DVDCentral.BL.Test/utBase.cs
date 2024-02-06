

namespace CG.DVDCentral.BL.Test
{
    [TestClass]
    public abstract class utBase
    {
        protected DVDCentralEntities dc;
        protected IDbContextTransaction transaction;
        private IConfigurationRoot _configuration;

        // represent the database configuration
        protected DbContextOptions<DVDCentralEntities> options;

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
