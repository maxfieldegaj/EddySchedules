﻿// <auto-generated />
using System;
using Eddy.Data.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Eddy.Data.Migrations
{
    [DbContext(typeof(EddyDbContext))]
    [Migration("20180629183820_MoreUpdates")]
    partial class MoreUpdates
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.0-rtm-30799")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Eddy.Domain.Models.Business", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BusinessId");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<string>("IdentifierString");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("PhoneNumber");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("StreetName");

                    b.Property<string>("StreetNumber");

                    b.Property<string>("ZipCode")
                        .IsRequired()
                        .HasMaxLength(10);

                    b.HasKey("Id");

                    b.HasIndex("BusinessId");

                    b.ToTable("Businesses");
                });

            modelBuilder.Entity("Eddy.Domain.Models.Message", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Content");

                    b.Property<bool>("Hostile");

                    b.Property<bool>("Read");

                    b.Property<string>("RecipientID");

                    b.Property<bool>("RepliedTo");

                    b.Property<string>("SenderID");

                    b.Property<DateTime>("SentTime");

                    b.HasKey("Id");

                    b.HasIndex("RecipientID");

                    b.HasIndex("SenderID");

                    b.ToTable("Message");
                });

            modelBuilder.Entity("Eddy.Domain.Models.Person", b =>
                {
                    b.Property<string>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("CurrentlyEmployed");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<bool>("IsManager");

                    b.Property<string>("LastName");

                    b.Property<string>("PhoneNumber");

                    b.Property<DateTime>("RequestedOff");

                    b.HasKey("ID");

                    b.ToTable("People");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Person");
                });

            modelBuilder.Entity("Eddy.Domain.Models.Shift", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Assigned");

                    b.Property<string>("AssignedToID");

                    b.Property<DateTime>("EndTime");

                    b.Property<bool>("ManagerShift");

                    b.Property<int?>("PlaceOfBusinessId");

                    b.Property<DateTime>("StartTime");

                    b.Property<bool>("TradePending");

                    b.HasKey("ID");

                    b.HasIndex("AssignedToID");

                    b.HasIndex("PlaceOfBusinessId");

                    b.ToTable("Schedules");
                });

            modelBuilder.Entity("Eddy.Domain.Models.Employee", b =>
                {
                    b.HasBaseType("Eddy.Domain.Models.Person");

                    b.Property<int?>("PlaceOfBusinessId");

                    b.Property<int?>("ShiftID");

                    b.HasIndex("PlaceOfBusinessId");

                    b.HasIndex("ShiftID");

                    b.ToTable("Employee");

                    b.HasDiscriminator().HasValue("Employee");
                });

            modelBuilder.Entity("Eddy.Domain.Models.Manager", b =>
                {
                    b.HasBaseType("Eddy.Domain.Models.Person");

                    b.Property<int?>("PlaceOfBusinessId")
                        .HasColumnName("Manager_PlaceOfBusinessId");

                    b.Property<int?>("ShiftID")
                        .HasColumnName("Manager_ShiftID");

                    b.HasIndex("PlaceOfBusinessId");

                    b.HasIndex("ShiftID");

                    b.ToTable("Manager");

                    b.HasDiscriminator().HasValue("Manager");
                });

            modelBuilder.Entity("Eddy.Domain.Models.Business", b =>
                {
                    b.HasOne("Eddy.Domain.Models.Business")
                        .WithMany("AffiliatedBusinesses")
                        .HasForeignKey("BusinessId");
                });

            modelBuilder.Entity("Eddy.Domain.Models.Message", b =>
                {
                    b.HasOne("Eddy.Domain.Models.Person", "Recipient")
                        .WithMany()
                        .HasForeignKey("RecipientID");

                    b.HasOne("Eddy.Domain.Models.Person", "Sender")
                        .WithMany()
                        .HasForeignKey("SenderID");
                });

            modelBuilder.Entity("Eddy.Domain.Models.Shift", b =>
                {
                    b.HasOne("Eddy.Domain.Models.Person", "AssignedTo")
                        .WithMany("Schedule")
                        .HasForeignKey("AssignedToID");

                    b.HasOne("Eddy.Domain.Models.Business", "PlaceOfBusiness")
                        .WithMany("Schedule")
                        .HasForeignKey("PlaceOfBusinessId");
                });

            modelBuilder.Entity("Eddy.Domain.Models.Employee", b =>
                {
                    b.HasOne("Eddy.Domain.Models.Business", "PlaceOfBusiness")
                        .WithMany("Staff")
                        .HasForeignKey("PlaceOfBusinessId");

                    b.HasOne("Eddy.Domain.Models.Shift")
                        .WithMany("RequestedOffEmployees")
                        .HasForeignKey("ShiftID");
                });

            modelBuilder.Entity("Eddy.Domain.Models.Manager", b =>
                {
                    b.HasOne("Eddy.Domain.Models.Business", "PlaceOfBusiness")
                        .WithMany("Managers")
                        .HasForeignKey("PlaceOfBusinessId");

                    b.HasOne("Eddy.Domain.Models.Shift")
                        .WithMany("RequestedOffManager")
                        .HasForeignKey("ShiftID");
                });
#pragma warning restore 612, 618
        }
    }
}
