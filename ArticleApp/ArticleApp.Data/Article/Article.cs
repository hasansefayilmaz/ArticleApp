using ArticleApp.Data.Base;
using System;

namespace ArticleApp.Data.Article
{
    public class Article : Entity
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public string Image { get; set; }
        public string Tags { get; set; }
        public int CreatedBy { get; set; }
        public int LastUpdateBy { get; set; }
        public DateTime? LastUpdateDate { get; set; }
    }
}
