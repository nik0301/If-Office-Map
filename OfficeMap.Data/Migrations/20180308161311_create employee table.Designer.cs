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
    [Migration("20180308161311_create employee table")]
    partial class createemployeetable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("OfficeMap.Data.Models.Area", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<int>("FloorId")
                        .HasColumnName("floor_id");

                    b.Property<int>("Height")
                        .HasColumnName("height");

                    b.Property<int?>("ParentId")
                        .HasColumnName("parent_id");

                    b.Property<int>("TopLeftX")
                        .HasColumnName("top_left_x");

                    b.Property<int>("TopLeftY")
                        .HasColumnName("top_left_y");

                    b.Property<int>("Width")
                        .HasColumnName("width");

                    b.HasKey("Id");

                    b.HasIndex("FloorId");

                    b.HasIndex("ParentId");

                    b.ToTable("Areas");
                });

            modelBuilder.Entity("OfficeMap.Data.Models.AreaAttribute", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<int>("AreaId")
                        .HasColumnName("area_id");

                    b.Property<string>("AttributeTitle")
                        .IsRequired()
                        .HasColumnName("attribute_title")
                        .HasMaxLength(50);

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnName("value")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.HasIndex("AreaId");

                    b.HasIndex("AttributeTitle");

                    b.ToTable("AreasAttributes");
                });

            modelBuilder.Entity("OfficeMap.Data.Models.Attribute", b =>
                {
                    b.Property<string>("Title")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("title")
                        .HasMaxLength(50);

                    b.HasKey("Title");

                    b.ToTable("Attributes");
                });

            modelBuilder.Entity("OfficeMap.Data.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<int?>("AreaId")
                        .HasColumnName("workplace_id");

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

                    b.HasIndex("AreaId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("OfficeMap.Data.Models.Floor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<int>("Nr")
                        .HasColumnName("nr");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnName("title")
                        .HasMaxLength(30);

                    b.HasKey("Id");

                    b.ToTable("Floors");
                });

            modelBuilder.Entity("OfficeMap.Data.Models.Object", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<int>("AreaId")
                        .HasColumnName("area_id");

                    b.Property<int>("TopLeftX")
                        .HasColumnName("top_left_x");

                    b.Property<int>("TopLeftY")
                        .HasColumnName("top_left_y");

                    b.Property<string>("TypeTitle")
                        .IsRequired()
                        .HasColumnName("type_title")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("AreaId");

                    b.HasIndex("TypeTitle");

                    b.ToTable("Objects");
                });

            modelBuilder.Entity("OfficeMap.Data.Models.SvgPath", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<string>("Draw")
                        .IsRequired()
                        .HasColumnName("draw")
                        .HasMaxLength(250);

                    b.Property<string>("FillColor")
                        .IsRequired()
                        .HasColumnName("fill_color")
                        .HasMaxLength(7);

                    b.Property<string>("StrokeColor")
                        .IsRequired()
                        .HasColumnName("stroke_color")
                        .HasMaxLength(7);

                    b.HasKey("Id");

                    b.ToTable("SvgPaths");
                });

            modelBuilder.Entity("OfficeMap.Data.Models.Type", b =>
                {
                    b.Property<string>("Title")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("title")
                        .HasMaxLength(50);

                    b.Property<int>("SvgPathId")
                        .HasColumnName("svg_path_id");

                    b.HasKey("Title");

                    b.HasIndex("SvgPathId");

                    b.ToTable("Types");
                });

            modelBuilder.Entity("OfficeMap.Data.Models.Area", b =>
                {
                    b.HasOne("OfficeMap.Data.Models.Floor", "Floor")
                        .WithMany()
                        .HasForeignKey("FloorId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("OfficeMap.Data.Models.Area", "Parent")
                        .WithMany()
                        .HasForeignKey("ParentId");
                });

            modelBuilder.Entity("OfficeMap.Data.Models.AreaAttribute", b =>
                {
                    b.HasOne("OfficeMap.Data.Models.Area", "Area")
                        .WithMany()
                        .HasForeignKey("AreaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("OfficeMap.Data.Models.Attribute", "Attribute")
                        .WithMany()
                        .HasForeignKey("AttributeTitle")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("OfficeMap.Data.Models.Employee", b =>
                {
                    b.HasOne("OfficeMap.Data.Models.Area", "Area")
                        .WithMany()
                        .HasForeignKey("AreaId");
                });

            modelBuilder.Entity("OfficeMap.Data.Models.Object", b =>
                {
                    b.HasOne("OfficeMap.Data.Models.Area", "Area")
                        .WithMany()
                        .HasForeignKey("AreaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("OfficeMap.Data.Models.Type", "Type")
                        .WithMany()
                        .HasForeignKey("TypeTitle")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("OfficeMap.Data.Models.Type", b =>
                {
                    b.HasOne("OfficeMap.Data.Models.SvgPath", "SvgPath")
                        .WithMany()
                        .HasForeignKey("SvgPathId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
