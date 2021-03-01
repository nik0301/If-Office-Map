﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using OfficeMap.Data;
using System;

namespace OfficeMap.Data.Migrations
{
    [DbContext(typeof(OfficeMapDbContext))]
    [Migration("20180315083446_Drop Objects and Areas")]
    partial class DropObjectsandAreas
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("OfficeMap.Data.Models.Attribute", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasMaxLength(10);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Attributes");
                });

            modelBuilder.Entity("OfficeMap.Data.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnName("email")
                        .HasMaxLength(100);

                    b.Property<string>("JobTitle")
                        .IsRequired()
                        .HasColumnName("job_title")
                        .HasMaxLength(50);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasMaxLength(50);

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnName("phone")
                        .HasMaxLength(50);

                    b.Property<string>("Surnmae")
                        .IsRequired()
                        .HasColumnName("surname")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("OfficeMap.Data.Models.Floor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<int>("Seq")
                        .HasColumnName("seq");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnName("title")
                        .HasMaxLength(30);

                    b.HasKey("Id");

                    b.ToTable("Floors");
                });

            modelBuilder.Entity("OfficeMap.Data.Models.ObjectAttribute", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<int>("AreaId")
                        .HasColumnName("area_id");

                    b.Property<string>("AttributeId")
                        .HasColumnName("attribute_id");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnName("value")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("ObjectAttributes");
                });

            modelBuilder.Entity("OfficeMap.Data.Models.SvgType", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasMaxLength(10);

                    b.Property<string>("Draw")
                        .IsRequired()
                        .HasColumnName("draw")
                        .HasMaxLength(250);

                    b.Property<string>("FillColor")
                        .IsRequired()
                        .HasColumnName("fill_color")
                        .HasMaxLength(7);

                    b.Property<string>("Name")
                        .HasColumnName("name")
                        .HasMaxLength(50);

                    b.Property<string>("StrokeColor")
                        .IsRequired()
                        .HasColumnName("stroke_color")
                        .HasMaxLength(7);

                    b.HasKey("Id");

                    b.ToTable("SvgTypes");
                });
#pragma warning restore 612, 618
        }
    }
}
