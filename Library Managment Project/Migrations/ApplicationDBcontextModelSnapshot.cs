﻿// <auto-generated />
using System;
using LibraryManagment.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Library_Managment_Project.Migrations
{
    [DbContext(typeof(ApplicationDBcontext))]
    partial class ApplicationDBcontextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Library_Managment_Project.Entities.Book", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("About")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Auther")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Code")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("PublishDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Qte")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.ToTable("Book");
                });

            modelBuilder.Entity("Library_Managment_Project.Entities.LoansBook", b =>
                {
                    b.Property<string>("MemberId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("BookId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("DateOfLoan")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateOfReturn")
                        .HasColumnType("datetime2");

                    b.Property<string>("LoanID")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LoanStatus")
                        .HasColumnType("int");

                    b.HasKey("MemberId", "BookId");

                    b.HasIndex("BookId");

                    b.ToTable("LoansBooks");
                });

            modelBuilder.Entity("Library_Managment_Project.Entities.Member", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MemberShipType")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdateAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("phone")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Member");
                });

            modelBuilder.Entity("Library_Managment_Project.Entities.LoansBook", b =>
                {
                    b.HasOne("Library_Managment_Project.Entities.Book", "Book")
                        .WithMany("Loans")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Library_Managment_Project.Entities.Member", "Member")
                        .WithMany("Loans")
                        .HasForeignKey("MemberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("Member");
                });

            modelBuilder.Entity("Library_Managment_Project.Entities.Book", b =>
                {
                    b.Navigation("Loans");
                });

            modelBuilder.Entity("Library_Managment_Project.Entities.Member", b =>
                {
                    b.Navigation("Loans");
                });
#pragma warning restore 612, 618
        }
    }
}
