using System;
using System.Data.SqlClient;
using System.IO;
using System.Reflection;

namespace @as.Data.Migrations
{
    /// <summary>
    /// .Sql File Batch Builder
    /// </summary>
    public class BatchBuilder
    {
        /// <summary>
        /// Initalize By File Base
        /// </summary>
        /// <param name="context"></param>
        public void InitalizeByFile(DataContext context)
        {
            var assemblyLocation = Assembly.GetExecutingAssembly().Location;
            var assemblyDirectory = Path.GetDirectoryName(assemblyLocation);
            var pathCombine = Path.Combine(assemblyDirectory, @"Initalize.sql");
            var fileContent = File.ReadAllText(pathCombine);
            var emptyparams = new SqlParameter[] { new SqlParameter() };
            //ExecuteNonQuery(context, fileContent);
            //context.Database.ExecuteSqlCommand(fileContent, emptyparams);
        }


        /// <summary>
        /// Auto Migration From .Sql File
        /// </summary>
        /// <param name="context"></param>
        /// <param name="Query"></param>
        public void ExecuteNonQuery(DataContext context, string Query)
        {
            string ConnectionString = context.Database.Connection.ConnectionString;
            string[] commands = RemoveSqlEntries(Query);
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                string FullQuery = "";
                foreach (string item in commands)
                {
                    FullQuery += item;
                }
                using (SqlCommand cmd = new SqlCommand(FullQuery, con))
                {
                    int AffectedRow = cmd.ExecuteNonQuery();
                }
                con.Close();
            }
        }

        /// <summary>
        /// Batch GO
        /// </summary>
        /// <param name="Query"></param>
        /// <returns></returns>
        public string[] RemoveSqlEntries(string Query)
        {
            string[] commands = Query.Split(
                new string[] { "GO\r\n", "GO ", "GO\t" }, StringSplitOptions.RemoveEmptyEntries);
            return commands;
        }
    }
}
