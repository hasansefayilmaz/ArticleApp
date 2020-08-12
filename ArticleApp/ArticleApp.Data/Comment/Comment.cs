using ArticleApp.Data.Base;
using System;

namespace ArticleApp.Data.Comment
{
    public class Comment : Entity
    {
        public string Text { get; set; }
        public int ArticleId { get; set; }
        public int CreatedBy { get; set; }
    }
}
