﻿// <auto-generated />
using System;
using E.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace E.Infrastructure.Migrations
{
    [DbContext(typeof(ExamenContext))]
    [Migration("20231211210420_KaycerKhouiniDB")]
    partial class KaycerKhouiniDB
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("E.ApplicationCore.Domain.Chauffeur", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<float>("TauxBenifice")
                        .HasColumnType("real");

                    b.Property<string>("VoitureNumMat")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("Id");

                    b.HasIndex("VoitureNumMat");

                    b.ToTable("Chauffeurs");
                });

            modelBuilder.Entity("E.ApplicationCore.Domain.Client", b =>
                {
                    b.Property<string>("CIN")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int?>("ChauffeurId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateNaissance")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Prenom")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("CIN");

                    b.HasIndex("ChauffeurId");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("E.ApplicationCore.Domain.Course", b =>
                {
                    b.Property<string>("VoitreFk")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("ClientFk")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<DateTime>("DateCourse")
                        .HasColumnType("datetime2");

                    b.Property<int>("Etat")
                        .HasColumnType("int");

                    b.Property<string>("LieuArrive")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("LieuDepart")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<double>("Montant")
                        .HasColumnType("float");

                    b.Property<bool>("PaiementEnligne")
                        .HasColumnType("bit");

                    b.HasKey("VoitreFk", "ClientFk", "DateCourse");

                    b.HasIndex("ClientFk");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("E.ApplicationCore.Domain.Voiture", b =>
                {
                    b.Property<string>("NumMat")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Couleur")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Marque")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("NumMat");

                    b.ToTable("Voitures");
                });

            modelBuilder.Entity("E.ApplicationCore.Domain.Chauffeur", b =>
                {
                    b.HasOne("E.ApplicationCore.Domain.Voiture", "Voiture")
                        .WithMany("Chauffeurs")
                        .HasForeignKey("VoitureNumMat")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Voiture");
                });

            modelBuilder.Entity("E.ApplicationCore.Domain.Client", b =>
                {
                    b.HasOne("E.ApplicationCore.Domain.Chauffeur", null)
                        .WithMany("Clients")
                        .HasForeignKey("ChauffeurId");
                });

            modelBuilder.Entity("E.ApplicationCore.Domain.Course", b =>
                {
                    b.HasOne("E.ApplicationCore.Domain.Client", "Client")
                        .WithMany("Courses")
                        .HasForeignKey("ClientFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("E.ApplicationCore.Domain.Voiture", "Voiture")
                        .WithMany("Courses")
                        .HasForeignKey("VoitreFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("Voiture");
                });

            modelBuilder.Entity("E.ApplicationCore.Domain.Chauffeur", b =>
                {
                    b.Navigation("Clients");
                });

            modelBuilder.Entity("E.ApplicationCore.Domain.Client", b =>
                {
                    b.Navigation("Courses");
                });

            modelBuilder.Entity("E.ApplicationCore.Domain.Voiture", b =>
                {
                    b.Navigation("Chauffeurs");

                    b.Navigation("Courses");
                });
#pragma warning restore 612, 618
        }
    }
}
