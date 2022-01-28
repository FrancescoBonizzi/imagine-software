using System.Collections.Generic;
using System.Linq;

namespace ImagineSoftwareWebsite.ViewModels
{
    public class OpenSourceProjectsListViewModel
    {
        public OpenSourceProjectViewModel[] OpenSourceProjects { get; }

        public OpenSourceProjectsListViewModel(
            IEnumerable<OpenSourceProjectViewModel> openSourceProjects)
        {
            OpenSourceProjects = openSourceProjects.ToArray();
        }
    }
}
