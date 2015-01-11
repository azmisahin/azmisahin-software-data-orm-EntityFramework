using System.Data.Entity;

namespace @as.Data
{
    /// <summary>
    /// Data Context Initalizer
    /// </summary>
    public class DataContextInitializer : DropCreateDatabaseAlways<DataContext>
    {
        /// <summary>
        /// Migration Initalize
        /// </summary>
        /// <param name="context"></param>
        protected override void Seed(DataContext context)
        {
            base.Seed(context);
        }
    }
    /// <summary>
    /// Code First Initalizer
    /// </summary>
    public partial class DataContext :DbContext
    {
        /// <summary>
        /// On Model Creating
        /// Map Foregin Key And Cascade Delete On/Off
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Log>()
            //    .HasRequired(n => n.foregInId)
            //    .WithMany(m => m.otherColumnMach)
            //    .HasForeignKey(f => f.otherColumnId)
            //    .WillCascadeOnDelete(false);
            base.OnModelCreating(modelBuilder);
        }
    }
}
