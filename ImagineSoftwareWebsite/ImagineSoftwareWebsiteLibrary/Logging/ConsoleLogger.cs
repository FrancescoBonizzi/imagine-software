using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace ImagineSoftwareWebsiteLibrary.Logs
{
    public class ConsoleLogger : IMyLogger
    {
        public Task Log(string message, [CallerMemberName] string callerMethod = null)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Error! {message}");
            Console.ForegroundColor = ConsoleColor.White;
            return Task.FromResult(true);
        }

        public Task Log(Exception ex, [CallerMemberName] string callerMethod = null)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Error! {ex.Message}");
            Console.ForegroundColor = ConsoleColor.White;
            return Task.FromResult(true);
        }
    }
}
