using Microsoft.Data.SqlClient;
using System.Data;

namespace Remote_Mcp_Ai.Services
{
	/// <summary>
	/// Provides methods for creating and managing database connections.
	/// </summary>
	internal class DBService
	{
		/// <summary>
		/// Establishes and opens a new SQL database connection using the specified connection string.
		/// </summary>
		/// <remarks>This method initializes a new instance of <see cref="SqlConnection"/> and attempts to open it. 
		/// Ensure that the connection is properly closed and disposed of after use to free up resources.</remarks>
		/// <param name="connectionString">The connection string used to establish the SQL database connection. Cannot be null or empty.</param>
		/// <returns>An open <see cref="SqlConnection"/> object.</returns>
		/// <exception cref="Exception"></exception>
		private static SqlConnection Connection(string connectionString)
		{
			try
			{
				var conn = new SqlConnection(connectionString);
				conn.Open();
				return conn;
			}
			catch (Exception ex)
			{

				throw new Exception(ex.Message);
			}
		}

		/// <summary>
		/// Executes a SQL command and retrieves the result as a <see cref="DataTable"/>.
		/// </summary>
		/// <remarks>This method opens a database connection, executes the provided SQL command, and returns the
		/// results. The caller is responsible for ensuring that the SQL command is valid and that the connection string is
		/// correct.</remarks>
		/// <param name="connectionString">The connection string used to establish a connection to the database.</param>
		/// <param name="command">The SQL command to execute against the database.</param>
		/// <returns>A <see cref="DataTable"/> containing the result set of the executed SQL command.</returns>
		/// <exception cref="Exception"></exception>
		internal static DataTable GetData(string connectionString, string command)
		{
			using var conn = Connection(connectionString);

			try
			{
				using var cmd = new SqlCommand()
				{
					Connection = conn,
					CommandType = CommandType.Text,
					CommandText = command
				};

				var data = new DataTable();
				new SqlDataAdapter(cmd).Fill(data);

				cmd.Connection.CloseAsync();

				return data;
			}
			catch (Exception ex)
			{

				throw new Exception(ex.Message);
			}
			finally
			{
				conn.Close();
			}
		}

		/// <summary>
		/// Executes a SQL command against the database specified by the connection string.
		/// </summary>
		/// <remarks>This method opens a new database connection for each call and closes it after the command is
		/// executed.</remarks>
		/// <param name="connectionString">The connection string used to establish a connection to the database. Cannot be null or empty.</param>
		/// <param name="command">The SQL command to execute. Cannot be null or empty.</param>
		/// <returns><see langword="true"/> if the command affected one or more rows; otherwise, <see langword="false"/>.</returns>
		internal static bool SetData(string connectionString, string command)
		{
			using var conn = Connection(connectionString);

			try
			{
				using var cmd = new SqlCommand()
				{
					Connection = Connection(connectionString),
					CommandType = CommandType.Text,
					CommandText = command
				};

				var result = cmd.ExecuteNonQuery();

				if (result > 0)
				{
					return true;
				}

			}
			catch (Exception)
			{
				throw;
			}
			finally
			{
				conn.Close();
			}
			return false;
		}
	}
}
