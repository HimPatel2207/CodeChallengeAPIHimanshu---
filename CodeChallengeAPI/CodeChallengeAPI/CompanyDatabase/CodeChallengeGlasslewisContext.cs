using System;
using System.Collections.Generic;
using CodeChallengeAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CodeChallenge.Repository.CompanyDatabase;

public partial class CodeChallengeGlasslewisContext : DbContext
{
    //private IConfiguration _config;
    public CodeChallengeGlasslewisContext()
    {
        //_config = config;
    }

    public CodeChallengeGlasslewisContext(DbContextOptions<CodeChallengeGlasslewisContext> options)
        : base(options)
    {
    }

    public virtual DbSet<User> User { get; set; }

    public virtual DbSet<CompanyModel> CompanyModel { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Data Source=HIMANSHU\\SQLEXPRESS;Initial Catalog=CodeChallengeGlasslewis;Integrated Security=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("dbo.tbl_UserMaster");

            entity.Property(e => e.Password).HasMaxLength(50);
            entity.Property(e => e.UserName).HasMaxLength(50);
        });

        modelBuilder.Entity<CompanyModel>(entity =>
        {
            entity.ToTable("tbl_companyData");

            entity.Property(e => e.Exchange).HasMaxLength(50);
            entity.Property(e => e.Isin)
                .HasMaxLength(12)
                .IsUnicode(false);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Ticker).HasMaxLength(10);
            entity.Property(e => e.Website).HasColumnName("website");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
