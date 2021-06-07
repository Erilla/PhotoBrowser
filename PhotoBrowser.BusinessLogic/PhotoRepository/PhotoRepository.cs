using PhotoBrowser.BusinessLogic.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace PhotoBrowser.BusinessLogic.PhotoRepository
{
    public class PhotoRepository : IPhotoRepository
    {
        public async Task<List<Photo>> GetPhotosAsync()
        {

            using (var client = new HttpClient())
            {
                var response = await client.GetAsync("https://jsonplaceholder.typicode.com/photos");

                var photos = JsonSerializer.Deserialize<List<Photo>>(response.Content.ReadAsStringAsync().Result, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                return photos;
            }
        }
    }
}
