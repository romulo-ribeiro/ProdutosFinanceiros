﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProdutosFinanceiros.Infra.Context;

#nullable disable

namespace ProdutosFinanceiros.Infra.Migrations
{
    [DbContext(typeof(MainContext))]
    partial class MainContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ProdutosFinanceiros.Domain.FinancialProduct", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("PaymentDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<decimal>("Value")
                        .HasPrecision(5)
                        .HasColumnType("decimal(5,2)");

                    b.HasKey("Id");

                    b.ToTable("FinancialProduct");
                });

            modelBuilder.Entity("ProdutosFinanceiros.Domain.InvestmentWallet", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<Guid>("ManagerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("WalletFinancialProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("WalletNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ManagerId");

                    b.HasIndex("UserId");

                    b.HasIndex("WalletFinancialProductId");

                    b.ToTable("InvestmentWallet");
                });

            modelBuilder.Entity("ProdutosFinanceiros.Domain.InvestmentWalletFinancialProduct", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<Guid>("FinancialProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("InvestmentWalletId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FinancialProductId");

                    b.HasIndex("InvestmentWalletId");

                    b.ToTable("InvestmentWalletFinancialProduct");
                });

            modelBuilder.Entity("ProdutosFinanceiros.Domain.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("ProdutosFinanceiros.Domain.InvestmentWallet", b =>
                {
                    b.HasOne("ProdutosFinanceiros.Domain.User", "Manager")
                        .WithMany()
                        .HasForeignKey("ManagerId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("ProdutosFinanceiros.Domain.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("ProdutosFinanceiros.Domain.InvestmentWalletFinancialProduct", "WalletFinancialProduct")
                        .WithMany()
                        .HasForeignKey("WalletFinancialProductId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("Manager");

                    b.Navigation("User");

                    b.Navigation("WalletFinancialProduct");
                });

            modelBuilder.Entity("ProdutosFinanceiros.Domain.InvestmentWalletFinancialProduct", b =>
                {
                    b.HasOne("ProdutosFinanceiros.Domain.FinancialProduct", "FinancialProduct")
                        .WithMany()
                        .HasForeignKey("FinancialProductId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("ProdutosFinanceiros.Domain.InvestmentWallet", "InvestmentWallet")
                        .WithMany()
                        .HasForeignKey("InvestmentWalletId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("FinancialProduct");

                    b.Navigation("InvestmentWallet");
                });
#pragma warning restore 612, 618
        }
    }
}
