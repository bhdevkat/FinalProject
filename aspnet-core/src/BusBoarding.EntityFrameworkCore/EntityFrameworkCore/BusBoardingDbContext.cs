using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using BusBoarding.Authorization.Roles;
using BusBoarding.Authorization.Users;
using BusBoarding.MultiTenancy;
using BusBoardingSystem.Domain;

namespace BusBoarding.EntityFrameworkCore
{
    public class BusBoardingDbContext : AbpZeroDbContext<Tenant, Role, User, BusBoardingDbContext>
    {
        /* Define a DbSet for each entity of the application */
        public DbSet<Boarding> Boardings { get; set; }
        public DbSet<Bus> Buses { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Staff> Staff { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Trip> Trips { get; set; }
        public BusBoardingDbContext(DbContextOptions<BusBoardingDbContext> options)
            : base(options)
        {
        }
    }
}
