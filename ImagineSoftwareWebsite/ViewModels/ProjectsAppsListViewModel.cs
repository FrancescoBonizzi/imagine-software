using System.Collections.Generic;
using System.Linq;

namespace ImagineSoftwareWebsite.ViewModels
{
    public class ProjectsAppsListViewModel
    {
        public ProjectsAppsViewModel[] ProjectsApps { get; }
        public string LocalizedTitle { get; }
        public string LocalizedSubTitle { get; }
        public string LocalizedMetaDescription { get; }

        public ProjectsAppsListViewModel(
            IEnumerable<ProjectsAppsViewModel> projectsApps,
            string localizedTitle,
            string localizedSubTitle,
            string localizedMetaDescription)
        {
            ProjectsApps = projectsApps.ToArray();
            LocalizedTitle = localizedTitle;
            LocalizedSubTitle = localizedSubTitle;
            LocalizedMetaDescription = localizedMetaDescription;
        }
    }
}
