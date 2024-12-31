using Blog.Core.Application.Features.Application.Blogs.BlogCategories;
using Blog.Core.Application.Features.Application.Blogs.BlogCategories.Interfaces;
using Blog.Core.Application.Features.Application.Blogs.BlogFavorites;
using Blog.Core.Application.Features.Application.Blogs.BlogFavorites.Interfaces;
using Blog.Core.Application.Features.Application.Blogs.Blogs;
using Blog.Core.Application.Features.Application.Blogs.Blogs.Interfaces;
using Blog.Core.Application.Features.Application.Categories;
using Blog.Core.Application.Features.Application.Categories.Interfaces;
using Blog.Core.Application.Features.Application.Comments.CommentLikes;
using Blog.Core.Application.Features.Application.Comments.CommentLikes.Interfaces;
using Blog.Core.Application.Features.Application.Comments.Comments;
using Blog.Core.Application.Features.Application.Comments.Comments.Interfaces;
using Blog.Core.Application.Features.Application.Pots.PostLikes;
using Blog.Core.Application.Features.Application.Pots.PostLikes.Interfaces;
using Blog.Core.Application.Features.Application.Pots.PostLists;
using Blog.Core.Application.Features.Application.Pots.PostLists.Interfaces;
using Blog.Core.Application.Features.Application.Pots.PostTags;
using Blog.Core.Application.Features.Application.Pots.PostTags.Interfaces;
using Blog.Core.Application.Features.Application.Pots.Pots;
using Blog.Core.Application.Features.Application.Pots.Pots.Interfaces;
using Blog.Core.Application.Features.Application.Tags;
using Blog.Core.Application.Features.Application.Tags.Interfaces;
using Blog.Core.Application.Features.Application.UserData.UserFollow;
using Blog.Core.Application.Features.Application.UserData.UserFollow.Interfaces;
using Blog.Core.Application.Features.Application.UserData.UserList.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;


namespace Blog.Core.Application.Extensions
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddApplicationLayer(this IServiceCollection services, IConfiguration config)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());


            #region Services Registration
            services.AddTransient<IBlogService, BlogService>();
            services.AddTransient<IBlogCategoryService, BlogCategoryService>();
            services.AddTransient<IBlogFavoriteService, BlogFavoriteService>();

            services.AddTransient<IPostService, PostService>();
            services.AddTransient<IPostLikesService, PostLikeService>();
            services.AddTransient<IPostListService, PostListService>();
            services.AddTransient<IPostTagService, PostTagService>();

            services.AddTransient<ICategoryService, CategoryService>();

            services.AddTransient<ITagService, TagService>();

            services.AddTransient<ICommentService, CommentService>();
            services.AddTransient<ICommentLikeService, CommentLikeService>();

            services.AddTransient<IUserFollowService, UserFollowService>();
            //  services.AddTransient<IUserListRepository, UserListRepository>();

            #endregion

            #region Validation Registration
            #endregion
            return services;
        } 
    }
}
