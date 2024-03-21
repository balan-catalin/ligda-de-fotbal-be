﻿// <auto-generated />
using System;
using LigaDeFotbal.DAL.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LigaDeFotbal.DAL.Migrations
{
    [DbContext(typeof(LdfContext))]
    [Migration("20231003205805_MakeScoreNullable")]
    partial class MakeScoreNullable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("LigaDeFotbal.BBL.Entities.Bet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("BetDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CompetitionId")
                        .HasColumnType("int");

                    b.Property<DateTime>("GamePlayDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("GameTeamId1")
                        .HasColumnType("int");

                    b.Property<int>("GameTeamId2")
                        .HasColumnType("int");

                    b.Property<int>("Score1")
                        .HasColumnType("int");

                    b.Property<int>("Score2")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CompetitionId");

                    b.HasIndex("UserId");

                    b.HasIndex("GameTeamId1", "GameTeamId2", "GamePlayDate");

                    b.ToTable("Bets");
                });

            modelBuilder.Entity("LigaDeFotbal.BBL.Entities.Competition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Competitions");
                });

            modelBuilder.Entity("LigaDeFotbal.BBL.Entities.Game", b =>
                {
                    b.Property<int>("FirstTeamId")
                        .HasColumnType("int");

                    b.Property<int>("SecondTeamId")
                        .HasColumnType("int");

                    b.Property<DateTime>("PlayDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("CompetitionId")
                        .HasColumnType("int");

                    b.Property<int>("Fixture")
                        .HasColumnType("int");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<int?>("Score1")
                        .HasColumnType("int");

                    b.Property<int?>("Score2")
                        .HasColumnType("int");

                    b.HasKey("FirstTeamId", "SecondTeamId", "PlayDate");

                    b.HasIndex("CompetitionId");

                    b.HasIndex("SecondTeamId");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("LigaDeFotbal.BBL.Entities.Team", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShortName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("LigaDeFotbal.BBL.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("LigaDeFotbal.BBL.Entities.UserCompetition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CompetitionId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("LastUpdate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Position")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(-1);

                    b.Property<DateTime>("RegistrationDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("RightAnswers")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<string>("Score")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(max)")
                        .HasDefaultValue("0");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CompetitionId");

                    b.HasIndex("UserId");

                    b.ToTable("UserCompetitions");
                });

            modelBuilder.Entity("LigaDeFotbal.BBL.Entities.Bet", b =>
                {
                    b.HasOne("LigaDeFotbal.BBL.Entities.Competition", null)
                        .WithMany("Bets")
                        .HasForeignKey("CompetitionId");

                    b.HasOne("LigaDeFotbal.BBL.Entities.User", null)
                        .WithMany("Bets")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LigaDeFotbal.BBL.Entities.Game", "Game")
                        .WithMany("Bets")
                        .HasForeignKey("GameTeamId1", "GameTeamId2", "GamePlayDate")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Game");
                });

            modelBuilder.Entity("LigaDeFotbal.BBL.Entities.Game", b =>
                {
                    b.HasOne("LigaDeFotbal.BBL.Entities.Competition", "Competition")
                        .WithMany()
                        .HasForeignKey("CompetitionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LigaDeFotbal.BBL.Entities.Team", "FirstTeam")
                        .WithMany("Games")
                        .HasForeignKey("FirstTeamId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("LigaDeFotbal.BBL.Entities.Team", "SecondTeam")
                        .WithMany()
                        .HasForeignKey("SecondTeamId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Competition");

                    b.Navigation("FirstTeam");

                    b.Navigation("SecondTeam");
                });

            modelBuilder.Entity("LigaDeFotbal.BBL.Entities.UserCompetition", b =>
                {
                    b.HasOne("LigaDeFotbal.BBL.Entities.Competition", "Competition")
                        .WithMany("UserCompetitions")
                        .HasForeignKey("CompetitionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LigaDeFotbal.BBL.Entities.User", "User")
                        .WithMany("UserCompetitions")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Competition");

                    b.Navigation("User");
                });

            modelBuilder.Entity("LigaDeFotbal.BBL.Entities.Competition", b =>
                {
                    b.Navigation("Bets");

                    b.Navigation("UserCompetitions");
                });

            modelBuilder.Entity("LigaDeFotbal.BBL.Entities.Game", b =>
                {
                    b.Navigation("Bets");
                });

            modelBuilder.Entity("LigaDeFotbal.BBL.Entities.Team", b =>
                {
                    b.Navigation("Games");
                });

            modelBuilder.Entity("LigaDeFotbal.BBL.Entities.User", b =>
                {
                    b.Navigation("Bets");

                    b.Navigation("UserCompetitions");
                });
#pragma warning restore 612, 618
        }
    }
}
