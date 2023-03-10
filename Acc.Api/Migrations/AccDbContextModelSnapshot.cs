// <auto-generated />
using System;
using Acc.Api.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace OjasTech.Acc.Api.Migrations
{
    [DbContext(typeof(AccDbContext))]
    partial class AccDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Ojastech.Acc.Api.Models.Entity.Account", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)")
                        .HasColumnName("created_by");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("modified_at");

                    b.Property<string>("ModifiedBy")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)")
                        .HasColumnName("modified_by");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("pk_accounts");

                    b.ToTable("accounts", (string)null);
                });

            modelBuilder.Entity("Ojastech.Acc.Api.Models.Entity.AccountUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<Guid>("AccountId")
                        .HasColumnType("uuid")
                        .HasColumnName("account_id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)")
                        .HasColumnName("created_by");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("modified_at");

                    b.Property<string>("ModifiedBy")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)")
                        .HasColumnName("modified_by");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid")
                        .HasColumnName("user_id");

                    b.Property<int>("UserRoleId")
                        .HasColumnType("integer")
                        .HasColumnName("user_role_id");

                    b.HasKey("Id")
                        .HasName("pk_account_users");

                    b.HasIndex("AccountId")
                        .HasDatabaseName("ix_account_users_account_id");

                    b.HasIndex("UserId")
                        .HasDatabaseName("ix_account_users_user_id");

                    b.HasIndex("UserRoleId")
                        .HasDatabaseName("ix_account_users_user_role_id");

                    b.ToTable("account_users", (string)null);
                });

            modelBuilder.Entity("Ojastech.Acc.Api.Models.Enum.Lookup.UserRoleLookup", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    b.Property<string>("Description")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)")
                        .HasColumnName("description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("pk_user_roles");

                    b.ToTable("user_roles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 0,
                            Description = "Normal User",
                            Name = "User"
                        },
                        new
                        {
                            Id = 1000,
                            Description = "Admin User",
                            Name = "Admin"
                        });
                });

            modelBuilder.Entity("Ojastech.Acc.ApiAddDbContext.Models.Entity.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)")
                        .HasColumnName("created_by");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)")
                        .HasColumnName("email");

                    b.Property<string>("ExternalLoginId")
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)")
                        .HasColumnName("external_login_id");

                    b.Property<string>("ExternalLoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)")
                        .HasColumnName("external_login_provider");

                    b.Property<string>("FirstName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)")
                        .HasColumnName("first_name");

                    b.Property<string>("LastName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)")
                        .HasColumnName("last_name");

                    b.Property<string>("MiddleName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)")
                        .HasColumnName("middle_name");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("modified_at");

                    b.Property<string>("ModifiedBy")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)")
                        .HasColumnName("modified_by");

                    b.Property<string>("Password")
                        .HasMaxLength(512)
                        .HasColumnType("character varying(512)")
                        .HasColumnName("password");

                    b.Property<string>("Phone")
                        .HasMaxLength(16)
                        .HasColumnType("character varying(16)")
                        .HasColumnName("phone");

                    b.HasKey("Id")
                        .HasName("pk_users");

                    b.HasIndex("Email")
                        .IsUnique()
                        .HasDatabaseName("ix_users_email");

                    b.HasIndex("Phone")
                        .IsUnique()
                        .HasDatabaseName("ix_users_phone");

                    b.ToTable("users", (string)null);
                });

            modelBuilder.Entity("Ojastech.Acc.Api.Models.Entity.AccountUser", b =>
                {
                    b.HasOne("Ojastech.Acc.Api.Models.Entity.Account", "Account")
                        .WithMany()
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_account_users_accounts_account_id");

                    b.HasOne("Ojastech.Acc.ApiAddDbContext.Models.Entity.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_account_users_users_user_id");

                    b.HasOne("Ojastech.Acc.Api.Models.Enum.Lookup.UserRoleLookup", "UserRole")
                        .WithMany()
                        .HasForeignKey("UserRoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_account_users_user_roles_user_role_id");

                    b.Navigation("Account");

                    b.Navigation("User");

                    b.Navigation("UserRole");
                });
#pragma warning restore 612, 618
        }
    }
}
