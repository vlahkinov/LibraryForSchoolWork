﻿// <auto-generated />
using System;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Data.Migrations
{
    [DbContext(typeof(LibraryContext))]
    partial class LibraryContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Data.Entities.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("FullName")
                        .IsUnique();

                    b.HasIndex("RoleId");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("Data.Entities.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CartId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CartId");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("Data.Entities.Cart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClientId")
                        .IsUnique();

                    b.HasIndex("EmployeeId");

                    b.ToTable("Carts");
                });

            modelBuilder.Entity("Data.Entities.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AccountId")
                        .HasColumnType("int");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("BookPreferences")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CardId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("Data.Entities.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AccountId")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("Data.Entities.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Data.Entities.Account", b =>
                {
                    b.HasOne("Data.Entities.Role", "Role")
                        .WithMany("Account")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Data.Entities.Book", b =>
                {
                    b.HasOne("Data.Entities.Cart", null)
                        .WithMany("Books")
                        .HasForeignKey("CartId");
                });

            modelBuilder.Entity("Data.Entities.Cart", b =>
                {
                    b.HasOne("Data.Entities.Client", "Client")
                        .WithOne("Cart")
                        .HasForeignKey("Data.Entities.Cart", "ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Data.Entities.Employee", "Employee")
                        .WithMany("Carts")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("Data.Entities.Client", b =>
                {
                    b.HasOne("Data.Entities.Account", "Account")
                        .WithMany()
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");
                });

            modelBuilder.Entity("Data.Entities.Employee", b =>
                {
                    b.HasOne("Data.Entities.Account", "Account")
                        .WithMany()
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");
                });

            modelBuilder.Entity("Data.Entities.Cart", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("Data.Entities.Client", b =>
                {
                    b.Navigation("Cart")
                        .IsRequired();
                });

            modelBuilder.Entity("Data.Entities.Employee", b =>
                {
                    b.Navigation("Carts");
                });

            modelBuilder.Entity("Data.Entities.Role", b =>
                {
                    b.Navigation("Account");
                });
#pragma warning restore 612, 618
        }
    }
}
