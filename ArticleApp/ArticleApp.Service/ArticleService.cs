using ArticleApp.Data.Article;
using ArticleApp.Data.Comment;
using ArticleApp.Data.User;
using ArticleApp.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticleApp.Service
{
    public class ArticleService : IArticleService
    {
        private readonly IArticleRepository _articleRepository;
        private readonly IUserRepository _userRepository;
        private readonly ICommentRepository _commentRepository;
        public ArticleService(IArticleRepository articleRepository, IUserRepository userRepository, ICommentRepository commentRepository)
        {

            _articleRepository = articleRepository;
            _userRepository = userRepository;
            _commentRepository = commentRepository;
        }
        public async Task<IEnumerable<ArticleDto>> GetAll()
        {
            var articles = await _articleRepository.FilterAsync(c => c.Status == 1);
            var userIds = articles.Select(c => c.CreatedBy).Distinct();
            var users = await _userRepository.FilterAsync(c => userIds.Contains(c.Id));
            var comments = await _commentRepository.FilterAsync(c => c.Status == 1);

            List<ArticleDto> articleDtos = new List<ArticleDto>();

            foreach (var article in articles)
            {
                var refUser = users.FirstOrDefault(c => c.Id == article.CreatedBy);
                var refComments = comments.Where(c => c.ArticleId == article.Id).ToList();
                var articleDto = new ArticleDto
                {
                    Id = article.Id,
                    Content = article.Content,
                    Status = article.Status,
                    CreatedBy = article.CreatedBy,
                    CreatedByName = refUser.Name + ' ' + refUser.Surname,
                    CreatedDate = article.CreatedDate,
                    Image = article.Image,
                    LastUpdateBy = article.LastUpdateBy,
                    LastUpdateDate = article.LastUpdateDate,
                    Tags = article.Tags,
                    Title = article.Title,
                    Comments = new List<CommentDto>()
                };
                foreach (var refComment in refComments)
                {
                    articleDto.Comments.Add(new CommentDto
                    {
                        CreatedBy = refComment.CreatedBy,
                        CreatedDate = refComment.CreatedDate,
                        Status = refComment.Status,
                        Text = refComment.Text
                    });
                }
                articleDtos.Add(articleDto);
            }
            return articleDtos;

        }
        public async Task<ArticleDto> GetById(int id)
        {
            var article = await _articleRepository.GetByIdAsync(id);
            var user = await _userRepository.GetByIdAsync(article.CreatedBy);
            var comments = await _commentRepository.FilterAsync(c => c.ArticleId == id);
            var articleDto = new ArticleDto
            {
                Id = article.Id,
                Content = article.Content,
                Status = article.Status,
                CreatedBy = article.CreatedBy,
                CreatedByName = user.Name + ' ' + user.Surname,
                CreatedDate = article.CreatedDate,
                Image = article.Image,
                LastUpdateBy = article.LastUpdateBy,
                LastUpdateDate = article.LastUpdateDate,
                Tags = article.Tags,
                Title = article.Title,
                Comments = new List<CommentDto>()
            };
            foreach (var comment in comments)
            {
                articleDto.Comments.Add(new CommentDto
                {
                    CreatedBy = comment.CreatedBy,
                    CreatedDate = comment.CreatedDate,
                    Status = comment.Status,
                    Text = comment.Text
                });
            }
            return articleDto;
        }
        public async Task<bool> Insert(ArticleDto articleDto)
        {
            return await _articleRepository.CreateAsync(new Article
            {
                Content = articleDto.Content,
                CreatedBy = articleDto.CreatedBy,
                CreatedDate = articleDto.CreatedDate,
                Id = articleDto.Id,
                Image = articleDto.Image,
                LastUpdateBy = articleDto.LastUpdateBy,
                LastUpdateDate = articleDto.LastUpdateDate,
                Status = articleDto.Status,
                Tags = articleDto.Tags,
                Title = articleDto.Title
            });

        }
        public async Task<bool> Update(ArticleDto articleDto)
        {
            return await _articleRepository.UpdateAsync(new Article
            {
                Content = articleDto.Content,
                CreatedBy = articleDto.CreatedBy,
                CreatedDate = articleDto.CreatedDate,
                Id = articleDto.Id,
                Image = articleDto.Image,
                LastUpdateBy = articleDto.LastUpdateBy,
                LastUpdateDate = articleDto.LastUpdateDate,
                Status = articleDto.Status,
                Tags = articleDto.Tags,
                Title = articleDto.Title
            });
        }
        public async Task<bool> Delete(ArticleDto articleDto)
        {
            return await _articleRepository.SoftDeleteAsync(new Article { Id = articleDto.Id });
        }
    }
}
