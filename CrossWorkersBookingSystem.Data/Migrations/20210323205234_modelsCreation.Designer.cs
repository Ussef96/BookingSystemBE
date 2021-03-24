﻿// <auto-generated />
using System;
using CrossWorkersBookingSystem.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CrossWorkersBookingSystem.Data.Migrations
{
    [DbContext(typeof(BookingContext))]
    [Migration("20210323205234_modelsCreation")]
    partial class modelsCreation
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CrossWorkersBookingSystem.Models.Models.Booking", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BookedQuantity")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateFrom")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateTo")
                        .HasColumnType("datetime2");

                    b.Property<int>("ResourceId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ResourceId")
                        .IsUnique();

                    b.ToTable("Booking");
                });

            modelBuilder.Entity("CrossWorkersBookingSystem.Models.Models.Resource", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Resource");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Anna Karenina",
                            Quantity = 10
                        },
                        new
                        {
                            Id = 2,
                            Name = "To Kill a Mockingbird",
                            Quantity = 5
                        },
                        new
                        {
                            Id = 3,
                            Name = "The Great Gatsby",
                            Quantity = 4
                        });
                });

            modelBuilder.Entity("CrossWorkersBookingSystem.Models.Models.Booking", b =>
                {
                    b.HasOne("CrossWorkersBookingSystem.Models.Models.Resource", "Resource")
                        .WithOne("Booking")
                        .HasForeignKey("CrossWorkersBookingSystem.Models.Models.Booking", "ResourceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Resource");
                });

            modelBuilder.Entity("CrossWorkersBookingSystem.Models.Models.Resource", b =>
                {
                    b.Navigation("Booking");
                });
#pragma warning restore 612, 618
        }
    }
}