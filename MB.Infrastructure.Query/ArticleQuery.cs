using MB.Infrastructure.EFCore;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using MB.Domain.CommentAgg;
using Microsoft.EntityFrameworkCore;

namespace MB.Infrastructure.Query
{
    public class ArticleQuery : IArticleQuery
    {
        private readonly MasterBloggerContext _context;

        public ArticleQuery(MasterBloggerContext context)
        {
            _context = context;
        }

        public ArticleQueryView GetArticle(int id)
        {
            return _context.Articles
                .Include(x => x.ArticleCategory)
                .Include(x => x.Comments)
                .Select(x => new ArticleQueryView
                {
                    Id = x.Id,
                    Title = x.Title,
                    ArticleCategory = x.ArticleCategory.Title,
                    ShortDescription = x.ShortDescription,
                    CreationDate = x.CreationDate.ToString(CultureInfo.InvariantCulture),
                    Image = x.Image,
                    Content = x.Content,
                    CommentsCount = x.Comments.Count(a => a.Status == Statuses.Confirmed),
                    Comments = MapComments(x.Comments.Where(a => a.Status == Statuses.Confirmed))
                }).AsNoTracking().FirstOrDefault(x => x.Id == id);
        }

        public List<ArticleQueryView> GetArticles()
        {
            return _context.Articles.Include(x => x.ArticleCategory).Select(x => new ArticleQueryView
            {
                Id = x.Id,
                Title = x.Title,
                ArticleCategory = x.ArticleCategory.Title,
                ShortDescription = x.ShortDescription,
                CreationDate = x.CreationDate.ToString(CultureInfo.InvariantCulture),
                Image = x.Image,
                IsDeleted = x.IsDeleted,
                CommentsCount = x.Comments.Count(a => a.Status == Statuses.Confirmed)
            }).AsNoTracking().ToList();
        }

        private static List<CommentQueryView> MapComments(IEnumerable<Comment> comments)
        {
            return comments.Select(comment => new CommentQueryView {Name = comment.Name
                , CreationDate = comment.CreationDate
                    .ToString(CultureInfo.InvariantCulture)
                , Message = comment.Message}).ToList();

            /*var result = new List<CommentQueryView>();

            foreach (var comment in comments)
            {
                result.Add(new CommentQueryView
                {
                    Name = comment.Name,
                    CreationDate = comment.CreationDate.ToString(CultureInfo.InvariantCulture),
                    Message = comment.Message
                });
            }

            return result;*/
        }
    }
}
