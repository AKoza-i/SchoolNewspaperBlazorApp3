using Microsoft.IdentityModel.Tokens;
using SchoolNewspaperBlazorApp.Data;
using SchoolNewspaperBlazorApp.Interfaces.Repository;
using SchoolNewspaperBlazorApp.Interfaces.Service;

namespace SchoolNewspaperBlazorApp.Service
{
    public class ArticleService : IArticleService
    {
        private readonly IArticleRepository _articleRepository;
        public ArticleService(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }
        public async Task AddArticleAsync(string title, string text, string author)
        {
            var article = new Article
            {
                Title = title,
                Text = text,
                Author = author,
                PublishDate = DateTime.Now
            };
            await _articleRepository.AddArticleAsync(article);
        }
        public async Task<List<Article>> GetAllArticlesAsync()
        {
            List<Article> articleList = await _articleRepository.GetAllArticlesAsync();

            // Zamiast rzucać wyjątek, bezpiecznie zwracamy listę.
            // Jeśli articleList jest null, zwracamy nową pustą listę.
            return articleList ?? new List<Article>();
        }
        public async Task<Article> GetArticleByIdAsync(int id)
        {
            var article = await _articleRepository.GetArticleByIdAsync(id);
            if (article == null)
            {
                throw new Exception($"Article with ID {id} not found.");
            }
            return article;
        }
    }
}
