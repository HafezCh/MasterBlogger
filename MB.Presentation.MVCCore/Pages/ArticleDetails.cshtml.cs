using MB.Application.Contracts.Comment;
using MB.Infrastructure.Query;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MB.Presentation.MVCCore.Pages
{
    public class ArticleDetailsModel : PageModel
    {
        public ArticleQueryView Article { get; set; }

        private readonly IArticleQuery _articleQuery;
        private readonly ICommentApplication commentApplication;

        public ArticleDetailsModel(IArticleQuery articleQuery, ICommentApplication commentApplication)
        {
            _articleQuery = articleQuery;
            this.commentApplication = commentApplication;
        }

        public void OnGet(int id)
        {
            Article = _articleQuery.GetArticle(id);
        }

        public RedirectToPageResult OnPost(AddComment command)
        {
            commentApplication.Add(command);
            return RedirectToPage("./ArticleDetails", new {id = command.ArticleId});
        }
    }
}