using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DbMigrator
{
    public class DbMigratorHostService : IHostedService
    {
        private readonly IHostApplicationLifetime _applicationLifetime;
        public DbMigratorHostService(IHostApplicationLifetime hostApplicationLifetime)
        {
            _applicationLifetime = hostApplicationLifetime;
        }
        public async Task StartAsync(CancellationToken cancellationToken)
        {

            _applicationLifetime.StopApplication();
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
