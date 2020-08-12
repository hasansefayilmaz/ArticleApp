using ArticleApp.Data.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArticleApp.Data.Article
{
   public class ArticleRepository : Repository<Article, ArticleDbContext>, IArticleRepository
    {
        public ArticleRepository(ArticleDbContext userDbContext) : base(userDbContext)
        {
        }
    }
}
