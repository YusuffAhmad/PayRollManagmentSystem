//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Design;
//using Microsoft.Extensions.Configuration;
//using System.IO;

//namespace SimplePayRollApplication.Context
//{
//    public class PayRollDbContextFactory : IDesignTimeDbContextFactory<ApplicationContext>
//    {
//        public ApplicationContext CreateDbContext(string[] args)
//        {
//            IConfigurationRoot configuration = new ConfigurationBuilder()
//               .SetBasePath(Directory.GetCurrentDirectory())
//               .AddJsonFile("appsettings.json")
//               .Build();

//            var builder = new DbContextOptionsBuilder<ApplicationContext>();
//            var connectionString = configuration.GetConnectionString("DefaultConnection");

//            builder.UseMySql(ServerVersion.AutoDetect(connectionString));

//            return new ApplicationContext(builder.Options);
//        }
//    }
//}
