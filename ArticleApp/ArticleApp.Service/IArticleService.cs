using ArticleApp.Service.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ArticleApp.Service
{
    public interface IArticleService
    {
        public Task<IEnumerable<ArticleDto>> GetAll();
        public Task<ArticleDto> GetById(int id);
        public Task<bool> Insert(ArticleDto articleDto);
        public Task<bool> Update(ArticleDto articleDto);
        public Task<bool> Delete(ArticleDto articleDto);
    }
}
