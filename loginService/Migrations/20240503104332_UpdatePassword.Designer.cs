﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using loginService.Data;

#nullable disable

namespace loginService.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20240503104332_UpdatePassword")]
    partial class UpdatePassword
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("loginService.Models.Connection", b =>
                {
                    b.Property<Guid>("SenderUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ReceiverUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsAccepted")
                        .HasColumnType("bit");

                    b.Property<DateTime>("RequestedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("SenderUserId", "ReceiverUserId");

                    b.HasIndex("ReceiverUserId");

                    b.ToTable("UserConnections");
                });

            modelBuilder.Entity("loginService.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ResetToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ResetTokenExpire")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SessionId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("loginService.Models.Connection", b =>
                {
                    b.HasOne("loginService.Models.User", "ReceiverUser")
                        .WithMany("ReceivedConnections")
                        .HasForeignKey("ReceiverUserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("loginService.Models.User", "SenderUser")
                        .WithMany("SentConnections")
                        .HasForeignKey("SenderUserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("ReceiverUser");

                    b.Navigation("SenderUser");
                });

            modelBuilder.Entity("loginService.Models.User", b =>
                {
                    b.Navigation("ReceivedConnections");

                    b.Navigation("SentConnections");
                });
#pragma warning restore 612, 618
        }
    }
}
