using ArticleApp.Data.Base;
using System;

namespace ArticleApp.Data.Article
{
    public class Article : Entity
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Image { get; set; }
        public string Tags { get; set; }
        public string CreatedBy { get; set; }
        public string LastUpdateBy { get; set; }
        public string LastUpdateDate { get; set; }
    }
}
