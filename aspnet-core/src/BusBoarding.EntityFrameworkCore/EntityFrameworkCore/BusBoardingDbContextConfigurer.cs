using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace BusBoarding.EntityFrameworkCore
{
    public static class BusBoardingDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<BusBoardingDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<BusBoardingDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
