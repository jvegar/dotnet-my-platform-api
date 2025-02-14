using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using dotnet_my_platform_api.Models;
using Microsoft.Extensions.Configuration;

namespace dotnet_my_platform_api.Data;

public partial class MyPlatformContext : DbContext
{
  private readonly string _connectionString;

  public MyPlatformContext(IConfiguration configuration)
      : base(new DbContextOptions<MyPlatformContext>())
  {
    _connectionString = configuration.GetConnectionString("DefaultConnection")
                        ?? throw new ArgumentNullException(nameof(configuration), "Connection string cannot be null.");
  }

  public virtual DbSet<Education> Educations { get; set; }

  public virtual DbSet<Experience> Experiences { get; set; }

  public virtual DbSet<PersonalInfo> PersonalInfos { get; set; }

  public virtual DbSet<Service> Services { get; set; }

  public virtual DbSet<Skill> Skills { get; set; }

  public virtual DbSet<TechStack> TechStacks { get; set; }

  public virtual DbSet<GitHubRepo> GitHubRepos { get; set; }

  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    if (!optionsBuilder.IsConfigured)
    {
      optionsBuilder.UseNpgsql(_connectionString);
    }
  }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<Education>(entity =>
    {
      entity.HasKey(e => e.Id).HasName("education_pkey");

      entity.ToTable("education");

      entity.Property(e => e.Id).HasColumnName("id");
      entity.Property(e => e.DateRange)
              .HasMaxLength(20)
              .HasColumnName("date_range");
      entity.Property(e => e.OrderIndex).HasColumnName("order_index");
      entity.Property(e => e.Subtitle)
              .HasMaxLength(255)
              .HasColumnName("subtitle");
      entity.Property(e => e.Title)
              .HasMaxLength(255)
              .HasColumnName("title");
    });

    modelBuilder.Entity<Experience>(entity =>
    {
      entity.HasKey(e => e.Id).HasName("experience_pkey");

      entity.ToTable("experience");

      entity.Property(e => e.Id).HasColumnName("id");
      entity.Property(e => e.Company)
              .HasMaxLength(255)
              .HasColumnName("company");
      entity.Property(e => e.DateRange)
              .HasMaxLength(20)
              .HasColumnName("date_range");
      entity.Property(e => e.OrderIndex).HasColumnName("order_index");
      entity.Property(e => e.Title)
              .HasMaxLength(255)
              .HasColumnName("title");
    });

    modelBuilder.Entity<PersonalInfo>(entity =>
    {
      entity.HasKey(e => e.Id).HasName("personal_info_pkey");

      entity.ToTable("personal_info");

      entity.Property(e => e.Id).HasColumnName("id");
      entity.Property(e => e.Description).HasColumnName("description");
      entity.Property(e => e.Email)
              .HasMaxLength(255)
              .HasColumnName("email");
      entity.Property(e => e.Name)
              .HasMaxLength(100)
              .HasColumnName("name");
      entity.Property(e => e.Phone)
              .HasMaxLength(20)
              .HasColumnName("phone");
      entity.Property(e => e.ProjectsCount).HasColumnName("projects_count");
    });

    modelBuilder.Entity<Service>(entity =>
    {
      entity.HasKey(e => e.Id).HasName("services_pkey");

      entity.ToTable("services");

      entity.Property(e => e.Id).HasColumnName("id");
      entity.Property(e => e.IconPath)
              .HasMaxLength(255)
              .HasColumnName("icon_path");
      entity.Property(e => e.OrderIndex).HasColumnName("order_index");
      entity.Property(e => e.Title)
              .HasMaxLength(50)
              .HasColumnName("title");
    });

    modelBuilder.Entity<Skill>(entity =>
    {
      entity.HasKey(e => e.Id).HasName("skills_pkey");

      entity.ToTable("skills");

      entity.Property(e => e.Id).HasColumnName("id");
      entity.Property(e => e.IsMainSkill)
              .HasDefaultValue(false)
              .HasColumnName("is_main_skill");
      entity.Property(e => e.LastMonth).HasColumnName("last_month");
      entity.Property(e => e.LastWeek).HasColumnName("last_week");
      entity.Property(e => e.Name)
              .HasMaxLength(100)
              .HasColumnName("name");
      entity.Property(e => e.OrderIndex).HasColumnName("order_index");
      entity.Property(e => e.Percentage).HasColumnName("percentage");
    });

    modelBuilder.Entity<TechStack>(entity =>
    {
      entity.HasKey(e => e.Id).HasName("tech_stack_pkey");

      entity.ToTable("tech_stack");

      entity.Property(e => e.Id).HasColumnName("id");
      entity.Property(e => e.IconPath)
              .HasMaxLength(255)
              .HasColumnName("icon_path");
      entity.Property(e => e.Name)
              .HasMaxLength(100)
              .HasColumnName("name");
      entity.Property(e => e.OrderIndex).HasColumnName("order_index");
      entity.Property(e => e.Url)
              .HasMaxLength(255)
              .HasColumnName("url");
    });

    OnModelCreatingPartial(modelBuilder);
  }

  partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
