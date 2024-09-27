
using Blog.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Blog.Infraestructure.Presistance.Context
{
	public class ApplicationContext : DbContext
	{
		#region Context Sets 
		public DbSet<UserBlog> UserBlogs { get; set; }
		public DbSet<BlogCategory> BlogCategories { get; set; }
		public DbSet<BlogFavorite> BlogFavorites { get; set; }
		public DbSet<Post> Post { get; set; }
		public DbSet<PostLike> PostLikes { get; set; }
		public DbSet<PostList> PostList { get; set; }
		public DbSet<PostTag> PostTags { get; set; }
		public DbSet<UserList> UserLists { get; set; }
		public DbSet<Comment> Comments { get; set; }
		public DbSet<CommentLike> CommentLikes { get; set; }
		public DbSet<Tag> Tags { get; set; }
		public DbSet<Category> Categories { get; set; }
		public DbSet<UserFollow> UserFollows { get; set; }

		#endregion
		public ApplicationContext() {}
        public ApplicationContext(DbContextOptions<ApplicationContext> contextOptions) : base(contextOptions)
        {
            
        }
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			base.OnConfiguring(optionsBuilder);

		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			
			base.OnModelCreating(modelBuilder);
			modelBuilder.Entity<UserBlog>(b =>{
				b.HasKey(b => b.Id);
			});
		}
	}
}
