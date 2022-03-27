using MB.Application.Contracts.Article;
using System.Collections.Generic;
using System.Linq;
using MB.Domain.ArticleAgg;
using MB.Domain.ArticleAgg.Services;

namespace MB.Application
{
    public class ArticleApplication : IArticleApplication
    {
        private readonly IArticleRepository _articleRepository;
        private readonly IArticleValidatorService _articleValidatorService;

        public ArticleApplication(IArticleRepository articleRepository, IArticleValidatorService articleValidatorService)
        {
            _articleRepository = articleRepository;
            _articleValidatorService = articleValidatorService;
        }

        public void Activate(int id)
        {
            var article = _articleRepository.Get(id);
            article.Activate();
            //_articleRepository.Save();
        }

        public void Create(CreateArticle command)
        {
            var article = new Article(command.Title, command.ShortDescription,
                command.Image, command.Content, command.ArticleCategoryId, _articleValidatorService);

            _articleRepository.Create(article);
        }

        public void Edit(EditArticle command)
        {
            var article = _articleRepository.Get(command.Id);
            article.Edit(command.Title, command.ShortDescription, command.Image
                , command.Content, command.ArticleCategoryId);
           //_articleRepository.Save();
        }

        public EditArticle Get(int id)
        {
            var article = _articleRepository.Get(id);

            return new EditArticle
            {
                Id = article.Id,
                Title = article.Title,
                ShortDescription = article.ShortDescription,
                Image = article.Image,
                Content = article.Content,
                ArticleCategoryId = article.ArticleCategoryId
            };
        }

        public List<ArticleViewModel> GetList()
        {
            return _articleRepository.GetList();
        }

        public void Remove(int id)
        {
            var article = _articleRepository.Get(id);
            article.Remove();
            //_articleRepository.Save();
        }
    }
}
