using System.Collections.Generic;

namespace ImagineSoftwareWebsite.ViewModels
{
    public class IndexPageViewModel
    {
        public IEnumerable<TechnologyViewModel> Technologies { get; }

        public IndexPageViewModel(IEnumerable<TechnologyViewModel> technologies)
        {
            Technologies = technologies;
        }
    }
}
