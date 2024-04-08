using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace FinalProject.Infrastructure.EFCore
{
    internal class WaigayaDbContext : DbContext
    {
        public WaigayaDbContext(DbContextOptions<WaigayaDbContext> options)
            : base(options)
        { }

        public class WaigayaDbContextFactory : IDesignTimeDbContextFactory<WaigayaDbContext>
        {
            public WaigayaDbContext CreateDbContext(string[] args)
            {
                var builder = new SqlConnectionStringBuilder();
                builder.DataSource = @"(localdb)\EFCoreDB";
                builder.InitialCatalog = "HogeHogeTest";
                builder.IntegratedSecurity = true;
                var o = new DbContextOptionsBuilder<WaigayaDbContext>();
                o.UseSqlServer(builder.ConnectionString);
                return new WaigayaDbContext(o.Options);
            }
        }
    }
}
