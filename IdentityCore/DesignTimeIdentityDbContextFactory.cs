using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CoreOwin.IdentityCore
{

    /// <summary>
    ///  burada appsettings den connection bilgisini alıp eğer db oluşturulmadıysa migration oluşturulması için yazıldı
    /// </summary>
    public class DesignTimeIdentityDbContextFactory : IDesignTimeDbContextFactory<testDBContext>
    {


        public testDBContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
              .SetBasePath(Directory.GetCurrentDirectory())
              .AddJsonFile("appsettings.json")
              .Build();

            var builder = new DbContextOptionsBuilder<testDBContext>();
            var connectionstring = configuration.GetConnectionString("DefaultConnection");
            builder.UseSqlServer(connectionstring);
            return new testDBContext(builder.Options);

        }
    }
}
