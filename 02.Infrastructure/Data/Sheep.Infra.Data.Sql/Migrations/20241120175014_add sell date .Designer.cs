﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Sheep.Infra.Data.Sql;

#nullable disable

namespace Sheep.Infra.Data.Sql.Migrations
{
    [DbContext(typeof(SheepDbcontext))]
    [Migration("20241120175014_add sell date ")]
    partial class addselldate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Sheep.Core.Domain.Category.CategoryEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWSEQUENTIALID()");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("CategoryEntity", (string)null);
                });

            modelBuilder.Entity("Sheep.Core.Domain.Category.CategoryPriceEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWSEQUENTIALID()");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<long>("Food")
                        .HasColumnType("bigint");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<long>("Overhead")
                        .HasColumnType("bigint");

                    b.Property<long>("Salary")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("CategoryPriceEntity");
                });

            modelBuilder.Entity("Sheep.Core.Domain.Sheep.Entities.SheepCategoryEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWSEQUENTIALID()");

                    b.Property<bool>("ActiveGroup")
                        .HasColumnType("bit");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("SheepId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("SheepId");

                    b.ToTable("SheepCategoryEntity", (string)null);
                });

            modelBuilder.Entity("Sheep.Core.Domain.Sheep.Entities.SheepEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWSEQUENTIALID()");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("ParentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("SheepNumber")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<DateTime?>("SheepSellDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("SheepState")
                        .HasColumnType("int");

                    b.Property<DateTime?>("SheepbirthDate")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("SheepshopDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("SheepwastedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.ToTable("SheepEntity", (string)null);
                });

            modelBuilder.Entity("Sheep.Core.Domain.Sheep.Entities.SheepFullPriceEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWSEQUENTIALID()");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<long?>("Expectations")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<long?>("PriceSheep")
                        .HasColumnType("bigint");

                    b.Property<Guid>("SheepId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("SheepId");

                    b.ToTable("SheepFullPriceEntity", (string)null);
                });

            modelBuilder.Entity("Sheep.Core.Domain.Category.CategoryPriceEntity", b =>
                {
                    b.HasOne("Sheep.Core.Domain.Category.CategoryEntity", "CategoryEntity")
                        .WithMany("CategoryEntities")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CategoryEntity");
                });

            modelBuilder.Entity("Sheep.Core.Domain.Sheep.Entities.SheepCategoryEntity", b =>
                {
                    b.HasOne("Sheep.Core.Domain.Category.CategoryEntity", "Category")
                        .WithMany("SheepGroups")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Sheep.Core.Domain.Sheep.Entities.SheepEntity", "Sheep")
                        .WithMany("SheepGroup")
                        .HasForeignKey("SheepId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Sheep");
                });

            modelBuilder.Entity("Sheep.Core.Domain.Sheep.Entities.SheepEntity", b =>
                {
                    b.HasOne("Sheep.Core.Domain.Sheep.Entities.SheepEntity", "Parent")
                        .WithMany("SheepEntites")
                        .HasForeignKey("ParentId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Parent");
                });

            modelBuilder.Entity("Sheep.Core.Domain.Sheep.Entities.SheepFullPriceEntity", b =>
                {
                    b.HasOne("Sheep.Core.Domain.Sheep.Entities.SheepEntity", "SheepEntity")
                        .WithMany("SheepFullPrices")
                        .HasForeignKey("SheepId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SheepEntity");
                });

            modelBuilder.Entity("Sheep.Core.Domain.Category.CategoryEntity", b =>
                {
                    b.Navigation("CategoryEntities");

                    b.Navigation("SheepGroups");
                });

            modelBuilder.Entity("Sheep.Core.Domain.Sheep.Entities.SheepEntity", b =>
                {
                    b.Navigation("SheepEntites");

                    b.Navigation("SheepFullPrices");

                    b.Navigation("SheepGroup");
                });
#pragma warning restore 612, 618
        }
    }
}
