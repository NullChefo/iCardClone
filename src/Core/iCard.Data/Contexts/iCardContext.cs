

using iCard.Data.Entities;
using Microsoft.EntityFrameworkCore;


namespace iCard.Data.Contexts
{
    public class ICardContext: DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Plan> Plan { get; set; }
        public DbSet<Account> Account { get; set; }
        public DbSet<Settings> Settings { get; set; }
        public DbSet<VirtualCard> VirtualCards { get; set; }
        public DbSet<TransactionHistory> TransactionHistories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=BalanceProjectDB;User Id=applogin;Password=12344321;");


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
                .HasForeignKey( th => th.AccountId);
          

            
            
            modelBuilder.Entity<Account>()
                .HasOne<Settings>(acc => acc.Settings);
        
            
            modelBuilder.Entity<Account>()
                .HasOne<Plan>(acc => acc.Plan);
          


        


        }


    }
}

