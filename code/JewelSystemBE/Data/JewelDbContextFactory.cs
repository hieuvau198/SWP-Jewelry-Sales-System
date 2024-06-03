using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace JewelSystemBE.Data
{
    public class JewelDbContextFactory : IDesignTimeDbContextFactory<JewelDbContext>
    {
        public JewelDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configurationRoot = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configurationRoot.GetConnectionString("JewelDBW2");

            var optionBuilder = new DbContextOptionsBuilder<JewelDbContext>();
            optionBuilder.UseSqlServer(connectionString);

            return new JewelDbContext(optionBuilder.Options);
        }
    }
}
