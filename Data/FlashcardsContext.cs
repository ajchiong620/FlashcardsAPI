using System;
using System.Collections.Generic;
using FlashcardsAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FlashcardsAPI.Data;

public partial class FlashcardsContext : DbContext
{
    public FlashcardsContext()
    {
    }

    public FlashcardsContext(DbContextOptions<FlashcardsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Flashcard> Flashcards { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=ANSELMO-PC;Initial Catalog=FLASHCARDPROJ;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Flashcard>(entity =>
        {
            entity.HasKey(e => e.Qid).HasName("PK__Flashcar__C277C2214DE111DC");

            entity.ToTable("Flashcard");

            entity.Property(e => e.Qid)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("qid");
            entity.Property(e => e.Answer)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("answer");
            entity.Property(e => e.Question)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("question");
            entity.Property(e => e.Status)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("status");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__CB9A1CDF34860EB8");

            entity.HasIndex(e => e.Email, "UQ__Users__AB6E61648890B6DB").IsUnique();

            entity.HasIndex(e => new { e.Username, e.Email }, "UQ__Users__B96D2364558A9E61").IsUnique();

            entity.HasIndex(e => e.Username, "UQ__Users__F3DBC572E80558D5").IsUnique();

            entity.Property(e => e.UserId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("userID");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.PasswordHash)
                .HasMaxLength(255)
                .HasColumnName("passwordHash");
            entity.Property(e => e.Username)
                .HasMaxLength(100)
                .HasColumnName("username");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
