using MB.Domain.ArticleCategoryAgg;
using System.Collections.Generic;
using System.Linq;
using _01_Framework.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace MB.Infrastructure.EFCore.Repository
{
    public class ArticleCategoryRepository : BaseRepository<int, ArticleCategory>, IArticleCategoryRepository
    {
        private readonly MasterBloggerContext _context;

        public ArticleCategoryRepository(MasterBloggerContext context) : base(context)
        {
            _context = context;
        }
    }
}
