using ImagineSoftwareWebsite.ViewModels;
using Squidex.ClientLibrary;

namespace ImagineSoftwareWebsite.Services
{
    public class SquidexApiClient
    {
        public IContentsClient<CommonPageSquidex, CommonPageViewModel> CommonPagesClient { get; }
        public IContentsClient<ServicesSquidex, ServicesViewModel> ServicesClient { get; }
        public IContentsClient<TechnologySquidex, TechnologyViewModel> TechnologiesClient { get; }
        public IContentsClient<CustomersSquidex, CustomersViewModel> CustomersClient { get; }
        public IContentsClient<OpenSourceProjectSquidex, OpenSourceProjectViewModel> OpenSourceProjectsClient { get; }
        public IContentsClient<HomePageSquidex, HomePageViewModel> HomePageClient { get; }
        public IContentsClient<ProjectsAppsSquidex, ProjectsAppsViewModel> ProjectsApplicationsPageClient { get; }

        public SquidexApiClient(SquidexClientManager squidexClientManager)
        {
            CommonPagesClient = squidexClientManager.CreateContentsClient<CommonPageSquidex, CommonPageViewModel>("common-pages");
            ServicesClient = squidexClientManager.CreateContentsClient<ServicesSquidex, ServicesViewModel>("services");
            TechnologiesClient = squidexClientManager.CreateContentsClient<TechnologySquidex, TechnologyViewModel>("technologies");
            CustomersClient = squidexClientManager.CreateContentsClient<CustomersSquidex, CustomersViewModel>("customers");
            OpenSourceProjectsClient = squidexClientManager.CreateContentsClient<OpenSourceProjectSquidex, OpenSourceProjectViewModel>("open-source-projects");
            HomePageClient = squidexClientManager.CreateContentsClient<HomePageSquidex, HomePageViewModel>("homepage");
            ProjectsApplicationsPageClient = squidexClientManager.CreateContentsClient<ProjectsAppsSquidex, ProjectsAppsViewModel>("projects-applications");
        }

    }
}
