﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using carCRBackend.Contexts;

#nullable disable

namespace carCRBackend.Migrations
{
    [DbContext(typeof(CarDataSQLiteDbContext))]
    [Migration("20211231090527_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.1");

            modelBuilder.Entity("carCRBackend.Models.CarDataModel", b =>
                {
                    b.Property<int>("CarId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CarDate")
                        .HasMaxLength(4)
                        .HasColumnType("INTEGER");

                    b.Property<string>("CarMake")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<string>("CarModel")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.HasKey("CarId");

                    b.ToTable("Athletes");
                });
#pragma warning restore 612, 618
        }
    }
}
