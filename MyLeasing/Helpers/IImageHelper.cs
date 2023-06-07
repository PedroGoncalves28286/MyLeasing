using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace MyLeasing.Web.Helpers
{
    public interface IImageHelper
    {
        Task<string> UloadImageAsync(IFormFile imageFile, string folder);
        Task DeleteImageAsync(string imageUrl);
    }
}
