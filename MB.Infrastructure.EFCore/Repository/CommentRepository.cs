using MB.Application.Contracts.Comment;
using MB.Domain.CommentAgg;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using _01_Framework.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace MB.Infrastructure.EFCore.Repository
{
    public class CommentRepository : BaseRepository<int , Comment>, ICommentRepository
    {
        private readonly MasterBloggerContext _context;

        public CommentRepository(MasterBloggerContext context) : base(context)
        {
            _context = context;
        }

        public List<CommentViewModel> GetList()
        {
            return _context.Comments.Include(x => x.Article).Select(x => new CommentViewModel
            {
                Id = x.Id,
                Article = x.Article.Title,
                CreationDate = x.CreationDate.ToString(CultureInfo.InvariantCulture),
                Email = x.Email,
                Message = x.Message,
                Name = x.Name,
                Status = x.Status
            }).AsNoTracking().ToList();
        }
    }
}
