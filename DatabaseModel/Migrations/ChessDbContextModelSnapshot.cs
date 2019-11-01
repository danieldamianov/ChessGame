﻿// <auto-generated />
using DatabaseModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DatabaseModel.Migrations
{
    [DbContext(typeof(ChessDbContext))]
    partial class ChessDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.0-rtm-35687")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DatabaseModel.Modles.Castling", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("GameId");

                    b.Property<int>("OrderInTheGame");

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.ToTable("Castling");
                });

            modelBuilder.Entity("DatabaseModel.Modles.Game", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("Id");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("DatabaseModel.Modles.NormalMoveDabModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FigureColor")
                        .IsRequired();

                    b.Property<string>("FigureType")
                        .IsRequired();

                    b.Property<int>("GameId");

                    b.Property<string>("InitialPosHorizontal")
                        .IsRequired()
                        .HasConversion(new ValueConverter<string, string>(v => default(string), v => default(string), new ConverterMappingHints(size: 1)));

                    b.Property<int>("InitialPosVertical");

                    b.Property<int>("OrderInTheGame");

                    b.Property<string>("TargetPosHorizontal")
                        .IsRequired()
                        .HasConversion(new ValueConverter<string, string>(v => default(string), v => default(string), new ConverterMappingHints(size: 1)));

                    b.Property<int>("TargetPosVertical");

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.ToTable("NormalMoveDabModel");
                });

            modelBuilder.Entity("DatabaseModel.Modles.ProducingPawn", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("GameId");

                    b.Property<int>("OrderInTheGame");

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.ToTable("ProducingPawn");
                });

            modelBuilder.Entity("DatabaseModel.Modles.UsersGame", b =>
                {
                    b.Property<int>("FirstUserId");

                    b.Property<int>("SecondUserId");

                    b.Property<int>("GameId");

                    b.Property<string>("Result");

                    b.HasKey("FirstUserId", "SecondUserId", "GameId");

                    b.HasIndex("GameId");

                    b.HasIndex("SecondUserId");

                    b.ToTable("UsersGames");
                });

            modelBuilder.Entity("DatabaseModel.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Password")
                        .IsRequired();

                    b.Property<string>("Username")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("DatabaseModel.Modles.Castling", b =>
                {
                    b.HasOne("DatabaseModel.Modles.Game", "Game")
                        .WithMany("Castlings")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DatabaseModel.Modles.NormalMoveDabModel", b =>
                {
                    b.HasOne("DatabaseModel.Modles.Game", "Game")
                        .WithMany("NormalMoves")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DatabaseModel.Modles.ProducingPawn", b =>
                {
                    b.HasOne("DatabaseModel.Modles.Game", "Game")
                        .WithMany("ProducingPawns")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DatabaseModel.Modles.UsersGame", b =>
                {
                    b.HasOne("DatabaseModel.User", "FirstUser")
                        .WithMany("UsersGamesLikeWhite")
                        .HasForeignKey("FirstUserId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("DatabaseModel.Modles.Game", "Game")
                        .WithMany("UsersGames")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("DatabaseModel.User", "SecondUser")
                        .WithMany("UsersGamesLikeBlack")
                        .HasForeignKey("SecondUserId")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}
