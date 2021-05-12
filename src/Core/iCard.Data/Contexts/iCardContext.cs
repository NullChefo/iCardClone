using System;
using iCard.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


namespace iCard.Data.Contexts
{
    public class ICardContext : DbContext
    {
        private  string connectionString = "Host=localhost:5432;Database=icardcloneapp;Username=applogin;Password=1234";
        

        public DbSet<User> Users { get; set; }
        public DbSet<Plan> Plan { get; set; }
        public DbSet<Account> Account { get; set; }
        public DbSet<Settings> Settings { get; set; }
        public DbSet<VirtualCard> VirtualCards { get; set; }
        public DbSet<TransactionHistory> TransactionHistories { get; set; }

        
      
         

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(connectionString);
           
        }
        
       
       
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VirtualCard>().ToTable("VirtualCard");

            modelBuilder.Entity<TransactionHistory>().ToTable("TransactionHistory");

            modelBuilder.Entity<Settings>().ToTable("Settings");

            modelBuilder.Entity<Plan>().ToTable("Plan");

            modelBuilder.Entity<Account>().ToTable("Account");


            modelBuilder.Entity<User>().ToTable("User")
                .HasOne(user => user.Account);


            modelBuilder.Entity<Account>().HasMany<VirtualCard>(acc => acc.VirtualCards)
                .WithOne(vc => vc.Account)
                .HasForeignKey(vc => vc.AccountId);


            modelBuilder.Entity<Account>()
                .HasMany<TransactionHistory>(acc => acc.Transactions)
                .WithOne(th => th.Account)
                .HasForeignKey(th => th.AccountId);


            modelBuilder.Entity<Account>()
                .HasOne<Settings>(acc => acc.Settings);


            modelBuilder.Entity<Account>()
                .HasOne<Plan>(acc => acc.Plan);
        }
    }
}