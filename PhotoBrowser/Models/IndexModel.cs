using PagedList.Core;

namespace PhotoBrowser.Models
{
    public class IndexModel
    {
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public IPagedList<PhotoPanelModel> PhotosPanelModelList { get; set; }
    }
}
