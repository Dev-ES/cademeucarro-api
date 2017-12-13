﻿// <auto-generated />

using System;
using CademeucarroApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace CademeucarroApi.Migrations
{
    [DbContext(typeof(CadeMeuCarroDataContext))]
    partial class CadeMeuCarroDataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452");

            modelBuilder.Entity("cademeucarro_api.Models.Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("IsStolen");

                    b.Property<string>("OwnerEmail");

                    b.Property<string>("OwnerPhone");

                    b.Property<string>("Plate");

                    b.Property<DateTime?>("StolenOn");

                    b.HasKey("Id");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("cademeucarro_api.Models.TrackCar", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CameraId");

                    b.Property<int?>("CarId");

                    b.Property<int>("Lat");

                    b.Property<int>("Long");

                    b.Property<string>("Plate");

                    b.Property<DateTime>("TrackedAt");

                    b.HasKey("Id");

                    b.HasIndex("CarId");

                    b.ToTable("Tracks");
                });

            modelBuilder.Entity("cademeucarro_api.Models.TrackCar", b =>
                {
                    b.HasOne("cademeucarro_api.Models.Car", "Car")
                        .WithMany()
                        .HasForeignKey("CarId");
                });
#pragma warning restore 612, 618
        }
    }
}
