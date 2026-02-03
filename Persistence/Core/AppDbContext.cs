using Domain.Categories;
using Domain.Orders;
using Domain.Products;
using Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Core
{
    public class AppDbContext :DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
      : base(options)
        {}

        public DbSet<User> Users { get; set; }
        public DbSet<Category>Categories{ get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItems> OrderItems { get; set; }
        public DbSet<GuestUser> GuestUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>()
                .HasOne(o => o.Customer)
                .WithMany()
                .HasForeignKey(o => o.CustomerId)
                .IsRequired(false);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.GuestUser)
                .WithMany(g => g.Orders)
                .HasForeignKey(o => o.GuestUserId)
                .IsRequired(false);
        }


        public virtual bool ExecuteTransaction(Action transactionBody)
        {
            using var trans = this.Database.BeginTransaction();
            try
            {
                transactionBody.Invoke();
                trans.Commit();
                return true;
            }
            catch (Exception ex)
            {
                trans.Rollback();
                throw ex;
            }
        }

        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }

    }
}
