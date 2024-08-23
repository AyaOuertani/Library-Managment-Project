
using Library_Managment_Project.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;
namespace LibraryManagment.Data
{
    public class ApplicationDBcontext : DbContext
    {
        public ApplicationDBcontext(DbContextOptions options) : base(options)
        {
        }

        #region DbSets
        public DbSet<Member> Members { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<LoansBooks> LoansBooks { get; set; }
        #endregion

        #region OnModelCreating
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<LoansBooks>(x => x.HasKey(l => new { l.MemberId, l.BookId }));

            modelBuilder.Entity<LoansBooks>()
                        .HasOne(l => l.Member)
                        .WithMany(m => m.Loans)
                        .HasForeignKey(l => l.MemberId);

            modelBuilder.Entity<LoansBooks>()
                        .HasOne(b => b.Books)
                        .WithMany(b => b.Loans)
                        .HasForeignKey(l => l.BookId);
        }
        #endregion

    }

}