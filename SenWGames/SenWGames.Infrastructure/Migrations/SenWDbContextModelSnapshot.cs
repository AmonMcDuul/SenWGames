﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SenWGames.Infrastructure;

#nullable disable

namespace SenWGames.Infrastructure.Migrations
{
    [DbContext(typeof(SenWDbContext))]
    partial class SenWDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GameLobbyPlayer", b =>
                {
                    b.Property<long>("GamesPlayedId")
                        .HasColumnType("bigint");

                    b.Property<long>("PlayersId")
                        .HasColumnType("bigint");

                    b.HasKey("GamesPlayedId", "PlayersId");

                    b.HasIndex("PlayersId");

                    b.ToTable("GameLobbyPlayer");
                });

            modelBuilder.Entity("SenWGames.Core.Domain.Entities.Game", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Game");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Game");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("SenWGames.Core.Domain.Entities.GameLobby", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<long?>("GameId")
                        .HasColumnType("bigint");

                    b.Property<long?>("GroupId")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.HasIndex("GroupId");

                    b.ToTable("GameLobby");
                });

            modelBuilder.Entity("SenWGames.Core.Domain.Entities.Group", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<long?>("GameLobbyId")
                        .HasColumnType("bigint");

                    b.Property<string>("GroupId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GroupLeaderId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GroupName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("GameLobbyId");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("SenWGames.Core.Domain.Entities.Player", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Avatar")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("Draws")
                        .HasColumnType("int");

                    b.Property<long?>("GroupId")
                        .HasColumnType("bigint");

                    b.Property<double>("LocationX")
                        .HasColumnType("float");

                    b.Property<double>("LocationY")
                        .HasColumnType("float");

                    b.Property<int?>("Loses")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PlayerId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("Wins")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.ToTable("Player");
                });

            modelBuilder.Entity("SenWGames.Core.Domain.Entities.Games.FourInARow", b =>
                {
                    b.HasBaseType("SenWGames.Core.Domain.Entities.Game");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("FourInARow");
                });

            modelBuilder.Entity("SenWGames.Core.Domain.Entities.Games.TicTacToe", b =>
                {
                    b.HasBaseType("SenWGames.Core.Domain.Entities.Game");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("Game", t =>
                        {
                            t.Property("Description")
                                .HasColumnName("TicTacToe_Description");
                        });

                    b.HasDiscriminator().HasValue("TicTacToe");
                });

            modelBuilder.Entity("GameLobbyPlayer", b =>
                {
                    b.HasOne("SenWGames.Core.Domain.Entities.GameLobby", null)
                        .WithMany()
                        .HasForeignKey("GamesPlayedId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SenWGames.Core.Domain.Entities.Player", null)
                        .WithMany()
                        .HasForeignKey("PlayersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SenWGames.Core.Domain.Entities.GameLobby", b =>
                {
                    b.HasOne("SenWGames.Core.Domain.Entities.Game", "Game")
                        .WithMany()
                        .HasForeignKey("GameId");

                    b.HasOne("SenWGames.Core.Domain.Entities.Group", null)
                        .WithMany("PlayedGames")
                        .HasForeignKey("GroupId");

                    b.Navigation("Game");
                });

            modelBuilder.Entity("SenWGames.Core.Domain.Entities.Group", b =>
                {
                    b.HasOne("SenWGames.Core.Domain.Entities.GameLobby", "GameLobby")
                        .WithMany()
                        .HasForeignKey("GameLobbyId");

                    b.Navigation("GameLobby");
                });

            modelBuilder.Entity("SenWGames.Core.Domain.Entities.Player", b =>
                {
                    b.HasOne("SenWGames.Core.Domain.Entities.Group", null)
                        .WithMany("Players")
                        .HasForeignKey("GroupId");
                });

            modelBuilder.Entity("SenWGames.Core.Domain.Entities.Group", b =>
                {
                    b.Navigation("PlayedGames");

                    b.Navigation("Players");
                });
#pragma warning restore 612, 618
        }
    }
}
