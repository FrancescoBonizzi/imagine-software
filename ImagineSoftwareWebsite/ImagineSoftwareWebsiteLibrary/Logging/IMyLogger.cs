using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace ImagineSoftwareWebsiteLibrary.Logs
{
    public interface IMyLogger
    {
        Task Log(string message, [CallerMemberName] string callerMethod = null);
        Task Log(Exception ex, [CallerMemberName] string callerMethod = null);
    }
}
