using Dapper;
using ImagineSoftwareWebsiteLibrary.Logging;
using Microsoft.Data.SqlClient;
using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace ImagineSoftwareWebsiteLibrary.Logs
{
    public class SQLServerLogger : IMyLogger
    {
        private readonly string _connectionString;

        public SQLServerLogger(string connectionString)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new ArgumentNullException(nameof(connectionString));
            }

            _connectionString = connectionString;
        }

        private async Task Log(string message, LogTypes logType, [CallerMemberName] string callerMethod = null)
        {
            try
            {
                using var connection = new SqlConnection(_connectionString);
                await connection.OpenAsync();
                await connection.ExecuteAsync(
                    "INSERT INTO Logs.Logs (LogDateUTC, Message, LogType, CallerMethod) " +
                    "VALUES " +
                    "(@logDateUc, @message, @logTypeId, @callerMethod); ",
                    new
                    {
                        logDateUTC = DateTime.UtcNow,
                        message,
                        logTypeId = (byte)logType,
                        callerMethod = callerMethod ?? string.Empty
                    });
            }
            // Un logger non deve rompere, MAI
            catch (Exception ex)
            {
                // TODO Event viewer?
                Debug.WriteLine(ex.ToString());
            }
        }

        public Task LogError(string message, [CallerMemberName] string callerMethod = null)
            => Log(message, LogTypes.Error, callerMethod);

        public async Task LogError(Exception ex, [CallerMemberName] string callerMethod = null)
            => await LogError(ex.ToString(), callerMethod);

        public Task LogInformation(string message, [CallerMemberName] string callerMethod = null)
            => Log(message, LogTypes.Information, callerMethod);
    }
}
