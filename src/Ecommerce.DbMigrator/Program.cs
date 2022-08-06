using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Ecommerce.Db.Data;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.DbMigrator
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .CreateLogger();
            await CreateHostBuilder(args).RunConsoleAsync();
        }
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureLogging((logging) => logging.ClearProviders())
                .ConfigureServices((context,services) =>
                {
                    //services.AddHostedService<DbMigratorHostService>();
                    services.AddLogging(c => c.AddSerilog());
                    services.AddDbContext<EcommerceDbContext>(o => o.UseNpgsql(context.Configuration.GetConnectionString("Default")));
                    services.AddSingleton<EcommerceDbContextFactory>(new EcommerceDbContextFactory(context.Configuration.GetConnectionString("Default")));                    
                });
    }
}
