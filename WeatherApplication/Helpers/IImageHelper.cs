using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace WeatherApplication.Helpers
{
    public interface IImageHelper
    {
        Task<string> UploadImageAsync(IFormFile imageFile, string folder);
    }
}
