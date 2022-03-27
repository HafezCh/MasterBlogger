using MB.Application.Contracts.ArticleCategory;
using MB.Domain.ArticleCategoryAgg;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using MB.Domain.ArticleCategoryAgg.Services;
using _01_Framework.Infrastructure;

namespace MB.Application
{
    public class ArticleCategoryApplication : IArticleCategoryApplication
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IArticleCategoryRepository _articleCategoryRepository;
        private readonly IArticleCategoryValidatorService _articleCategoryValidatorService;

        public ArticleCategoryApplication(IArticleCategoryRepository articleCategoryRepository, IArticleCategoryValidatorService articleCategoryValidatorService, IUnitOfWork unitOfWork)
        {
            _articleCategoryRepository = articleCategoryRepository;
            _articleCategoryValidatorService = articleCategoryValidatorService;
            _unitOfWork = unitOfWork;
        }

        public void Activate(int id)
        {
            _unitOfWork.BeginTran();

            var articleCategory = _articleCategoryRepository.Get(id);
            articleCategory.Activate();
            
            _unitOfWork.CommitTran();
        }

        public void Create(CreateArticleCategory command)
        {
            _unitOfWork.BeginTran();

            var articleCategory = new ArticleCategory(command.Title, _articleCategoryValidatorService);

            _articleCategoryRepository.Create(articleCategory);
            
            _unitOfWork.CommitTran();
        }

        public RenameArticleCategory Get(int id)
        {
            var articleCategory = _articleCategoryRepository.Get(id);
            return new RenameArticleCategory
            {
                Id = articleCategory.Id,
                Title = articleCategory.Title
            };
        }

        public List<ArticleCategoryViewModel> List()
        {
            var articleCategories = _articleCategoryRepository.GetAll();

            return articleCategories.Select(articleCategory => new ArticleCategoryViewModel
            {
                Id = articleCategory.Id,
                Title = articleCategory.Title
                    ,
                IsDeleted = articleCategory.IsDeleted,
                CreationDate =
                        articleCategory.CreationDate.ToString(CultureInfo.InvariantCulture)
            }).OrderByDescending(x => x.Id).ToList();

            /*foreach (var articleCategory in articleCategories)
            {
                result.Create(new ArticleCategoryViewModel
                {
                    Id = articleCategory.Id,
                    Title = articleCategory.Title,
                    IsDeleted = articleCategory.IsDeleted,
                    CreationDate = articleCategory.CreationDate.ToString(CultureInfo.InvariantCulture)
                });
            }*/
        }

        public void Remove(int id)
        {
            _unitOfWork.BeginTran();

            var articleCategory = _articleCategoryRepository.Get(id);
            articleCategory.Remove();
            
            _unitOfWork.CommitTran();
        }

        public void Rename(RenameArticleCategory command)
        {
            _unitOfWork.BeginTran();

            var articleCategory = _articleCategoryRepository.Get(command.Id);
            articleCategory.Rename(command.Title, _articleCategoryValidatorService);
            
            _unitOfWork.CommitTran();
        }
    }
}
