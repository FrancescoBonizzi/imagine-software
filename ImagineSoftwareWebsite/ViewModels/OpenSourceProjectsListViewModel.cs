﻿using System.Collections.Generic;
using System.Linq;

namespace ImagineSoftwareWebsite.ViewModels
{
    public class OpenSourceProjectsListViewModel
    {
        public OpenSourceProjectViewModel[] OpenSourceProjects { get; }
        public string LocalizedTitle { get; }
        public string LocalizedSubTitle { get; }

        public OpenSourceProjectsListViewModel(
            IEnumerable<OpenSourceProjectViewModel> openSourceProjects,
            string localizedTitle,
            string localizedSubTitle)
        {
            OpenSourceProjects = openSourceProjects.ToArray();
            LocalizedTitle = localizedTitle;
            LocalizedSubTitle = localizedSubTitle;
        }
    }
}
