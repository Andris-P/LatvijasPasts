namespace LatvijasPasts.Web.Models
{
    public class CvListViewModel
    {
        public CvListViewModel()
        {
            CvItems = new List<CvItemViewModel>();
        }

        public List<CvItemViewModel> CvItems { get; set; }
    }
}

 