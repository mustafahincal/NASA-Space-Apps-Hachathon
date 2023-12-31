﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Teapot.DataAccess.Contexts;

#nullable disable

namespace Teapot.DataAccess.Migrations
{
    [DbContext(typeof(Teapot418DbContext))]
    [Migration("20231008052429_ModifyChatTable2")]
    partial class ModifyChatTable2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Teapot.Core.Entities.Concrete.OperationClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("pk_operation_claims");

                    b.ToTable("operation_claims", (string)null);
                });

            modelBuilder.Entity("Teapot.Core.Entities.Concrete.UserOperationClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("OperationClaimId")
                        .HasColumnType("integer")
                        .HasColumnName("operation_claim_id");

                    b.Property<int>("UserId")
                        .HasColumnType("integer")
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("pk_user_operation_claims");

                    b.HasIndex("OperationClaimId")
                        .HasDatabaseName("ix_user_operation_claims_operation_claim_id");

                    b.ToTable("user_operation_claims", (string)null);
                });

            modelBuilder.Entity("Teapot.Entities.Concrete.AppUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("email");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("first_name");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("last_name");

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("bytea")
                        .HasColumnName("password_hash");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnType("bytea")
                        .HasColumnName("password_salt");

                    b.Property<int>("RegisterTypeId")
                        .HasColumnType("integer")
                        .HasColumnName("register_type_id");

                    b.Property<bool>("Status")
                        .HasColumnType("boolean")
                        .HasColumnName("status");

                    b.HasKey("Id")
                        .HasName("pk_users");

                    b.ToTable("users", (string)null);
                });

            modelBuilder.Entity("Teapot.Entities.Concrete.Chat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ContributerId")
                        .HasColumnType("integer")
                        .HasColumnName("contributer_id");

                    b.Property<int>("ProjectOwnerId")
                        .HasColumnType("integer")
                        .HasColumnName("project_owner_id");

                    b.HasKey("Id")
                        .HasName("pk_chats");

                    b.HasIndex("ContributerId")
                        .HasDatabaseName("ix_chats_contributer_id");

                    b.HasIndex("ProjectOwnerId")
                        .HasDatabaseName("ix_chats_project_owner_id");

                    b.ToTable("chats", (string)null);
                });

            modelBuilder.Entity("Teapot.Entities.Concrete.ChatHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("message");

                    b.Property<int>("ProjectId")
                        .HasColumnType("integer")
                        .HasColumnName("project_id");

                    b.Property<int>("ReceiverId")
                        .HasColumnType("integer")
                        .HasColumnName("receiver_id");

                    b.Property<int>("SenderId")
                        .HasColumnType("integer")
                        .HasColumnName("sender_id");

                    b.HasKey("Id")
                        .HasName("pk_chat_histories");

                    b.HasIndex("ProjectId")
                        .HasDatabaseName("ix_chat_histories_project_id");

                    b.HasIndex("ReceiverId")
                        .HasDatabaseName("ix_chat_histories_receiver_id");

                    b.HasIndex("SenderId")
                        .HasDatabaseName("ix_chat_histories_sender_id");

                    b.ToTable("chat_histories", (string)null);
                });

            modelBuilder.Entity("Teapot.Entities.Concrete.Invite", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ContributorId")
                        .HasColumnType("integer")
                        .HasColumnName("contributor_id");

                    b.Property<int>("ProjectId")
                        .HasColumnType("integer")
                        .HasColumnName("project_id");

                    b.Property<bool>("Status")
                        .HasColumnType("boolean")
                        .HasColumnName("status");

                    b.HasKey("Id")
                        .HasName("pk_invites");

                    b.HasIndex("ContributorId")
                        .HasDatabaseName("ix_invites_contributor_id");

                    b.HasIndex("ProjectId")
                        .HasDatabaseName("ix_invites_project_id");

                    b.ToTable("invites", (string)null);
                });

            modelBuilder.Entity("Teapot.Entities.Concrete.Message", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ChatId")
                        .HasColumnType("integer")
                        .HasColumnName("chat_id");

                    b.Property<int>("SenderId")
                        .HasColumnType("integer")
                        .HasColumnName("sender_id");

                    b.HasKey("Id")
                        .HasName("pk_messages");

                    b.HasIndex("ChatId")
                        .HasDatabaseName("ix_messages_chat_id");

                    b.HasIndex("SenderId")
                        .HasDatabaseName("ix_messages_sender_id");

                    b.ToTable("messages", (string)null);
                });

            modelBuilder.Entity("Teapot.Entities.Concrete.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<int>("OwnerId")
                        .HasColumnType("integer")
                        .HasColumnName("owner_id");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("title");

                    b.HasKey("Id")
                        .HasName("pk_projects");

                    b.HasIndex("OwnerId")
                        .HasDatabaseName("ix_projects_owner_id");

                    b.ToTable("projects", (string)null);
                });

            modelBuilder.Entity("Teapot.Entities.Concrete.ProjectContributor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ContributorId")
                        .HasColumnType("integer")
                        .HasColumnName("contributor_id");

                    b.Property<int>("ProjectId")
                        .HasColumnType("integer")
                        .HasColumnName("project_id");

                    b.HasKey("Id")
                        .HasName("pk_project_contributors");

                    b.HasIndex("ContributorId")
                        .HasDatabaseName("ix_project_contributors_contributor_id");

                    b.HasIndex("ProjectId")
                        .HasDatabaseName("ix_project_contributors_project_id");

                    b.ToTable("project_contributors", (string)null);
                });

            modelBuilder.Entity("Teapot.Entities.Concrete.ProjectFile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("image_url");

                    b.Property<int>("ProjectId")
                        .HasColumnType("integer")
                        .HasColumnName("project_id");

                    b.HasKey("Id")
                        .HasName("pk_project_files");

                    b.ToTable("project_files", (string)null);
                });

            modelBuilder.Entity("Teapot.Core.Entities.Concrete.UserOperationClaim", b =>
                {
                    b.HasOne("Teapot.Core.Entities.Concrete.OperationClaim", "OperationClaim")
                        .WithMany()
                        .HasForeignKey("OperationClaimId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_user_operation_claims_operation_claims_operation_claim_id");

                    b.Navigation("OperationClaim");
                });

            modelBuilder.Entity("Teapot.Entities.Concrete.Chat", b =>
                {
                    b.HasOne("Teapot.Entities.Concrete.AppUser", "Contributer")
                        .WithMany()
                        .HasForeignKey("ContributerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_chats_users_contributer_id");

                    b.HasOne("Teapot.Entities.Concrete.AppUser", "ProjectOwner")
                        .WithMany()
                        .HasForeignKey("ProjectOwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_chats_users_project_owner_id");

                    b.Navigation("Contributer");

                    b.Navigation("ProjectOwner");
                });

            modelBuilder.Entity("Teapot.Entities.Concrete.ChatHistory", b =>
                {
                    b.HasOne("Teapot.Entities.Concrete.Project", "Project")
                        .WithMany()
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_chat_histories_projects_project_id");

                    b.HasOne("Teapot.Entities.Concrete.AppUser", "Receiver")
                        .WithMany()
                        .HasForeignKey("ReceiverId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_chat_histories_users_receiver_id");

                    b.HasOne("Teapot.Entities.Concrete.AppUser", "Sender")
                        .WithMany()
                        .HasForeignKey("SenderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_chat_histories_users_sender_id");

                    b.Navigation("Project");

                    b.Navigation("Receiver");

                    b.Navigation("Sender");
                });

            modelBuilder.Entity("Teapot.Entities.Concrete.Invite", b =>
                {
                    b.HasOne("Teapot.Entities.Concrete.AppUser", "Contributor")
                        .WithMany()
                        .HasForeignKey("ContributorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_invites_users_contributor_id");

                    b.HasOne("Teapot.Entities.Concrete.Project", "Project")
                        .WithMany()
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_invites_projects_project_id");

                    b.Navigation("Contributor");

                    b.Navigation("Project");
                });

            modelBuilder.Entity("Teapot.Entities.Concrete.Message", b =>
                {
                    b.HasOne("Teapot.Entities.Concrete.Chat", "Chat")
                        .WithMany("Messages")
                        .HasForeignKey("ChatId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_messages_chats_chat_id");

                    b.HasOne("Teapot.Entities.Concrete.AppUser", "Sender")
                        .WithMany()
                        .HasForeignKey("SenderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_messages_users_sender_id");

                    b.Navigation("Chat");

                    b.Navigation("Sender");
                });

            modelBuilder.Entity("Teapot.Entities.Concrete.Project", b =>
                {
                    b.HasOne("Teapot.Entities.Concrete.AppUser", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_projects_users_owner_id");

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("Teapot.Entities.Concrete.ProjectContributor", b =>
                {
                    b.HasOne("Teapot.Entities.Concrete.AppUser", "Contributor")
                        .WithMany("Projects")
                        .HasForeignKey("ContributorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_project_contributors_users_contributor_id");

                    b.HasOne("Teapot.Entities.Concrete.Project", "Project")
                        .WithMany("Contributors")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_project_contributors_projects_project_id");

                    b.Navigation("Contributor");

                    b.Navigation("Project");
                });

            modelBuilder.Entity("Teapot.Entities.Concrete.AppUser", b =>
                {
                    b.Navigation("Projects");
                });

            modelBuilder.Entity("Teapot.Entities.Concrete.Chat", b =>
                {
                    b.Navigation("Messages");
                });

            modelBuilder.Entity("Teapot.Entities.Concrete.Project", b =>
                {
                    b.Navigation("Contributors");
                });
#pragma warning restore 612, 618
        }
    }
}
