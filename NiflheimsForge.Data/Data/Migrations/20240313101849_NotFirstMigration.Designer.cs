﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NiflheimsForge.Data;

#nullable disable

namespace NiflheimsForge.Data.Data.Migrations
{
    [DbContext(typeof(NiflheimsForgeDBContext))]
    [Migration("20240313101849_NotFirstMigration")]
    partial class NotFirstMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("NiflheimsForge.Core.Models.City", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CountryId")
                        .IsRequired()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100000)
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("NiflheimsForge.Core.Models.Country", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100000)
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("NiflheimsForge.Core.Models.City", b =>
                {
                    b.HasOne("NiflheimsForge.Core.Models.Country", "Country")
                        .WithMany("Cities")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("NiflheimsForge.Core.Models.Country", b =>
                {
                    b.Navigation("Cities");
                });
#pragma warning restore 612, 618
        }
    }
}
