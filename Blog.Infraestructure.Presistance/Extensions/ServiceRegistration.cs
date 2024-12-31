

using Blog.Core.Application.Features.Application.Blogs.BlogCategories.Interfaces;
using Blog.Core.Application.Features.Application.Blogs.BlogFavorites.Interfaces;
using Blog.Core.Application.Features.Application.Blogs.Blogs.Interfaces;
using Blog.Core.Application.Features.Application.Categories.Interfaces;
using Blog.Core.Application.Features.Application.Comments.CommentLikes.Interfaces;
using Blog.Core.Application.Features.Application.Comments.Comments.Interfaces;
using Blog.Core.Application.Features.Application.Pots.PostLikes.Interfaces;
using Blog.Core.Application.Features.Application.Pots.PostLists.Interfaces;
using Blog.Core.Application.Features.Application.Pots.PostTags.Interfaces;
using Blog.Core.Application.Features.Application.Pots.Pots.Interfaces;
using Blog.Core.Application.Features.Application.Tags.Interfaces;
using Blog.Core.Application.Features.Application.UserData.UserFollow.Interfaces;
using Blog.Core.Application.Features.Application.UserData.UserList.Interfaces;
using Blog.Infraestructure.Presistance.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Blog.Infraestructure.Presistance.Extensions
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddInfraestructurePersistanceLayer(this IServiceCollection services, IConfiguration confi)
        {

            services.AddTransient<IBlogRepository, BlogRepository>();
            services.AddTransient<IBlogCategoryRepository, BlogCategoryRepository>();
            services.AddTransient<IBlogFavoriteRepository, BlogFavoriteRepository>();

            services.AddTransient<IPostRepository, PostRepository>();
            services.AddTransient<IPostLikeRepository, PostLikeRepository>();
            services.AddTransient<IPostListRepository, PostListRepository>();
            services.AddTransient<IPostTagRepository, PostTagRepository>();

            services.AddTransient<ICategoryRepository, CategoryRepository>();

            services.AddTransient<ITagRepository, TagRepository>();

            services.AddTransient<ICommentRepository, CommentRepository>();
            services.AddTransient<ICommentLikeRepositiory, CommentLikeRepository>();

            services.AddTransient<IUserFollowRepository, UserFollowRepository>();
            services.AddTransient<IUserListRepository, UserListRepository>();

            return services;
        }
    }
}
