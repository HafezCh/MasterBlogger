using MB.Application.Contracts.Article;
using MB.Domain.ArticleAgg;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace MB.Infrastructure.EFCore.Repository
{
    public class ArticleRepository : IArticleRepository
    {
        private readonly MasterBloggerContext _context;

        public ArticleRepository(MasterBloggerContext context)
        {
            _context = context;
        }

        public void Create(Article entity)
        {
            _context.Articles.Add(entity);
            Save();
        }

        public bool Exists(string title)
        {
            return _context.Articles.Any(a => a.Title == title);
        }

        public Article Get(int id)
        {
            return _context.Articles.FirstOrDefault(x => x.Id == id);
        }

        public List<ArticleViewModel> GetList()
        {
            return _context.Articles.Include(x => x.ArticleCategory).Select(x => new ArticleViewModel
            {
                Id = x.Id,
                Title = x.Title,
                ArticleCategory = x.ArticleCategory.Title,
                IsDeleted = x.IsDeleted,
                CreationDate = x.CreationDate.ToString(CultureInfo.InvariantCulture)
            }).ToList();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
