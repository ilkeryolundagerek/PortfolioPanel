using PortfolioPanel.Entities;
using System.Data.Entity;

namespace PortfolioPanel.Data
{
    public class PortfolioContext : DbContext
    {
        private readonly static string connection_string = @"Server=.; Database=PortfolioDB; Trusted_Connection=True; MultipleActiveResultSets=True;";
        public PortfolioContext() : base(connection_string)
        {
        }

        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
        public virtual DbSet<TeamMember> TeamMembers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>()
                .HasMany(p => p.Categories)
                .WithMany(c => c.Posts)
                .Map(pc =>
                {
                    pc.MapLeftKey("PostRefId");
                    pc.MapRightKey("CategoryRefId");
                    pc.ToTable("PostCategories");
                });

            modelBuilder.Entity<Post>()
                .HasMany(p => p.Tags)
                .WithMany(t => t.Posts)
                .Map(pt =>
                {
                    pt.MapLeftKey("PostRefId");
                    pt.MapRightKey("TagRefId");
                    pt.ToTable("PostTags");
                });

            modelBuilder.Entity<Project>()
                .HasMany(p => p.Categories)
                .WithMany(c => c.Projects)
                .Map(pc =>
                {
                    pc.MapLeftKey("ProjectRefId");
                    pc.MapRightKey("CategoryRefId");
                    pc.ToTable("ProjectCategories");
                });

            modelBuilder.Entity<Project>()
                .HasMany(p => p.Tags)
                .WithMany(t => t.Projects)
                .Map(pt =>
                {
                    pt.MapLeftKey("ProjectRefId");
                    pt.MapRightKey("TagRefId");
                    pt.ToTable("ProjectTags");
                });

            modelBuilder.Entity<Project>()
                .HasMany(p => p.Team)
                .WithMany(t => t.Projects)
                .Map(pt =>
                {
                    pt.MapLeftKey("ProjectRefId");
                    pt.MapRightKey("TeamMemberRefId");
                    pt.ToTable("ProjectTeamMembers");
                });
        }
    }
}