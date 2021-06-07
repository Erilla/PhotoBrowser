using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PagedList.Core;
using PhotoBrowser.BusinessLogic.PhotoRepository;
using PhotoBrowser.Models;
using System.Diagnostics;
using System.Threading.Tasks;
using PhotoBrowser.Mappers;
using System.Linq;

namespace PhotoBrowser.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IPhotoRepository _photoRepository;

        public HomeController(ILogger<HomeController> logger, IPhotoRepository photoRepository)
        {
            _logger = logger;
            _photoRepository = photoRepository;
        }

        public async Task<IActionResult> IndexAsync(int? page, int pageSize = 5)
        {
            var pageIndex = page ?? 1;

            var photosList = await _photoRepository.GetPhotosAsync();
            var photoPanelModels = photosList.ToPhotoPanelModelList();
            var photoPanelModelsList = photoPanelModels.AsQueryable().ToPagedList(pageIndex, pageSize);

            var model = new IndexModel
            {
                CurrentPage = pageIndex,
                PageSize = pageSize,
                PhotosPanelModelList = photoPanelModelsList
            };

            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
