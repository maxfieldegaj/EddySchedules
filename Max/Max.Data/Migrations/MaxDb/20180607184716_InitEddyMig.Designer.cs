﻿// <auto-generated />
using System;
using Max.Data.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Max.Data.Migrations.MaxDb
{
    [DbContext(typeof(MaxDbContext))]
    [Migration("20180607184716_InitEddyMig")]
    partial class InitEddyMig
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.0-rtm-30799")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Max.Domain.Models.Business", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BusinessId");

                    b.Property<string>("Location");

                    b.Property<string>("Name");

                    b.Property<string>("PhoneNumber");

                    b.HasKey("Id");

                    b.HasIndex("BusinessId");

                    b.ToTable("Businesses");
                });

            modelBuilder.Entity("Max.Domain.Models.Person", b =>
                {
                    b.Property<string>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CurrentlyEmployed");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("Email");

                    b.Property<bool>("IsManager");

                    b.Property<string>("PhoneNumber");

                    b.HasKey("ID");

                    b.ToTable("People");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Person");
                });

            modelBuilder.Entity("Max.Domain.Models.Shift", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Assigned");

                    b.Property<string>("EmployeeID");

                    b.Property<DateTime>("EndTime");

                    b.Property<string>("PersonID");

                    b.Property<int?>("PlaceOfBusinessId");

                    b.Property<DateTime>("StartTime");

                    b.Property<bool>("TradePending");

                    b.HasKey("ID");

                    b.HasIndex("PersonID");

                    b.HasIndex("PlaceOfBusinessId");

                    b.ToTable("Schedules");
                });

            modelBuilder.Entity("Max.Domain.Models.Employee", b =>
                {
                    b.HasBaseType("Max.Domain.Models.Person");

                    b.Property<int?>("PlaceOfBusinessId");

                    b.Property<DateTime>("RequestedOff");

                    b.Property<int?>("ShiftID");

                    b.HasIndex("PlaceOfBusinessId");

                    b.HasIndex("ShiftID");

                    b.ToTable("Employee");

                    b.HasDiscriminator().HasValue("Employee");
                });

            modelBuilder.Entity("Max.Domain.Models.Manager", b =>
                {
                    b.HasBaseType("Max.Domain.Models.Person");

                    b.Property<int?>("PlaceOfBusinessId")
                        .HasColumnName("Manager_PlaceOfBusinessId");

                    b.Property<DateTime>("RequestedOff")
                        .HasColumnName("Manager_RequestedOff");

                    b.Property<int?>("ShiftID")
                        .HasColumnName("Manager_ShiftID");

                    b.HasIndex("PlaceOfBusinessId");

                    b.HasIndex("ShiftID");

                    b.ToTable("Manager");

                    b.HasDiscriminator().HasValue("Manager");
                });

            modelBuilder.Entity("Max.Domain.Models.Business", b =>
                {
                    b.HasOne("Max.Domain.Models.Business")
                        .WithMany("AffiliatedBusinesses")
                        .HasForeignKey("BusinessId");
                });

            modelBuilder.Entity("Max.Domain.Models.Shift", b =>
                {
                    b.HasOne("Max.Domain.Models.Person")
                        .WithMany("Schedule")
                        .HasForeignKey("PersonID");

                    b.HasOne("Max.Domain.Models.Business", "PlaceOfBusiness")
                        .WithMany("Schedule")
                        .HasForeignKey("PlaceOfBusinessId");
                });

            modelBuilder.Entity("Max.Domain.Models.Employee", b =>
                {
                    b.HasOne("Max.Domain.Models.Business", "PlaceOfBusiness")
                        .WithMany("Staff")
                        .HasForeignKey("PlaceOfBusinessId");

                    b.HasOne("Max.Domain.Models.Shift")
                        .WithMany("RequestedOffEmployees")
                        .HasForeignKey("ShiftID");
                });

            modelBuilder.Entity("Max.Domain.Models.Manager", b =>
                {
                    b.HasOne("Max.Domain.Models.Business", "PlaceOfBusiness")
                        .WithMany("Managers")
                        .HasForeignKey("PlaceOfBusinessId");

                    b.HasOne("Max.Domain.Models.Shift")
                        .WithMany("RequestedOffManager")
                        .HasForeignKey("ShiftID");
                });
#pragma warning restore 612, 618
        }
    }
}
