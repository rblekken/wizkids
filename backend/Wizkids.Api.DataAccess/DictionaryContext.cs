using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Wizkids.Api.DataAccess.Models;

namespace Wizkids.Api.DataAccess
{
    public partial class DictionaryContext : DbContext
    {
        public DictionaryContext()
        {
        }

        public DictionaryContext(DbContextOptions<DictionaryContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Word> Words { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Word>(entity =>
            {
                entity.HasIndex(e => e.Value, "Value");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
