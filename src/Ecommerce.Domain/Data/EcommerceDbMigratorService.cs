using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Volo.Abp.DependencyInjection;

namespace Ecommerce.Domain.Data
{
    public class EcommerceDbMigratorService : ITransientDependency
    {
        private ILogger<EcommerceDbMigratorService> _logger;
        public EcommerceDbMigratorService()
        {
            _logger = NullLogger<EcommerceDbMigratorService>.Instance;
        }
        public async Task MigrationAsync()
        {
            var initial = AddInitialMigrationIfNotExist();
        }

        private bool AddInitialMigrationIfNotExist()
        {
            return true;
        }
    }
}
