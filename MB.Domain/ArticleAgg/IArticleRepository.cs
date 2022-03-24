using MB.Application.Contracts.Article;
using System.Collections.Generic;

namespace MB.Domain.ArticleAgg
{
    public interface IArticleRepository
    {
        List<ArticleViewModel> GetList();
        void Create(Article entity);
        Article Get(int id);
        void Save();
        bool Exists(string title);
    }
}
