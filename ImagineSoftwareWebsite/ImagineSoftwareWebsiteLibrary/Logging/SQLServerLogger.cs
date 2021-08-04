using Dapper;
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

        public async Task Log(string message, [CallerMemberName] string callerMethod = null)
        {
            try
            {
                using var connection = new SqlConnection(_connectionString);
                await connection.OpenAsync();
                await connection.ExecuteAsync(
                    "INSERT INTO Logs.Logs " +
                    "VALUES " +
                    "(@logDate, @message, @callerMethod); ",
                    new { logDate = DateTimeOffset.Now, message, callerMethod = callerMethod ?? string.Empty });
            }
            // Un logger non deve rompere, MAI
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }

        public async Task Log(Exception ex, [CallerMemberName] string callerMethod = null)
            => await Log(ex.ToString(), callerMethod);
    }
}
