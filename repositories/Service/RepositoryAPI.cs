using System;
using System.Threading.Tasks;
namespace repositories.Service
{
    public interface RepositoryAPI 
    {
		[Get("/api/v1/products.json?brand=maybelline")]
        Task<string> GetMakeUps();
    }
}
