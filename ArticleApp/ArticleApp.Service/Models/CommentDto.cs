using System;

namespace ArticleApp.Service.Models
{
    public class CommentDto
    {
        public string Text { get; set; }
        public byte Status { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }

    }
}