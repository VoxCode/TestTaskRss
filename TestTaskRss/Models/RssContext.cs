namespace TestTaskRss.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class RssContext : DbContext
    {
        public RssContext()
            : base("name=RssContext1")
        {
        }

        public virtual DbSet<RssNews> RssNews { get; set; }
        public virtual DbSet<RssSources> RssSources { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RssSources>()
                .HasMany(e => e.RssNews)
                .WithRequired(e => e.RssSources)
                .HasForeignKey(e => e.RssSourceId);
        }
    }
}
