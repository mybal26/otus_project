using AuthService.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AuthService.Data
{
    public class AppDbContext : IdentityDbContext<User>
    {
        public DbSet<RefreshToken> RefreshTokens { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) 
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Конфигурация для RefreshToken
            builder.Entity<RefreshToken>(entity =>
            {
                entity.HasKey(rt => rt.Id);
                
                entity.Property(rt => rt.Token)
                    .IsRequired()
                    .HasMaxLength(500);
                
                entity.Property(rt => rt.CreatedByIp)
                    .HasMaxLength(100);
                
                entity.Property(rt => rt.RevokedByIp)
                    .HasMaxLength(100);
                
                entity.Property(rt => rt.ReplacedByToken)
                    .HasMaxLength(500);

                // Связь с пользователем
                entity.HasOne(rt => rt.User)
                    .WithMany(u => u.RefreshTokens)
                    .HasForeignKey(rt => rt.UserId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            // Конфигурация для User
            builder.Entity<User>(entity =>
            {
                entity.Property(u => u.FirstName)
                    .HasMaxLength(100);
                
                entity.Property(u => u.LastName)
                    .HasMaxLength(100);
                
                entity.Property(u => u.CreatedAt)
                    .HasDefaultValueSql("NOW()");
                
                entity.HasMany(u => u.RefreshTokens)
                    .WithOne(rt => rt.User)
                    .HasForeignKey(rt => rt.UserId);
            });
        }
    }
}