
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

        public DbSet<Member> Member { get; set; }
        public DbSet<Book> Book { get; set; }
        public DbSet<LoansBook> LoansBooks { get; set; }
        public DbSet<Librarian> Librarian { get; set; }
        public DbSet<Admin> Admin { get; set; }
        #endregion

        #region OnModelCreating
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<LoansBook>()
                .HasKey(l => l.Id);
            modelBuilder.Entity<LoansBook>()
                        .HasOne(l => l.Member)
                        .WithMany(m => m.Loans)
                        .HasForeignKey(l => l.MemberId);

            modelBuilder.Entity<LoansBook>()
                        .HasOne(b => b.Book)
                        .WithMany(b => b.Loans)
                        .HasForeignKey(l => l.BookId);
            

        }
        #endregion

    }

}