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
    partial class OfficeMapDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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
                        .HasColumnName("email")
                        .HasMaxLength(100);

                    b.Property<bool>("IsSuperUser")
                        .HasColumnName("is_super_user");

                    b.Property<string>("JobTitle")
                        .HasColumnName("job_title")
                        .HasMaxLength(50);

                    b.Property<string>("Name")
                        .HasColumnName("name")
                        .HasMaxLength(50);

                    b.Property<string>("Phone")
                        .HasColumnName("phone")
                        .HasMaxLength(50);

                    b.Property<string>("Surname")
                        .HasColumnName("surname")
                        .HasMaxLength(50);

                    b.Property<string>("UnitId")
                        .HasColumnName("unit_id")
                        .HasMaxLength(10);

                    b.Property<string>("UserIdentity")
                        .IsRequired()
                        .HasColumnName("user_identity")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.HasIndex("UnitId");

                    b.HasIndex("UserIdentity")
                        .IsUnique();

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("OfficeMap.Data.Models.Floor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<int>("Height")
                        .HasColumnName("height");

                    b.Property<int>("Seq")
                        .HasColumnName("seq");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnName("title")
                        .HasMaxLength(30);

                    b.Property<int>("Width")
                        .HasColumnName("width");

                    b.HasKey("Id");

                    b.ToTable("Floors");
                });

            modelBuilder.Entity("OfficeMap.Data.Models.Object", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<int?>("CustomHeight")
                        .HasColumnName("custom_height");

                    b.Property<int?>("CustomWidth")
                        .HasColumnName("custom_width");

                    b.Property<int?>("EmployeeId")
                        .HasColumnName("employee_id");

                    b.Property<int>("FloorId")
                        .HasColumnName("floor_id");

                    b.Property<string>("ObjectTypeId")
                        .HasColumnName("object_type_id")
                        .HasMaxLength(10);

                    b.Property<int?>("ParentObjectId")
                        .HasColumnName("parent_object_id");

                    b.Property<int?>("RotationAngle")
                        .HasColumnName("rotation_angle");

                    b.Property<string>("SvgTypeId")
                        .HasColumnName("svg_type_id");

                    b.Property<int>("TopLeftX")
                        .HasColumnName("top_left_x");

                    b.Property<int>("TopLeftY")
                        .HasColumnName("top_left_y");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("FloorId");

                    b.HasIndex("ObjectTypeId");

                    b.HasIndex("ParentObjectId");

                    b.HasIndex("SvgTypeId");

                    b.ToTable("Objects");
                });

            modelBuilder.Entity("OfficeMap.Data.Models.ObjectAttribute", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<string>("AttributeId")
                        .HasColumnName("attribute_id");

                    b.Property<int>("ObjectId")
                        .HasColumnName("object_id");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnName("value")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.HasIndex("AttributeId");

                    b.HasIndex("ObjectId");

                    b.ToTable("ObjectAttributes");
                });

            modelBuilder.Entity("OfficeMap.Data.Models.ObjectType", b =>
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

                    b.ToTable("ObjectTypes");
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

                    b.Property<int>("Height")
                        .HasColumnName("height");

                    b.Property<string>("Name")
                        .HasColumnName("name")
                        .HasMaxLength(50);

                    b.Property<string>("StrokeColor")
                        .IsRequired()
                        .HasColumnName("stroke_color")
                        .HasMaxLength(7);

                    b.Property<int>("Width")
                        .HasColumnName("width");

                    b.HasKey("Id");

                    b.ToTable("SvgTypes");
                });

            modelBuilder.Entity("OfficeMap.Data.Models.Unit", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasMaxLength(10);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("Units");
                });

            modelBuilder.Entity("OfficeMap.Data.Models.WorkplaceChange", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<DateTime?>("ApprovalDate")
                        .HasColumnName("approval_date");

                    b.Property<int>("EmployeeId")
                        .HasColumnName("employee_id");

                    b.Property<int>("NewWorkplaceId")
                        .HasColumnName("new_workplace_id");

                    b.Property<int?>("OldWorkplaceId")
                        .HasColumnName("old_workplace_id");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("NewWorkplaceId");

                    b.HasIndex("OldWorkplaceId");

                    b.ToTable("WorkplacesChanges");
                });

            modelBuilder.Entity("OfficeMap.Data.Models.Employee", b =>
                {
                    b.HasOne("OfficeMap.Data.Models.Unit", "Unit")
                        .WithMany("Employees")
                        .HasForeignKey("UnitId");
                });

            modelBuilder.Entity("OfficeMap.Data.Models.Object", b =>
                {
                    b.HasOne("OfficeMap.Data.Models.Employee", "Employee")
                        .WithMany("Objects")
                        .HasForeignKey("EmployeeId");

                    b.HasOne("OfficeMap.Data.Models.Floor", "Floor")
                        .WithMany()
                        .HasForeignKey("FloorId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("OfficeMap.Data.Models.ObjectType", "ObjectType")
                        .WithMany("Objects")
                        .HasForeignKey("ObjectTypeId");

                    b.HasOne("OfficeMap.Data.Models.Object", "ParentObject")
                        .WithMany()
                        .HasForeignKey("ParentObjectId");

                    b.HasOne("OfficeMap.Data.Models.SvgType", "SvgType")
                        .WithMany()
                        .HasForeignKey("SvgTypeId");
                });

            modelBuilder.Entity("OfficeMap.Data.Models.ObjectAttribute", b =>
                {
                    b.HasOne("OfficeMap.Data.Models.Attribute", "Attribute")
                        .WithMany()
                        .HasForeignKey("AttributeId");

                    b.HasOne("OfficeMap.Data.Models.Object", "Object")
                        .WithMany("ObjectAttributes")
                        .HasForeignKey("ObjectId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("OfficeMap.Data.Models.WorkplaceChange", b =>
                {
                    b.HasOne("OfficeMap.Data.Models.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("OfficeMap.Data.Models.Object", "NewWorkplace")
                        .WithMany()
                        .HasForeignKey("NewWorkplaceId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("OfficeMap.Data.Models.Object", "OldWorkplace")
                        .WithMany()
                        .HasForeignKey("OldWorkplaceId");
                });
#pragma warning restore 612, 618
        }
    }
}
