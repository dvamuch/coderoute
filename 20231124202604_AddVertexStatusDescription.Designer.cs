﻿// <auto-generated />
using CodeRoute.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CodeRoute.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20231124202604_AddVertexStatusDescription")]
    partial class AddVertexStatusDescription
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("CodeRoute.Models.RelatedRoutes", b =>
                {
                    b.Property<int>("CurrentRouteId")
                        .HasColumnType("integer");

                    b.Property<int>("RelatedRouteId")
                        .HasColumnType("integer");

                    b.HasKey("CurrentRouteId", "RelatedRouteId");

                    b.HasIndex("RelatedRouteId");

                    b.ToTable("RelatedRoutes");
                });

            modelBuilder.Entity("CodeRoute.Models.Route", b =>
                {
                    b.Property<int>("RouteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("RouteId"));

                    b.Property<string>("Desctiption")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("MarkDownPage")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("RouteId");

                    b.HasAlternateKey("Title");

                    b.ToTable("Routes");
                });

            modelBuilder.Entity("CodeRoute.Models.RouteStatus", b =>
                {
                    b.Property<int>("RouteStatusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("RouteStatusId"));

                    b.Property<string>("StatusName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("RouteStatusId");

                    b.ToTable("RouteStatuses");
                });

            modelBuilder.Entity("CodeRoute.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("UserId"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("boolean");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("UserId");

                    b.HasAlternateKey("Email");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("CodeRoute.Models.UserRoute", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.Property<int>("RouteId")
                        .HasColumnType("integer");

                    b.Property<int>("RouteStatusId")
                        .HasColumnType("integer");

                    b.HasKey("UserId", "RouteId");

                    b.HasIndex("RouteId");

                    b.HasIndex("RouteStatusId");

                    b.ToTable("UserRoutes");
                });

            modelBuilder.Entity("CodeRoute.Models.UserVertex", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.Property<int>("VertexId")
                        .HasColumnType("integer");

                    b.Property<int>("StatusId")
                        .HasColumnType("integer");

                    b.HasKey("UserId", "VertexId");

                    b.HasIndex("StatusId");

                    b.HasIndex("VertexId");

                    b.ToTable("UserVertexes");
                });

            modelBuilder.Entity("CodeRoute.Models.Vertex", b =>
                {
                    b.Property<int>("VertexId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("VertexId"));

                    b.Property<string>("MarkdownPage")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("RouteId")
                        .HasColumnType("integer");

                    b.HasKey("VertexId");

                    b.ToTable("Vertexes");
                });

            modelBuilder.Entity("CodeRoute.Models.VertexConnection", b =>
                {
                    b.Property<int>("CurrentVertexId")
                        .HasColumnType("integer");

                    b.Property<int>("PreviousVertexId")
                        .HasColumnType("integer");

                    b.HasKey("CurrentVertexId", "PreviousVertexId");

                    b.HasIndex("PreviousVertexId");

                    b.ToTable("VertexConnections");
                });

            modelBuilder.Entity("CodeRoute.Models.VertexStatus", b =>
                {
                    b.Property<int>("StatusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("StatusId"));

                    b.Property<string>("StatusDescription")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("StatusName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("StatusId");

                    b.ToTable("VertexStatuses");
                });

            modelBuilder.Entity("CodeRoute.Models.RelatedRoutes", b =>
                {
                    b.HasOne("CodeRoute.Models.Route", "CurrentRoute")
                        .WithMany()
                        .HasForeignKey("CurrentRouteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CodeRoute.Models.Route", "RelatedRoute")
                        .WithMany()
                        .HasForeignKey("RelatedRouteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CurrentRoute");

                    b.Navigation("RelatedRoute");
                });

            modelBuilder.Entity("CodeRoute.Models.UserRoute", b =>
                {
                    b.HasOne("CodeRoute.Models.Route", "Route")
                        .WithMany()
                        .HasForeignKey("RouteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CodeRoute.Models.RouteStatus", "RouteStatus")
                        .WithMany()
                        .HasForeignKey("RouteStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CodeRoute.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Route");

                    b.Navigation("RouteStatus");

                    b.Navigation("User");
                });

            modelBuilder.Entity("CodeRoute.Models.UserVertex", b =>
                {
                    b.HasOne("CodeRoute.Models.VertexStatus", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CodeRoute.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CodeRoute.Models.Vertex", "Vertex")
                        .WithMany()
                        .HasForeignKey("VertexId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Status");

                    b.Navigation("User");

                    b.Navigation("Vertex");
                });

            modelBuilder.Entity("CodeRoute.Models.VertexConnection", b =>
                {
                    b.HasOne("CodeRoute.Models.Vertex", "CurrentVertex")
                        .WithMany()
                        .HasForeignKey("CurrentVertexId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CodeRoute.Models.Vertex", "PreviousVertex")
                        .WithMany()
                        .HasForeignKey("PreviousVertexId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CurrentVertex");

                    b.Navigation("PreviousVertex");
                });
#pragma warning restore 612, 618
        }
    }
}
