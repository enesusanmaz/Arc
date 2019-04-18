using MYARCH.CORE;
using System;
using System.Data.Entity;

namespace MYARCH.DATA.Context
{
    public partial class MyArchContext : DbContext
    {
        private readonly MyArchContext _context;
        public MyArchContext()
            : base("name=MyArchEntities")
        {
            Configuration.LazyLoadingEnabled = false;
        }

        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Post> Post { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("User", "dbo");
            modelBuilder.Entity<Post>().ToTable("Post", "dbo");
            modelBuilder.Entity<Category>().ToTable("Category", "dbo");

            base.OnModelCreating(modelBuilder);
        }
    }
}
