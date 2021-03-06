﻿// <auto-generated />
using System;
using CIBDigitalTechAssessment.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CIBDigitalTechAssessment.Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20191204222445_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CIBDigitalTechAssessment.Core.Entities.Entry", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime>("DateModified");

                    b.Property<string>("Name");

                    b.Property<int>("PhoneBookId");

                    b.Property<string>("PhoneNumber");

                    b.HasKey("Id");

                    b.HasIndex("PhoneBookId");

                    b.ToTable("Entries");
                });

            modelBuilder.Entity("CIBDigitalTechAssessment.Core.Entities.PhoneBook", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime>("DateModified");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("PhoneBooks");
                });

            modelBuilder.Entity("CIBDigitalTechAssessment.Core.Entities.Entry", b =>
                {
                    b.HasOne("CIBDigitalTechAssessment.Core.Entities.PhoneBook", "PhoneBook")
                        .WithMany("Entries")
                        .HasForeignKey("PhoneBookId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
