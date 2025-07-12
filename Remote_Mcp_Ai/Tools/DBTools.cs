using ModelContextProtocol.Server;
using Remote_Mcp_Ai.Services;
using System.ComponentModel;
using System.Data;

namespace Remote_Mcp_Ai.Tools
{
    /// <summary>
    /// Provides methods for interacting with a database.
    /// </summary>
    [McpServerToolType]
    internal class DBTools
    {
        /// <summary>
        /// Retrieves data from the database using the specified connection string and command.
        /// </summary>
        /// <remarks>This method uses the provided connection string and command to query the database and
        /// retrieve data.  Ensure that the connection string and command are valid and properly formatted to avoid
        /// runtime errors.</remarks>
        /// <param name="connectionString">The connection string used to establish a connection to the database. Cannot be null or empty.</param>
        /// <param name="command">The SQL command to execute against the database. Cannot be null or empty.</param>
        /// <returns>An object containing the data retrieved from the database. The return value will be null if no data is
        /// found.</returns>
        [McpServerTool, Description("Get Data from datenbank")]
        internal Object GetData(string connectionString, string command) => DBService.GetData(connectionString, command);

        [McpServerTool, Description("Set new Data in the database")]
        internal bool SetData(string connectionString, string command) => DBService.SetData(connectionString, command);

    }
}
