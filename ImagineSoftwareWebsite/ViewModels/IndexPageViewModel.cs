using System.Collections.Generic;

namespace ImagineSoftwareWebsite.ViewModels
{
    public class IndexPageViewModel
    {
        public IEnumerable<TechnologyViewModel> Technologies { get; }
        public IEnumerable<CustomersViewModel> Customerss { get; }

        public IndexPageViewModel(
            IEnumerable<TechnologyViewModel> technologies,
            IEnumerable<CustomersViewModel> customerss)
        {
            Technologies = technologies;
            Customerss = customerss;
        }
    }
}
