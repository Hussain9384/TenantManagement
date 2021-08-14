﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TenantManagement.InfraStructure.Database;

namespace TenantManagement.InfraStructure.Migrations
{
    [DbContext(typeof(TenantDatabase))]
    [Migration("20210814083118_AddTenantInformation")]
    partial class AddTenantInformation
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TenantManagement.InfraStructure.Entities.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AddressLine1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AddressLine2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AddressLine3")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PinCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StreetName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TenantId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TenantId");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("TenantManagement.InfraStructure.Entities.ContactDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AlternateEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MobileNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TelePhone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TenantId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TenantId");

                    b.ToTable("ContactDetails");
                });

            modelBuilder.Entity("TenantManagement.InfraStructure.Entities.Tenant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Tenants");
                });

            modelBuilder.Entity("TenantManagement.InfraStructure.Entities.TenantProperty", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TenantId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TenantId");

                    b.ToTable("TenantProperties");
                });

            modelBuilder.Entity("TenantManagement.InfraStructure.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TenantId")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("TenantId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("TenantManagement.InfraStructure.Entities.Address", b =>
                {
                    b.HasOne("TenantManagement.InfraStructure.Entities.Tenant", null)
                        .WithMany("AddressList")
                        .HasForeignKey("TenantId");
                });

            modelBuilder.Entity("TenantManagement.InfraStructure.Entities.ContactDetail", b =>
                {
                    b.HasOne("TenantManagement.InfraStructure.Entities.Tenant", null)
                        .WithMany("ContactDetails")
                        .HasForeignKey("TenantId");
                });

            modelBuilder.Entity("TenantManagement.InfraStructure.Entities.TenantProperty", b =>
                {
                    b.HasOne("TenantManagement.InfraStructure.Entities.Tenant", null)
                        .WithMany("Properties")
                        .HasForeignKey("TenantId");
                });

            modelBuilder.Entity("TenantManagement.InfraStructure.Entities.User", b =>
                {
                    b.HasOne("TenantManagement.InfraStructure.Entities.Tenant", null)
                        .WithMany("Users")
                        .HasForeignKey("TenantId");
                });

            modelBuilder.Entity("TenantManagement.InfraStructure.Entities.Tenant", b =>
                {
                    b.Navigation("AddressList");

                    b.Navigation("ContactDetails");

                    b.Navigation("Properties");

                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
