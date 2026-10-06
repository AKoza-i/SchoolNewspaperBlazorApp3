using SchoolNewspaperBlazorApp.Data;

namespace SchoolNewspaperBlazorApp.Interfaces.Service
{
    public interface IArticleService
    {
        Task AddArticleAsync(string title, string text, string author);
        Task<List<Article>> GetAllArticlesAsync();
    }
}
