namespace Repository
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class LibDb : DbContext
    {
        public LibDb()
            : base("name=LibDb")
        {
        }

        public virtual DbSet<AUTHOR> AUTHORs { get; set; }
        public virtual DbSet<BOOK> BOOKs { get; set; }
        public virtual DbSet<CLASSIFICATION> CLASSIFICATIONs { get; set; }
        public virtual DbSet<USER> USERs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AUTHOR>()
                .HasMany(e => e.BOOKs)
                .WithMany(e => e.AUTHORs)
                .Map(m => m.ToTable("BOOK_AUTHOR").MapLeftKey("Aid").MapRightKey("ISBN"));

            modelBuilder.Entity<USER>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<USER>()
                .Property(e => e.HashPassWord)
                .IsUnicode(false);
        }
    }
}
