﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using sticky_tunes_backend.Data;

#nullable disable

namespace sticky_tunes_backend.Migrations
{
    [DbContext(typeof(StickyTunesDbContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("ArtistTrack", b =>
                {
                    b.Property<int>("ArtistsId")
                        .HasColumnType("int");

                    b.Property<int>("TracksId")
                        .HasColumnType("int");

                    b.HasKey("ArtistsId", "TracksId");

                    b.HasIndex("TracksId");

                    b.ToTable("ArtistTrack");
                });

            modelBuilder.Entity("sticky_tunes_backend.Models.Artist", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Artists");
                });

            modelBuilder.Entity("sticky_tunes_backend.Models.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("DatePosted")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("PostId")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .HasColumnType("longtext");

                    b.Property<int>("TrackId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PostId");

                    b.HasIndex("TrackId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("sticky_tunes_backend.Models.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("DatePosted")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("TrackId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TrackId");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("sticky_tunes_backend.Models.Track", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("AlbumName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("SpotifyTrackId")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Tracks");
                });

            modelBuilder.Entity("ArtistTrack", b =>
                {
                    b.HasOne("sticky_tunes_backend.Models.Artist", null)
                        .WithMany()
                        .HasForeignKey("ArtistsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("sticky_tunes_backend.Models.Track", null)
                        .WithMany()
                        .HasForeignKey("TracksId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("sticky_tunes_backend.Models.Comment", b =>
                {
                    b.HasOne("sticky_tunes_backend.Models.Post", "Post")
                        .WithMany("Comments")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("sticky_tunes_backend.Models.Track", "Track")
                        .WithMany("Comments")
                        .HasForeignKey("TrackId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Post");

                    b.Navigation("Track");
                });

            modelBuilder.Entity("sticky_tunes_backend.Models.Post", b =>
                {
                    b.HasOne("sticky_tunes_backend.Models.Track", "Track")
                        .WithMany("Posts")
                        .HasForeignKey("TrackId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Track");
                });

            modelBuilder.Entity("sticky_tunes_backend.Models.Post", b =>
                {
                    b.Navigation("Comments");
                });

            modelBuilder.Entity("sticky_tunes_backend.Models.Track", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Posts");
                });
#pragma warning restore 612, 618
        }
    }
}
