using System;
using MB.Domain.ArticleAgg.Services;
using MB.Domain.ArticleCategoryAgg;

namespace MB.Domain.ArticleAgg
{
    public class Article
    {
        public int Id { get; private set; }
        public string Title { get; private set; }
        public string ShortDescription { get; private set; }
        public string Image { get; private set; }
        public string Content { get; private set; }
        public bool IsDeleted { get; private set; }
        public DateTime CreationDate { get; private set; }
        public int ArticleCategoryId { get; private set; }
        public ArticleCategory ArticleCategory { get; private set; }

        protected Article()
        {
        }

        public Article(string title, string shortDescription, string image
            , string content, int articleCategoryId , IArticleValidatorService validatorService)
        {
            Validate(title, articleCategoryId);

            validatorService.CheckThatThisRecordAlreadyExists(title);

            Title = title;
            ShortDescription = shortDescription;
            Image = image;
            Content = content;
            ArticleCategoryId = articleCategoryId;
            CreationDate = DateTime.Now;
            IsDeleted = false;
        }

        private static void Validate(string title, int articleCategoryId)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentNullException();

            if (articleCategoryId == 0)
                throw new ArgumentOutOfRangeException();
        }

        public void Edit(string title, string shortDescription, string image
            , string content, int articleCategoryId, IArticleValidatorService validatorService)
        {
            Validate(title,articleCategoryId);

            validatorService.CheckThatThisRecordAlreadyExists(title);

            Title = title;
            ShortDescription = shortDescription;
            Image = image;
            Content = content;
            ArticleCategoryId = articleCategoryId;
        }

        public void Remove()
        {
            IsDeleted = true;
        }

        public void Activate()
        {
            IsDeleted = false;
        }
    }
}
