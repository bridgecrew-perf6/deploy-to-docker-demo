﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WeatherAPI.Context;

namespace WeatherAPI.Migrations
{
    [DbContext(typeof(WeatherContext))]
    [Migration("20210118022435_initdb")]
    partial class initdb
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("WeatherAPI.Models.Weather", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("HappenDate")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Summary")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("TemperatureC")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("WeatherSet");
                });
#pragma warning restore 612, 618
        }
    }
}
