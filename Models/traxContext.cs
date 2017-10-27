using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TraxNETBackend.Models
{
    public partial class TraxContext : DbContext
    {
        public virtual DbSet<AudioFiles> AudioFiles { get; set; }
        public virtual DbSet<Images> Images { get; set; }
        public virtual DbSet<Migrations> Migrations { get; set; }
        public virtual DbSet<OauthAccessTokens> OauthAccessTokens { get; set; }
        public virtual DbSet<OauthAuthCodes> OauthAuthCodes { get; set; }
        public virtual DbSet<OauthClients> OauthClients { get; set; }
        public virtual DbSet<OauthPersonalAccessClients> OauthPersonalAccessClients { get; set; }
        public virtual DbSet<OauthRefreshTokens> OauthRefreshTokens { get; set; }
        public virtual DbSet<PasswordResets> PasswordResets { get; set; }
        public virtual DbSet<Tracks> Tracks { get; set; }
        public virtual DbSet<UserFavorites> UserFavorites { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
            optionsBuilder.UseMySql(@"server=localhost;port=3306;user=root;password=;database=trax");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AudioFiles>(entity =>
            {
                entity.ToTable("audio_files", "trax");

                entity.HasIndex(e => e.FileName)
                    .HasName("audio_files_filename_unique")
                    .IsUnique();

                entity.HasIndex(e => e.TrackId)
                    .HasName("track_id")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("timestamp");

                entity.Property(e => e.FileName)
                    .IsRequired()
                    .HasColumnName("fileName")
                    .HasColumnType("varchar(191)")
                    .HasMaxLength(191);

                entity.Property(e => e.TrackId)
                    .HasColumnName("track_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("timestamp");
            });

            modelBuilder.Entity<Images>(entity =>
            {
                entity.ToTable("images", "trax");

                entity.HasIndex(e => e.FileName)
                    .HasName("images_filename_unique")
                    .IsUnique();

                entity.HasIndex(e => new { e.ImageableId, e.ImageableType })
                    .HasName("imageable_id_imageable_type")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("timestamp");

                entity.Property(e => e.FileName)
                    .IsRequired()
                    .HasColumnName("fileName")
                    .HasColumnType("varchar(191)")
                    .HasMaxLength(191);

                entity.Property(e => e.ImageableId)
                    .HasColumnName("imageable_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ImageableType)
                    .IsRequired()
                    .HasColumnName("imageable_type")
                    .HasColumnType("varchar(191)")
                    .HasMaxLength(191);

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("timestamp");
            });

            modelBuilder.Entity<Migrations>(entity =>
            {
                entity.ToTable("migrations", "trax");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.Batch)
                    .HasColumnName("batch")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Migration)
                    .IsRequired()
                    .HasColumnName("migration")
                    .HasColumnType("varchar(191)")
                    .HasMaxLength(191);
            });

            modelBuilder.Entity<OauthAccessTokens>(entity =>
            {
                entity.ToTable("oauth_access_tokens", "trax");

                entity.HasIndex(e => e.UserId)
                    .HasName("oauth_access_tokens_user_id_index");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("varchar(100)")
                    .HasMaxLength(100);

                entity.Property(e => e.ClientId)
                    .HasColumnName("client_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("timestamp");

                entity.Property(e => e.ExpiresAt).HasColumnName("expires_at");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("varchar(191)")
                    .HasMaxLength(191);

                entity.Property(e => e.Revoked)
                    .HasColumnName("revoked")
                    .HasColumnType("tinyint(1)");

                entity.Property(e => e.Scopes)
                    .HasColumnName("scopes")
                    .HasMaxLength(65535);

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("timestamp");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<OauthAuthCodes>(entity =>
            {
                entity.ToTable("oauth_auth_codes", "trax");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("varchar(100)")
                    .HasMaxLength(100);

                entity.Property(e => e.ClientId)
                    .HasColumnName("client_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ExpiresAt).HasColumnName("expires_at");

                entity.Property(e => e.Revoked)
                    .HasColumnName("revoked")
                    .HasColumnType("tinyint(1)");

                entity.Property(e => e.Scopes)
                    .HasColumnName("scopes")
                    .HasMaxLength(65535);

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<OauthClients>(entity =>
            {
                entity.ToTable("oauth_clients", "trax");

                entity.HasIndex(e => e.UserId)
                    .HasName("oauth_clients_user_id_index");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("timestamp");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(191)")
                    .HasMaxLength(191);

                entity.Property(e => e.PasswordClient)
                    .HasColumnName("password_client")
                    .HasColumnType("tinyint(1)");

                entity.Property(e => e.PersonalAccessClient)
                    .HasColumnName("personal_access_client")
                    .HasColumnType("tinyint(1)");

                entity.Property(e => e.Redirect)
                    .IsRequired()
                    .HasColumnName("redirect")
                    .HasMaxLength(65535);

                entity.Property(e => e.Revoked)
                    .HasColumnName("revoked")
                    .HasColumnType("tinyint(1)");

                entity.Property(e => e.Secret)
                    .IsRequired()
                    .HasColumnName("secret")
                    .HasColumnType("varchar(100)")
                    .HasMaxLength(100);

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("timestamp");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<OauthPersonalAccessClients>(entity =>
            {
                entity.ToTable("oauth_personal_access_clients", "trax");

                entity.HasIndex(e => e.ClientId)
                    .HasName("oauth_personal_access_clients_client_id_index");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.ClientId)
                    .HasColumnName("client_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("timestamp");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("timestamp");
            });

            modelBuilder.Entity<OauthRefreshTokens>(entity =>
            {
                entity.ToTable("oauth_refresh_tokens", "trax");

                entity.HasIndex(e => e.AccessTokenId)
                    .HasName("oauth_refresh_tokens_access_token_id_index");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("varchar(100)")
                    .HasMaxLength(100);

                entity.Property(e => e.AccessTokenId)
                    .IsRequired()
                    .HasColumnName("access_token_id")
                    .HasColumnType("varchar(100)")
                    .HasMaxLength(100);

                entity.Property(e => e.ExpiresAt).HasColumnName("expires_at");

                entity.Property(e => e.Revoked)
                    .HasColumnName("revoked")
                    .HasColumnType("tinyint(1)");
            });

            modelBuilder.Entity<PasswordResets>(entity =>
            {
                entity.ToTable("password_resets", "trax");

                entity.HasIndex(e => e.Email)
                    .HasName("password_resets_email_index");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("timestamp");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasColumnType("varchar(191)")
                    .HasMaxLength(191);

                entity.Property(e => e.Token)
                    .IsRequired()
                    .HasColumnName("token")
                    .HasColumnType("varchar(191)")
                    .HasMaxLength(191);
            });

            modelBuilder.Entity<Tracks>(entity =>
            {
                entity.ToTable("tracks", "trax");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("timestamp");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(191)")
                    .HasMaxLength(191);

                entity.Property(e => e.Slug)
                    .IsRequired()
                    .HasColumnName("slug")
                    .HasColumnType("varchar(191)")
                    .HasMaxLength(191);

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("timestamp");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<UserFavorites>(entity =>
            {
                entity.HasKey(e => new { e.TrackId, e.UserId })
                    .HasName("PRIMARY");

                entity.ToTable("user_favorites", "trax");

                entity.Property(e => e.TrackId)
                    .HasColumnName("track_id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasColumnType("int(10) unsigned");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.ToTable("users", "trax");

                entity.HasIndex(e => e.Email)
                    .HasName("users_email_unique")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("timestamp");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasColumnType("varchar(191)")
                    .HasMaxLength(191);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(191)")
                    .HasMaxLength(191);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasColumnType("varchar(191)")
                    .HasMaxLength(191);

                entity.Property(e => e.RememberToken)
                    .HasColumnName("remember_token")
                    .HasColumnType("varchar(100)")
                    .HasMaxLength(100);

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("timestamp");
            });
        }
    }
}