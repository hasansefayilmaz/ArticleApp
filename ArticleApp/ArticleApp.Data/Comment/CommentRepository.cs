using ArticleApp.Data.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArticleApp.Data.Comment
{
   public class CommentRepository : Repository<Comment, CommentDbContext>, ICommentRepository
    {
        public CommentRepository(CommentDbContext commentDbContext) : base(commentDbContext)
        {
        }
    }
}
