using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
namespace RecipeFinder.Model;

public partial class RecipeFinderContext : DbContext
{
    public RecipeFinderContext()
    {
    }

    public RecipeFinderContext(DbContextOptions<RecipeFinderContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Ingredient1> Ingredient1s { get; set; }

    public virtual DbSet<Meal> Meals { get; set; }

    public virtual DbSet<User> Users { get; set; }

    // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //     => optionsBuilder.UseSqlServer("Server=tcp:team-one.database.windows.net,1433;Initial Catalog=RecipeFinder;Persist Security Info=False;User ID=abdel;Password=Revature@2024;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("./appsettings.json")
            .Build();
        optionsBuilder.UseSqlServer(configuration.GetConnectionString("DataBaseLogingString"));
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Ingredient1>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Ingredie__3214EC27B1FC4C91");

            entity.ToTable("Ingredient1", "RecipeFinder");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Meal>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Meal__3214EC27BB85FFC3");

            entity.ToTable("Meal", "RecipeFinder");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Area)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Category)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Ingredient1)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Ingredient10)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Ingredient11)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Ingredient12)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Ingredient13)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Ingredient14)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Ingredient15)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Ingredient2)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Ingredient3)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Ingredient4)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Ingredient5)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Ingredient6)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Ingredient7)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Ingredient8)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Ingredient9)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Instructions)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.MealThumb)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Meal_thumb");
            entity.Property(e => e.Measure1)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Measure10)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Measure11)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Measure12)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Measure13)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Measure14)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Measure15)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Measure2)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Measure3)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Measure4)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Measure5)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Measure6)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Measure7)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Measure8)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Measure9)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Tags)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Youtube)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__User__3214EC27EC04DCFA");

            entity.ToTable("User", "RecipeFinder");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("First_name");
            entity.Property(e => e.LastName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Last_name");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Username)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
