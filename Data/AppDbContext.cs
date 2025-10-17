using Microsoft.EntityFrameworkCore;
using BimehApi.Models;

namespace BimehApi.Data;

public class AppDbContext : DbContext
{
    public DbSet<InsuranceRequest> InsuranceRequests { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<InsuranceRequest>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Title).IsRequired().HasMaxLength(200);
            entity.Property(e => e.Capital).IsRequired();
            entity.Property(e => e.Premium).HasColumnType("decimal(18,2)").IsRequired();
            entity.Property(e => e.CreatedAt).IsRequired();
        });

        base.OnModelCreating(modelBuilder);
    }
}