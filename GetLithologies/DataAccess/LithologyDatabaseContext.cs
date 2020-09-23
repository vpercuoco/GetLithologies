using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace GetLithologies.DataAccess
{
    public partial class LithologyDatabaseContext : DbContext
    {
        public LithologyDatabaseContext()
        {
        }

        public LithologyDatabaseContext(DbContextOptions<LithologyDatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AllSections> AllSections { get; set; }
        public virtual DbSet<DescriptionColumnValuePairs> DescriptionColumnValuePairs { get; set; }
        public virtual DbSet<LithologicDescriptions> LithologicDescriptions { get; set; }
        public virtual DbSet<LithologicSubintervals> LithologicSubintervals { get; set; }
        public virtual DbSet<Lithologies> Lithologies { get; set; }
        public virtual DbSet<LithologyTable> LithologyTable { get; set; }
        public virtual DbSet<Sections> Sections { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=(localdb)\\ProjectsV13;Database=LithologyDatabase;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AllSections>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.BottomDepthCsfAM)
                    .HasColumnName("Bottom depth CSF-A (m)")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.BottomDepthCsfBM)
                    .HasColumnName("Bottom depth CSF-B (m)")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CatwalkSamplesNo)
                    .HasColumnName("Catwalk samples (no )")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Comments)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Core)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CuratedLengthM)
                    .HasColumnName("Curated length (m)")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Exp)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Hole)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RecoveredLengthM)
                    .HasColumnName("Recovered length (m)")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Sect)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SectionHalfSamplesNo)
                    .HasColumnName("Section half samples (no )")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Site)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TextIdOfArchiveHalf)
                    .HasColumnName("Text ID of archive half")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TextIdOfSection)
                    .HasColumnName("Text ID of section")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TextIdOfWorkingHalf)
                    .HasColumnName("Text ID of working half")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TopDepthCsfAM)
                    .HasColumnName("Top depth CSF-A (m)")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TopDepthCsfBM)
                    .HasColumnName("Top depth CSF-B (m)")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Type)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<DescriptionColumnValuePairs>(entity =>
            {
                entity.HasIndex(e => e.LithologicDescriptionLithologicId);

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ColumnName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CorrectedColumnNames)
                    .HasColumnName("corrected_column_names")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LithologicDescriptionLithologicId)
                    .HasColumnName("LithologicDescriptionLithologicID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value)
                    .HasMaxLength(5000)
                    .IsUnicode(false);

                entity.HasOne(d => d.LithologicDescriptionLithologic)
                    .WithMany(p => p.DescriptionColumnValuePairs)
                    .HasForeignKey(d => d.LithologicDescriptionLithologicId);
            });

            modelBuilder.Entity<LithologicDescriptions>(entity =>
            {
                entity.HasKey(e => e.LithologicId);

                entity.HasIndex(e => e.SectionInfoId);

                entity.Property(e => e.LithologicId)
                    .HasColumnName("LithologicID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DescriptionGroup)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DescriptionReport)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DescriptionTab)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DescriptionType)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SectionInfoId).HasColumnName("SectionInfoID");

                entity.HasOne(d => d.SectionInfo)
                    .WithMany(p => p.LithologicDescriptions)
                    .HasForeignKey(d => d.SectionInfoId);
            });

            modelBuilder.Entity<LithologicSubintervals>(entity =>
            {
                entity.HasIndex(e => e.LithologicDescriptionLithologicId);

                entity.HasIndex(e => e.SectionInfoId);

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.LithologicDescriptionLithologicId)
                    .HasColumnName("LithologicDescriptionLithologicID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LithologicSubId).HasColumnName("LithologicSubID");

                entity.Property(e => e.SectionInfoId).HasColumnName("SectionInfoID");

                entity.HasOne(d => d.LithologicDescriptionLithologic)
                    .WithMany(p => p.LithologicSubintervals)
                    .HasForeignKey(d => d.LithologicDescriptionLithologicId);

                entity.HasOne(d => d.SectionInfo)
                    .WithMany(p => p.LithologicSubintervals)
                    .HasForeignKey(d => d.SectionInfoId);
            });

            modelBuilder.Entity<Lithologies>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("lithologies");

                entity.Property(e => e.BottomOffsetCm)
                    .HasColumnName("Bottom Offset (cm)")
                    .HasMaxLength(5000)
                    .IsUnicode(false);

                entity.Property(e => e.LithologicDescriptionLithologicId)
                    .HasColumnName("LithologicDescriptionLithologicID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PrefixLithology)
                    .HasColumnName("Prefix Lithology")
                    .HasMaxLength(5000)
                    .IsUnicode(false);

                entity.Property(e => e.PrincipalLithology)
                    .HasColumnName("Principal Lithology")
                    .HasMaxLength(5000)
                    .IsUnicode(false);

                entity.Property(e => e.SuffixLithology)
                    .HasColumnName("Suffix Lithology")
                    .HasMaxLength(5000)
                    .IsUnicode(false);

                entity.Property(e => e.TopOffsetCm)
                    .HasColumnName("Top Offset (cm)")
                    .HasMaxLength(5000)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<LithologyTable>(entity =>
            {
                entity.HasKey(e => e.LithologicDescriptionLithologicId)
                    .HasName("PK__Litholog__6C8EC86F603ED2C8");

                entity.Property(e => e.LithologicDescriptionLithologicId)
                    .HasColumnName("LithologicDescriptionLithologicID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.BottomOffsetCm)
                    .HasColumnName("Bottom Offset (cm)")
                    .HasMaxLength(5000)
                    .IsUnicode(false);

                entity.Property(e => e.PrefixLithology)
                    .HasColumnName("Prefix Lithology")
                    .HasMaxLength(5000)
                    .IsUnicode(false);

                entity.Property(e => e.PrincipalLithology)
                    .HasColumnName("Principal Lithology")
                    .HasMaxLength(5000)
                    .IsUnicode(false);

                entity.Property(e => e.SuffixLithology)
                    .HasColumnName("Suffix Lithology")
                    .HasMaxLength(5000)
                    .IsUnicode(false);

                entity.Property(e => e.TopOffsetCm)
                    .HasColumnName("Top Offset (cm)")
                    .HasMaxLength(5000)
                    .IsUnicode(false);

                entity.HasOne(d => d.LithologicDescriptionLithologic)
                    .WithOne(p => p.LithologyTable)
                    .HasForeignKey<LithologyTable>(d => d.LithologicDescriptionLithologicId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Lithology__Litho__6B24EA82");
            });

            modelBuilder.Entity<Sections>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.SampleId).HasColumnName("SampleID");

                entity.Property(e => e.SectionTextId)
                    .IsRequired()
                    .HasColumnName("SectionTextID")
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
