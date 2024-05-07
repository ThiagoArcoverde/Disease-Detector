﻿// <auto-generated />
using DiseaseDetector;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DiseaseDetector.Migrations
{
    [DbContext(typeof(DBContext))]
    [Migration("20240507115017_update-disease")]
    partial class updatedisease
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.4");

            modelBuilder.Entity("DiseaseDetector.Entities.Disease", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("Alias")
                        .HasColumnType("TEXT");

                    b.Property<string>("AliasId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("SymptomsId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Diseases");
                });

            modelBuilder.Entity("DiseaseDetector.Entities.Symptom", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Symptoms");
                });
#pragma warning restore 612, 618
        }
    }
}
