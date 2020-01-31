﻿// <auto-generated />
using System;
using AirportManagement.Repo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AirportManagement.Repo.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AirportManagement.Data.Aircraft", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AircraftType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CountryOfRegistration")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("FlightId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Manufacturer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Model")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumberOfFlightAttendants")
                        .HasColumnType("int");

                    b.Property<int>("NumberOfPilots")
                        .HasColumnType("int");

                    b.Property<int>("NumberOfSeats")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FlightId")
                        .IsUnique()
                        .HasFilter("[FlightId] IS NOT NULL");

                    b.ToTable("Aircraft");
                });

            modelBuilder.Entity("AirportManagement.Data.Airport", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Airport");
                });

            modelBuilder.Entity("AirportManagement.Data.Destination", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AirportId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("FlightDestinationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("LocalTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("Weather")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AirportId");

                    b.HasIndex("FlightDestinationId")
                        .IsUnique()
                        .HasFilter("[FlightDestinationId] IS NOT NULL");

                    b.ToTable("Destination");
                });

            modelBuilder.Entity("AirportManagement.Data.Flight", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Airline")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("AirportId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<TimeSpan>("ArrivalTime")
                        .HasColumnType("time");

                    b.Property<TimeSpan>("DepartureTime")
                        .HasColumnType("time");

                    b.Property<Guid?>("DestinationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<TimeSpan>("EstimationTime")
                        .HasColumnType("time");

                    b.Property<string>("FlightNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<TimeSpan>("FlightTime")
                        .HasColumnType("time");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AirportId");

                    b.ToTable("Flight");
                });

            modelBuilder.Entity("AirportManagement.Data.Gate", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("DestinationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("FlightId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("GateNumber")
                        .HasColumnType("int");

                    b.Property<Guid?>("TerminalId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("DestinationId")
                        .IsUnique()
                        .HasFilter("[DestinationId] IS NOT NULL");

                    b.HasIndex("FlightId")
                        .IsUnique()
                        .HasFilter("[FlightId] IS NOT NULL");

                    b.HasIndex("TerminalId");

                    b.ToTable("Gate");
                });

            modelBuilder.Entity("AirportManagement.Data.Terminal", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AirportId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("DestinationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("FlightId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AirportId");

                    b.HasIndex("DestinationId")
                        .IsUnique()
                        .HasFilter("[DestinationId] IS NOT NULL");

                    b.ToTable("Terminal");
                });

            modelBuilder.Entity("AirportManagement.Data.Aircraft", b =>
                {
                    b.HasOne("AirportManagement.Data.Flight", "Flight")
                        .WithOne("Aircraft")
                        .HasForeignKey("AirportManagement.Data.Aircraft", "FlightId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("AirportManagement.Data.Destination", b =>
                {
                    b.HasOne("AirportManagement.Data.Airport", "Airport")
                        .WithMany()
                        .HasForeignKey("AirportId");

                    b.HasOne("AirportManagement.Data.Flight", "Flight")
                        .WithOne("Destination")
                        .HasForeignKey("AirportManagement.Data.Destination", "FlightDestinationId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("AirportManagement.Data.Flight", b =>
                {
                    b.HasOne("AirportManagement.Data.Airport", "Airport")
                        .WithMany("Flights")
                        .HasForeignKey("AirportId")
                        .OnDelete(DeleteBehavior.NoAction);
                });

            modelBuilder.Entity("AirportManagement.Data.Gate", b =>
                {
                    b.HasOne("AirportManagement.Data.Destination", "Destination")
                        .WithOne("Gate")
                        .HasForeignKey("AirportManagement.Data.Gate", "DestinationId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("AirportManagement.Data.Flight", "Flight")
                        .WithOne("Gate")
                        .HasForeignKey("AirportManagement.Data.Gate", "FlightId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("AirportManagement.Data.Terminal", "Terminal")
                        .WithMany("Gates")
                        .HasForeignKey("TerminalId")
                        .OnDelete(DeleteBehavior.NoAction);
                });

            modelBuilder.Entity("AirportManagement.Data.Terminal", b =>
                {
                    b.HasOne("AirportManagement.Data.Airport", "Airport")
                        .WithMany("Terminals")
                        .HasForeignKey("AirportId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("AirportManagement.Data.Destination", "Destination")
                        .WithOne("Terminal")
                        .HasForeignKey("AirportManagement.Data.Terminal", "DestinationId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("AirportManagement.Data.Flight", "Flight")
                        .WithOne("Terminal")
                        .HasForeignKey("AirportManagement.Data.Terminal", "DestinationId")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}