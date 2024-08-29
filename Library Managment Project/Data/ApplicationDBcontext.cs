
using Library_Managment_Project.Entities;
using Microsoft.EntityFrameworkCore;
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
            modelBuilder.Entity<Librarian>().HasIndex(l => l.Email)
                                            .IsUnique();

            modelBuilder.Entity<Librarian>().HasIndex(l => l.PhoneNumber)
                                            .IsUnique();

            modelBuilder.Entity<Admin>().HasIndex(a => a.Email)
                                        .IsUnique();

            modelBuilder.Entity<Admin>().HasIndex(a => a.PhoneNumber)
                                        .IsUnique();

            modelBuilder.Entity<Member>().HasIndex(m => m.Email)
                                         .IsUnique();

            modelBuilder.Entity<Member>().HasIndex(m => m.PhoneNumber)
                                         .IsUnique();

            modelBuilder.Entity<LoansBook>().HasKey(l => l.Id);

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