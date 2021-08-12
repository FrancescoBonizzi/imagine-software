using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace ImagineSoftwareWebsiteLibrary.Logs
{
    public interface IMyLogger
    {
        Task LogInformation(string message, [CallerMemberName] string callerMethod = null);
        Task LogError(string message, [CallerMemberName] string callerMethod = null);
        Task LogError(Exception ex, [CallerMemberName] string callerMethod = null);
    }
}
