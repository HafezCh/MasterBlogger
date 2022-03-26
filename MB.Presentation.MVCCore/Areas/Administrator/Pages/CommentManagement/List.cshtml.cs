using System.Collections.Generic;
using MB.Application.Contracts.Comment;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MB.Presentation.MVCCore.Areas.Administrator.Pages.CommentManagement
{
    public class ListModel : PageModel
    {
        public List<CommentViewModel> Comments { get; set; }

        private readonly ICommentApplication _commentApplication;

        public ListModel(ICommentApplication commentApplication)
        {
            _commentApplication = commentApplication;
        }

        public void OnGet()
        {
            Comments = _commentApplication.List();
        }

        public RedirectToPageResult OnPostCancel(int id)
        {
            _commentApplication.Cancel(id);
            return RedirectToPage("./List");
        }
        public RedirectToPageResult OnPostConfirm(int id)
        {
            _commentApplication.Confirm(id);
            return RedirectToPage("./List");
        }
    }
}
