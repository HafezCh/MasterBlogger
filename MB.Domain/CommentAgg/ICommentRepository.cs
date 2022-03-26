using System.Collections.Generic;
using MB.Application.Contracts.Comment;

namespace MB.Domain.CommentAgg
{
    public interface ICommentRepository
    {
        void Create(Comment entity);
        List<CommentViewModel> GetList();
        Comment Get(int id);
        void Save();
    }
}
