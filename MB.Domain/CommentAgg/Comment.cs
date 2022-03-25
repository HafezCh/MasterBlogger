using System;
using MB.Domain.ArticleAgg;

namespace MB.Domain.CommentAgg
{
    public class Comment
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Message { get; private set; }
        public int Status { get; private set; } // New = 0 , Confirmed = 1 , Canceled = 2
        public DateTime CreationDate { get; private set; }
        public int ArticleId { get; private set; }
        public Article Article { get; private set; }

        public Comment(string name, string email, string message, int articleId)
        {
            Name = name;
            Email = email;
            Message = message;
            ArticleId = articleId;
            CreationDate = DateTime.Now;
            Status = Statuses.New;
        }

        protected Comment()
        {
        }
    }
}
