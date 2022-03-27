using MB.Application.Contracts.Article;
using System.Collections.Generic;
using System.Linq;
using _01_Framework.Infrastructure;
using MB.Domain.ArticleAgg;
using MB.Domain.ArticleAgg.Services;

namespace MB.Application
{
    public class ArticleApplication : IArticleApplication
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IArticleRepository _articleRepository;
        private readonly IArticleValidatorService _articleValidatorService;

        public ArticleApplication(IArticleRepository articleRepository, IArticleValidatorService articleValidatorService, IUnitOfWork unitOfWork)
        {
            _articleRepository = articleRepository;
            _articleValidatorService = articleValidatorService;
            _unitOfWork = unitOfWork;
        }

        public void Activate(int id)
        {
            _unitOfWork.BeginTran();

            var article = _articleRepository.Get(id);
            article.Activate();
            
            _unitOfWork.CommitTran();
        }

        public void Create(CreateArticle command)
        {
            _unitOfWork.BeginTran();

            var article = new Article(command.Title, command.ShortDescription,
                command.Image, command.Content, command.ArticleCategoryId, _articleValidatorService);

            _articleRepository.Create(article);

            _unitOfWork.CommitTran();
        }

        public void Edit(EditArticle command)
        {
            _unitOfWork.BeginTran();

            var article = _articleRepository.Get(command.Id);
            article.Edit(command.Title, command.ShortDescription, command.Image
                , command.Content, command.ArticleCategoryId);

            _unitOfWork.CommitTran();
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
            _unitOfWork.BeginTran();

            var article = _articleRepository.Get(id);
            article.Remove();

            _unitOfWork.CommitTran();
        }
    }
}
