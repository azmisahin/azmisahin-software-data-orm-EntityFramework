using System.Linq;

namespace @as.Data.Migrations
{
    /// <summary>
    /// Migration Initializer
    /// </summary>
    public class Initializer
    {
        /// <summary>
        /// Log Initalializer
        /// </summary>
        /// <param name="context"></param>
        public void LogInitializer(DataContext context)
        {
            if (context.Logs.Count() == 0)
            {
                context.Database.Connection.Open();
                context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT[dbo].[Log] ON");
                context.Database.ExecuteSqlCommand("INSERT [dbo].[Log] ([id],[dateTime],[info]) VALUES (0, '1.1.2015','-')");
                context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT[dbo].[Log] OFF");
                context.Database.Connection.Close();
            }
        }
    }
}
