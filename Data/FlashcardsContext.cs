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

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
