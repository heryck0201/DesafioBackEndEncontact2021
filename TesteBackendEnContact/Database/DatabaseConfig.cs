using Dapper;
using Microsoft.Data.SqlClient;
using System.Linq;

namespace TesteBackendEnContact.Database
{
    public class DatabaseConfig
    {
        public DatabaseConfig(string connectionString, string name)
        {
            ConnectionString = connectionString.Replace("Initial Catalog = *;", "Initial Catalog = " + name);
            using var connection = new SqlConnection(connectionString.Replace("Initial Catalog = *;", ""));
            var parameters = new DynamicParameters();
            parameters.Add("name", name);
            if (!connection.Query("SELECT * FROM sys.databases WHERE name = @name", parameters).Any())
            {
                connection.Execute($"CREATE DATABASE {name}");
            }
        }
        public DatabaseConfig() { }
        public string ConnectionString { get; set; }
    }
}