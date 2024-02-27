﻿// <auto-generated />
using System;
using LittleAirline.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ConsoleApp2.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240219210237_wip")]
    partial class wip
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.2");

            modelBuilder.Entity("ConsoleApp2.Models.Aircraft", b =>
                {
                    b.Property<int>("AircraftId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Registration")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("AircraftId");

                    b.ToTable("Aircrafts");
                });

            modelBuilder.Entity("ConsoleApp2.Models.Flight", b =>
                {
                    b.Property<int>("FlightId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AircraftId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Departure")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Destination")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Landing")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Takeoff")
                        .HasColumnType("TEXT");

                    b.HasKey("FlightId");

                    b.HasIndex("AircraftId");

                    b.ToTable("Flights");
                });

            modelBuilder.Entity("ConsoleApp2.Models.FlightPilot", b =>
                {
                    b.Property<int>("FlightId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PilotId")
                        .HasColumnType("INTEGER");

                    b.HasKey("FlightId", "PilotId");

                    b.HasIndex("PilotId");

                    b.ToTable("FlightPilots");
                });

            modelBuilder.Entity("ConsoleApp2.Models.Pilot", b =>
                {
                    b.Property<int>("PilotId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("PilotId");

                    b.ToTable("Pilots");
                });

            modelBuilder.Entity("ConsoleApp2.Models.Flight", b =>
                {
                    b.HasOne("ConsoleApp2.Models.Aircraft", "Aircraft")
                        .WithMany("Flights")
                        .HasForeignKey("AircraftId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Aircraft");
                });

            modelBuilder.Entity("ConsoleApp2.Models.FlightPilot", b =>
                {
                    b.HasOne("ConsoleApp2.Models.Flight", "Flight")
                        .WithMany("FlightPilots")
                        .HasForeignKey("FlightId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ConsoleApp2.Models.Pilot", "Pilot")
                        .WithMany("FlightPilots")
                        .HasForeignKey("PilotId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Flight");

                    b.Navigation("Pilot");
                });

            modelBuilder.Entity("ConsoleApp2.Models.Aircraft", b =>
                {
                    b.Navigation("Flights");
                });

            modelBuilder.Entity("ConsoleApp2.Models.Flight", b =>
                {
                    b.Navigation("FlightPilots");
                });

            modelBuilder.Entity("ConsoleApp2.Models.Pilot", b =>
                {
                    b.Navigation("FlightPilots");
                });
#pragma warning restore 612, 618
        }
    }
}