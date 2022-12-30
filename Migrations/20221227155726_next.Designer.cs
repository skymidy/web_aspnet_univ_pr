﻿// <auto-generated />
using System;
using ASPnetWebApp.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ASPnetWebApp.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20221227155726_next")]
    partial class next
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ASPnetWebApp.Models.PairRecord", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PairedUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<float>("Rating")
                        .HasColumnType("real");

                    b.Property<string>("RatingDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("PairedUserId");

                    b.ToTable("PairRecords");
                });

            modelBuilder.Entity("ASPnetWebApp.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LoginName")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.Property<string>("LoginNameUppercase")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasMaxLength(84)
                        .HasColumnType("nvarchar(84)");

                    b.Property<Guid>("Profile")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("LoginName")
                        .IsUnique();

                    b.HasIndex("Profile");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ASPnetWebApp.Models.UserProfile", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Interests")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Knowledge")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("MentorSearchStatus")
                        .HasColumnType("bit");

                    b.Property<bool>("MentorStatus")
                        .HasColumnType("bit");

                    b.Property<bool>("SearchStatus")
                        .HasColumnType("bit");

                    b.HasKey("UserId");

                    b.ToTable("UsersProfile");
                });

            modelBuilder.Entity("ASPnetWebApp.Models.PairRecord", b =>
                {
                    b.HasOne("ASPnetWebApp.Models.User", "PairedUser")
                        .WithMany("PairRecords")
                        .HasForeignKey("PairedUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PairedUser");
                });

            modelBuilder.Entity("ASPnetWebApp.Models.User", b =>
                {
                    b.HasOne("ASPnetWebApp.Models.UserProfile", "UserProfile")
                        .WithMany()
                        .HasForeignKey("Profile")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserProfile");
                });

            modelBuilder.Entity("ASPnetWebApp.Models.User", b =>
                {
                    b.Navigation("PairRecords");
                });
#pragma warning restore 612, 618
        }
    }
}
