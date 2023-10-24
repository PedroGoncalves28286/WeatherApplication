using WeatherApplication.Prism.Models;
using System.Threading.Tasks;

namespace WeatherApplication.Prism.Services
{
    public interface IApiService
    {
        Task<Response> GetListAsync<T>(string urlBase, string api, string controller);

        Task<Response> GetUser(string urlBase, string api, string controller);

        Task<Response> CheckUser(string urlBase, string api, string controller);
    }
}
