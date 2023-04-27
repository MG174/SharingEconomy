﻿// <auto-generated />
using System;
using CQRSwithMediatR.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CQRSwithMediatR.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0-preview.3.21201.2");

            modelBuilder.Entity("CQRSwithMediatR.Models.Advertisment", b =>
                {
                    b.Property<int>("AdvertismentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("CreatedByUserId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("CreatedTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.HasKey("AdvertismentId");

                    b.HasIndex("CreatedByUserId");

                    b.ToTable("Advertisment");
                });

            modelBuilder.Entity("CQRSwithMediatR.Models.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Author")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("CQRSwithMediatR.Models.Booking", b =>
                {
                    b.Property<int>("BookingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("AdvertismentBookedIdAdvertismentId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("BookedTime")
                        .HasColumnType("TEXT");

                    b.Property<int?>("UserBookedByIdUserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("BookingId");

                    b.HasIndex("AdvertismentBookedIdAdvertismentId");

                    b.HasIndex("UserBookedByIdUserId");

                    b.ToTable("Booking");
                });

            modelBuilder.Entity("CQRSwithMediatR.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("AccountType")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Surname")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("CQRSwithMediatR.Models.Advertisment", b =>
                {
                    b.HasOne("CQRSwithMediatR.Models.User", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedByUserId");

                    b.Navigation("CreatedBy");
                });

            modelBuilder.Entity("CQRSwithMediatR.Models.Booking", b =>
                {
                    b.HasOne("CQRSwithMediatR.Models.Advertisment", "AdvertismentBookedId")
                        .WithMany()
                        .HasForeignKey("AdvertismentBookedIdAdvertismentId");

                    b.HasOne("CQRSwithMediatR.Models.User", "UserBookedById")
                        .WithMany()
                        .HasForeignKey("UserBookedByIdUserId");

                    b.Navigation("AdvertismentBookedId");

                    b.Navigation("UserBookedById");
                });
#pragma warning restore 612, 618
        }
    }
}
