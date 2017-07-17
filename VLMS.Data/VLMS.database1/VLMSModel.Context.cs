
namespace VLMS.Database
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class VLMSDataEntities : DbContext
    {
        public VLMSDataEntities()
            : base("name=VLMSDataEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Error> Errors { get; set; }
        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<ItemCategory> ItemCategories { get; set; }
        public virtual DbSet<ItemProfilePhoto> ItemProfilePhotoes { get; set; }
        public virtual DbSet<Library> Libraries { get; set; }
        public virtual DbSet<Status> Status { get; set; }
    }
}
