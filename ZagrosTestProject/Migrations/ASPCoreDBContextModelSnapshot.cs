﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ZagrosTestProject.Entities;

namespace ZagrosTestProject.Migrations
{
    [DbContext(typeof(ASPCoreDBContext))]
    partial class ASPCoreDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CustomCookieAuthentication.Entities.Users", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName");

                    b.Property<bool>("IsActive");

                    b.Property<string>("LastName");

                    b.Property<string>("Password");

                    b.Property<string>("UserName");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ZagrosTestProject.Education", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("EducationDegreeTypeId");

                    b.Property<int>("EducationId");

                    b.Property<DateTime>("FromDate");

                    b.Property<int>("PersonnelId");

                    b.Property<DateTime>("ToDate");

                    b.HasKey("Id");

                    b.HasIndex("EducationDegreeTypeId");

                    b.HasIndex("PersonnelId");

                    b.ToTable("Educations");
                });

            modelBuilder.Entity("ZagrosTestProject.EducationDegreeType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("EducationDegreeDescription");

                    b.Property<string>("EducationDegreeTitle");

                    b.HasKey("Id");

                    b.ToTable("EducationDegreeTypes");
                });

            modelBuilder.Entity("ZagrosTestProject.Entities.GenderType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("GenderDescription");

                    b.Property<string>("GenderTitle");

                    b.HasKey("Id");

                    b.ToTable("GenderTypes");
                });

            modelBuilder.Entity("ZagrosTestProject.MaritalStatusType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("MaritalStatusDescription");

                    b.Property<string>("MaritalStatusTitle");

                    b.HasKey("Id");

                    b.ToTable("MaritalStatusTypes");
                });

            modelBuilder.Entity("ZagrosTestProject.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Birthdate");

                    b.Property<string>("FirstName");

                    b.Property<int>("GenderId");

                    b.Property<string>("LastName");

                    b.Property<int>("MaritalStatusId");

                    b.HasKey("Id");

                    b.HasIndex("GenderId");

                    b.HasIndex("MaritalStatusId");

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("ZagrosTestProject.Personnel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Birthdate");

                    b.Property<string>("FirstName");

                    b.Property<int>("GenderId");

                    b.Property<string>("LastName");

                    b.Property<int>("MaritalStatusId");

                    b.Property<int>("PositionId");

                    b.HasKey("Id");

                    b.HasIndex("GenderId");

                    b.HasIndex("MaritalStatusId");

                    b.HasIndex("PositionId");

                    b.ToTable("Personnels");
                });

            modelBuilder.Entity("ZagrosTestProject.PositionType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("PositionDescription");

                    b.Property<string>("PositionTitle");

                    b.HasKey("Id");

                    b.ToTable("PositionTypes");
                });

            modelBuilder.Entity("ZagrosTestProject.Education", b =>
                {
                    b.HasOne("ZagrosTestProject.EducationDegreeType", "EducationDegreeType")
                        .WithMany("Education")
                        .HasForeignKey("EducationDegreeTypeId");

                    b.HasOne("ZagrosTestProject.Personnel", "Personnel")
                        .WithMany("Education")
                        .HasForeignKey("PersonnelId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ZagrosTestProject.Person", b =>
                {
                    b.HasOne("ZagrosTestProject.Entities.GenderType", "Gender")
                        .WithMany("Person")
                        .HasForeignKey("GenderId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ZagrosTestProject.MaritalStatusType", "MaritalStatus")
                        .WithMany("Person")
                        .HasForeignKey("MaritalStatusId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ZagrosTestProject.Personnel", b =>
                {
                    b.HasOne("ZagrosTestProject.Entities.GenderType", "Gender")
                        .WithMany("Personnel")
                        .HasForeignKey("GenderId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ZagrosTestProject.MaritalStatusType", "MaritalStatus")
                        .WithMany("Personnel")
                        .HasForeignKey("MaritalStatusId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ZagrosTestProject.PositionType", "Position")
                        .WithMany("Personnel")
                        .HasForeignKey("PositionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
