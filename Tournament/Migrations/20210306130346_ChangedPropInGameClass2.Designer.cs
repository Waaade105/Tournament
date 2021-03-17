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
    [Migration("20210306130346_ChangedPropInGameClass2")]
    partial class ChangedPropInGameClass2
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

                    b.Property<int?>("Team_AID")
                        .HasColumnType("int");

                    b.Property<int?>("Team_BID")
                        .HasColumnType("int");

                    b.Property<int?>("WinnerID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("Team_AID");

                    b.HasIndex("Team_BID");

                    b.HasIndex("WinnerID");

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
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.HasKey("ID");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("Tournament.Models.Game", b =>
                {
                    b.HasOne("Tournament.Models.Team", "Team_A")
                        .WithMany()
                        .HasForeignKey("Team_AID");

                    b.HasOne("Tournament.Models.Team", "Team_B")
                        .WithMany()
                        .HasForeignKey("Team_BID");

                    b.HasOne("Tournament.Models.Team", "Winner")
                        .WithMany()
                        .HasForeignKey("WinnerID");

                    b.Navigation("Team_A");

                    b.Navigation("Team_B");

                    b.Navigation("Winner");
                });
#pragma warning restore 612, 618
        }
    }
}
