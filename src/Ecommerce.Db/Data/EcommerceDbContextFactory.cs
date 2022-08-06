using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Db.Data
{
    public class EcommerceDbContextFactory
    {
        private readonly string _connectionString;
        public EcommerceDbContextFactory(string connectionString)
        {
            _connectionString = connectionString;
        }
        public EcommerceDbContext CreateContext(string[] args)
        {
            var options = new DbContextOptionsBuilder<EcommerceDbContext>();
            options.UseNpgsql(_connectionString);
            return new EcommerceDbContext(options.Options);
        }
    }
}
