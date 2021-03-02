﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Tournament.Data;

namespace Tournament.Migrations
{
    [DbContext(typeof(TournamentContext))]
    [Migration("20210228143416_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Tournament.Models.Game", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("TeamA_score")
                        .HasColumnType("int");

                    b.Property<int>("TeamB_score")
                        .HasColumnType("int");

                    b.Property<int?>("WinnerID")
                        .HasColumnType("int");

                    b.Property<int?>("teamAID")
                        .HasColumnType("int");

                    b.Property<int?>("teamBID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("WinnerID");

                    b.HasIndex("teamAID");

                    b.HasIndex("teamBID");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("Tournament.Models.Team", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Coach")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("ID");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("Tournament.Models.Game", b =>
                {
                    b.HasOne("Tournament.Models.Team", "Winner")
                        .WithMany()
                        .HasForeignKey("WinnerID");

                    b.HasOne("Tournament.Models.Team", "teamA")
                        .WithMany()
                        .HasForeignKey("teamAID");

                    b.HasOne("Tournament.Models.Team", "teamB")
                        .WithMany()
                        .HasForeignKey("teamBID");

                    b.Navigation("teamA");

                    b.Navigation("teamB");

                    b.Navigation("Winner");
                });
#pragma warning restore 612, 618
        }
    }
}