using SchoolNewspaperBlazorApp.Data;

namespace SchoolNewspaperBlazorApp.Interfaces.Service
{
    public interface IArticleService
    {
        Task AddArticleAsync(Article article);
        Task<List<Article>> GetAllArticlesAsync();
    }
}
