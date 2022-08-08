using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using Volo.Abp;

namespace Ecommerce.DbMigrator
{
    public class DbMigratorHostService : IHostedService
    {
        private readonly IHostApplicationLifetime _applicationLifetime;
        private readonly IConfiguration _configuration;
        public DbMigratorHostService(IHostApplicationLifetime hostApplicationLifetime, IConfiguration configuration)
        {
            _applicationLifetime = hostApplicationLifetime;
            _configuration = configuration;
        }
        public async Task StartAsync(CancellationToken cancellationToken)
        {
            using (var app = await AbpApplicationFactory.CreateAsync<DbMigratorModule>(options =>
            {
                options.Services.ReplaceConfiguration(_configuration);                
                options.Services.AddLogging(c => c.AddSerilog());
            }))
            {
                await app.InitializeAsync();
            }           
            _applicationLifetime.StopApplication();
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
