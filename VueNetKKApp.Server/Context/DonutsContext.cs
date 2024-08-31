using Microsoft.EntityFrameworkCore;
using VueNetKKApp.Server.Models;

namespace VueNetKKApp.Server.Context
{
    public class DonutsContext : DbContext
    {
        private readonly String strConectionString = "server=localhost; database=donuts; user=root; password=archer0123";

        //-------------------------------------------------------------------------------------------------------------
        public DonutsContext(DbContextOptions<DonutsContext> options) : base(options)
        {
        }

        //-------------------------------------------------------------------------------------------------------------
        public DonutsContext()
        {
        }

        //-------------------------------------------------------------------------------------------------------------
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(strConectionString,
                ServerVersion.AutoDetect(strConectionString));
        }

        //-------------------------------------------------------------------------------------------------------------
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //                                              // (1 : n) relation from Donut entity
            //                                              // to Sale entity
            modelBuilder.Entity<DonutEntity>()
                .HasMany(d => d.IcSaleEntity)
                .WithOne(s => s.DonutEntity)
                .HasForeignKey(s => s.intPkDonut);

            //                                              // (1 : n) relation from Auth entity
            //                                              // to Sale entity
            modelBuilder.Entity<AuthEntity>()
                .HasMany(a => a.IcSaleEntity)
                .WithOne(s => s.AuthEntity)
                .HasForeignKey(s => s.intPkAuth);

            //                                              // (1 : 1) relation from Auth entity
            //                                              // to User entity
            modelBuilder.Entity<AuthEntity>()
                .HasOne(a => a.UserEntity)
                .WithOne(u => u.AuthEntity)
                .HasForeignKey<UserEntity>(u => u.intPkAuth);

            base.OnModelCreating(modelBuilder);
        }

        //-------------------------------------------------------------------------------------------------------------

        public DbSet<DonutEntity> DonutEnity { get; set; }
        public DbSet<AuthEntity> AuthEntity { get; set; }
        public DbSet<UserEntity> UserEntity { get; set; }
        public DbSet<SaleEntity> SaleEntity { get; set; }
    }
}