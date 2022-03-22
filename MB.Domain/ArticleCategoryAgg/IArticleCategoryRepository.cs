using System.Collections.Generic;

namespace MB.Domain.ArticleCategoryAgg
{
    public interface IArticleCategoryRepository
    {
        List<ArticleCategory> GetAll();
        void Create(ArticleCategory entity);
        ArticleCategory Get(int id);
        void Save();
        bool Exists(string title);
    }
}
