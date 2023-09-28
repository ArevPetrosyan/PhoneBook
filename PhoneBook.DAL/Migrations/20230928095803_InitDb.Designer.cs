﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using PhoneBook.DAL;

#nullable disable

namespace PhoneBook.DAL.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230928095803_InitDb")]
    partial class InitDb
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("PhoneBook.DAL.Models.Contact", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long>("ContactTypeId")
                        .HasColumnType("bigint")
                        .HasColumnName("contact_type_id");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_date");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean")
                        .HasColumnName("is_deleted");

                    b.Property<DateTime?>("ModifyDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("modify_date");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)")
                        .HasColumnName("name");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("phone_number");

                    b.Property<string>("TextComment")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("text_comment");

                    b.HasKey("Id")
                        .HasName("pk_contact");

                    b.HasIndex("ContactTypeId")
                        .HasDatabaseName("ix_contact_contact_type_id");

                    b.HasIndex("CreatedDate")
                        .HasDatabaseName("ix_contact_created_date");

                    b.HasIndex("IsDeleted")
                        .HasDatabaseName("ix_contact_is_deleted");

                    b.ToTable("Contact", (string)null);
                });

            modelBuilder.Entity("PhoneBook.DAL.Models.ContactType", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_date");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean")
                        .HasColumnName("is_deleted");

                    b.Property<DateTime?>("ModifyDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("modify_date");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("pk_contact_type");

                    b.HasIndex("CreatedDate")
                        .HasDatabaseName("ix_contact_type_created_date");

                    b.HasIndex("IsDeleted")
                        .HasDatabaseName("ix_contact_type_is_deleted");

                    b.ToTable("ContactType", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            CreatedDate = new DateTime(2023, 9, 28, 9, 58, 3, 334, DateTimeKind.Utc).AddTicks(681),
                            IsDeleted = false,
                            Name = "Person"
                        },
                        new
                        {
                            Id = 2L,
                            CreatedDate = new DateTime(2023, 9, 28, 9, 58, 3, 334, DateTimeKind.Utc).AddTicks(700),
                            IsDeleted = false,
                            Name = "Private organization"
                        },
                        new
                        {
                            Id = 3L,
                            CreatedDate = new DateTime(2023, 9, 28, 9, 58, 3, 334, DateTimeKind.Utc).AddTicks(706),
                            IsDeleted = false,
                            Name = "Public organization"
                        });
                });

            modelBuilder.Entity("PhoneBook.DAL.Models.Person", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("address");

                    b.Property<long>("ContactId")
                        .HasColumnType("bigint")
                        .HasColumnName("contact_id");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_date");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("email");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean")
                        .HasColumnName("is_deleted");

                    b.Property<DateTime?>("ModifyDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("modify_date");

                    b.HasKey("Id")
                        .HasName("pk_person");

                    b.HasIndex("ContactId")
                        .HasDatabaseName("ix_person_contact_id");

                    b.HasIndex("CreatedDate")
                        .HasDatabaseName("ix_person_created_date");

                    b.HasIndex("IsDeleted")
                        .HasDatabaseName("ix_person_is_deleted");

                    b.ToTable("Person", (string)null);
                });

            modelBuilder.Entity("PhoneBook.DAL.Models.PrivateOrganization", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long>("ContactId")
                        .HasColumnType("bigint")
                        .HasColumnName("contact_id");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_date");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean")
                        .HasColumnName("is_deleted");

                    b.Property<DateTime?>("ModifyDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("modify_date");

                    b.Property<string>("OrganizationType")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("organization_type");

                    b.Property<string>("TaxId")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("tax_id");

                    b.HasKey("Id")
                        .HasName("pk_private_organization");

                    b.HasIndex("ContactId")
                        .HasDatabaseName("ix_private_organization_contact_id");

                    b.HasIndex("CreatedDate")
                        .HasDatabaseName("ix_private_organization_created_date");

                    b.HasIndex("IsDeleted")
                        .HasDatabaseName("ix_private_organization_is_deleted");

                    b.ToTable("PrivateOrganization", (string)null);
                });

            modelBuilder.Entity("PhoneBook.DAL.Models.PublicOrganization", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long>("ContactId")
                        .HasColumnType("bigint")
                        .HasColumnName("contact_id");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_date");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean")
                        .HasColumnName("is_deleted");

                    b.Property<DateTime?>("ModifyDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("modify_date");

                    b.Property<string>("PublicInfo")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("public_info");

                    b.Property<string>("Website")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("website");

                    b.HasKey("Id")
                        .HasName("pk_public_organization");

                    b.HasIndex("ContactId")
                        .HasDatabaseName("ix_public_organization_contact_id");

                    b.HasIndex("CreatedDate")
                        .HasDatabaseName("ix_public_organization_created_date");

                    b.HasIndex("IsDeleted")
                        .HasDatabaseName("ix_public_organization_is_deleted");

                    b.ToTable("PublicOrganization", (string)null);
                });

            modelBuilder.Entity("PhoneBook.DAL.Models.Contact", b =>
                {
                    b.HasOne("PhoneBook.DAL.Models.ContactType", "ContactType")
                        .WithMany()
                        .HasForeignKey("ContactTypeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("fk_contact_contact_types_contact_type_id");

                    b.Navigation("ContactType");
                });

            modelBuilder.Entity("PhoneBook.DAL.Models.Person", b =>
                {
                    b.HasOne("PhoneBook.DAL.Models.Contact", "Contact")
                        .WithMany()
                        .HasForeignKey("ContactId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("fk_person_contact_contact_id");

                    b.Navigation("Contact");
                });

            modelBuilder.Entity("PhoneBook.DAL.Models.PrivateOrganization", b =>
                {
                    b.HasOne("PhoneBook.DAL.Models.Contact", "Contact")
                        .WithMany()
                        .HasForeignKey("ContactId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("fk_private_organization_contact_contact_id");

                    b.Navigation("Contact");
                });

            modelBuilder.Entity("PhoneBook.DAL.Models.PublicOrganization", b =>
                {
                    b.HasOne("PhoneBook.DAL.Models.Contact", "Contact")
                        .WithMany()
                        .HasForeignKey("ContactId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("fk_public_organization_contact_contact_id");

                    b.Navigation("Contact");
                });
#pragma warning restore 612, 618
        }
    }
}
