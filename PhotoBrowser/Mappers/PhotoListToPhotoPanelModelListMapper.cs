using PhotoBrowser.BusinessLogic.Models;
using PhotoBrowser.Models;
using System.Collections.Generic;
using System.Linq;

namespace PhotoBrowser.Mappers
{
    public static class PhotoListToPhotoPanelModelListMapper
    {
        public static IList<PhotoPanelModel> ToPhotoPanelModelList(this List<Photo> source)
        {
            return (from photoSource in source
                    select new PhotoPanelModel
                    {
                        PhotoUrl = photoSource.ThumbnailUrl,
                        Title = photoSource.Title
                    }).ToList();
        }
    }
}
