﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using ORMDemo.API.Infrastructure.Contexts;

#nullable disable

namespace ORMDemo.API.Migrations
{
    [DbContext(typeof(DemoContext))]
    partial class DemoContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ORMDemo.API.Infrastructure.Entities.Blog", b =>
                {
                    b.Property<Guid>("BlogId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedTimestamp")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("ModifiedTimestamp")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("BlogId");

                    b.ToTable("blogs", (string)null);
                });

            modelBuilder.Entity("ORMDemo.API.Infrastructure.Entities.Post", b =>
                {
                    b.Property<Guid>("PostId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("BlogId")
                        .HasColumnType("uuid");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("PostId");

                    b.HasIndex("BlogId");

                    b.ToTable("posts", (string)null);
                });

            modelBuilder.Entity("ORMDemo.API.Infrastructure.Entities.Post", b =>
                {
                    b.HasOne("ORMDemo.API.Infrastructure.Entities.Blog", "Blog")
                        .WithMany("Posts")
                        .HasForeignKey("BlogId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Blog");
                });

            modelBuilder.Entity("ORMDemo.API.Infrastructure.Entities.Blog", b =>
                {
                    b.Navigation("Posts");
                });
#pragma warning restore 612, 618
        }
    }
}
