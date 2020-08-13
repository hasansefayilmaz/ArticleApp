using System;
using System.Collections.Generic;
using System.Text;

namespace ArticleApp.Service.Models
{
    public class ArticleDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Image { get; set; }
        public string Tags { get; set; }
        public byte Status { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int LastUpdateBy { get; set; }
        public DateTime? LastUpdateDate { get; set; }
        public string CreatedByName { get; set; }
        public List<CommentDto> Comments { get; set; }

    }
}
