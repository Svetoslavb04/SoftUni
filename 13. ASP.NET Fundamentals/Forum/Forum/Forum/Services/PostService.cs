using Forum.Data;
using Forum.Data.Models;
using Forum.Models;
using Microsoft.EntityFrameworkCore;

namespace Forum.Services
{
    public class PostService
    {
        private ForumDbContext context;

        public PostService(ForumDbContext _context)
        {
            context = _context;
        }

        public async Task<IEnumerable<PostDto>> AllAsync()
        {
            context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

            var posts = await context.Posts
                .Select(p => new PostDto
                {
                    Id = p.Id,
                    Title = p.Title,
                    Content = p.Content
                })
                .ToListAsync();

            return posts.AsEnumerable();
        }

        public async Task Add(PostDto post)
        {

            await context.Posts.AddAsync(new Post()
            {
                Title = post.Title,
                Content = post.Content
            });

            await context.SaveChangesAsync();

        }

        public async Task<PostDto> GetById(int id)
        {
            if (context.Posts.Any(p => p.Id == id))
            {
                return await context.Posts
                    .Where(p => p.Id == id)
                    .Select(p => new PostDto()
                    {
                        Id = p.Id,
                        Title = p.Title,
                        Content = p.Content
                    })
                    .FirstOrDefaultAsync();

            }

            return null;
        }

        public async Task<PostDto> Edit(PostDto post)
        {

            if (!context.Posts.Any(p => p.Id == post.Id))
            {
                throw new ArgumentException("Invalid post");
            }

            var dbPost = context.Posts
                .Where(p => p.Id == post.Id)
                .FirstOrDefault();

            dbPost.Title = post.Title;
            dbPost.Content = post.Content;

            await context.SaveChangesAsync();

            return post;
        }

        public async Task<bool> Delete(PostDto post)
        {
            if (!context.Posts.Any(p => p.Id == post.Id))
            {
                throw new ArgumentException("Invalid post");
            }

            context.Posts
                .Remove(context.Posts.Where(p => p.Id == post.Id).FirstOrDefault());

            await context.SaveChangesAsync();

            return true;
        }
    }
}
