using PhotoBrowser.BusinessLogic.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PhotoBrowser.BusinessLogic.PhotoRepository
{
    public interface IPhotoRepository
    {
        public Task<List<Photo>> GetPhotosAsync();
    }
}
