using System.Collections.Generic;

namespace MB.Application.Contracts.ArticleCategory
{
    public interface IArticleCategoryApplication
    {
        List<ArticleCategoryViewModel> List();
        void Add(CreateArticleCategory command);
        void Rename(RenameArticleCategory command);
        RenameArticleCategory Get(int id);
        void Remove(int id);
        void Activate(int id);
    }
}
