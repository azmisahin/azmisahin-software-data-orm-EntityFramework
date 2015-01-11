namespace @as.Data.Migrations
{
    using System.Data.Entity.Migrations;

    /// <summary>
    /// Enable-Migrations
    /// </summary>
    internal sealed class Configuration : DbMigrationsConfiguration<DataContext>
    {
        /// <summary>
        /// Configuration
        /// </summary>
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        /// <summary>
        /// First Initializer
        /// </summary>
        /// <param name="context"></param>
        protected override void Seed(DataContext context)
        {
            new Initializer().LogInitializer(context:context);
            //new BatchBuilder().InitalizeByFile(context: context);
        }
    }
}
