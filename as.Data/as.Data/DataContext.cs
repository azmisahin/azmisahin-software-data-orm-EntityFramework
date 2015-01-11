using System.Data.Entity;
using @as.Data.Models;

namespace @as.Data
{
    /// <summary>
    /// Data Context
    /// </summary>
    public partial class DataContext : DbContext, iDataContext
    {
        #region Singleton
        private static volatile DataContext instance = null;
        public static DataContext Initalize { get { return instance == null ? new DataContext() : instance; } }
        #endregion

        #region Ctor
        /// <summary>
        /// Data Context
        /// </summary>
        public DataContext() : base("DefaultConnection")//private context Migration [ Not  Add-Migration - is not constructible.]
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
            Configuration.ValidateOnSaveEnabled = false;
            Database.Log = System.Console.Write;
            Database.SetInitializer<DataContext>(new DataContextInitializer());
        }

        /// <summary>
        /// Data Context 
        /// Connection String Configure
        /// </summary>
        /// <param name="nameOrConnectionString"></param>
        private DataContext(string nameOrConnectionString) :base(nameOrConnectionString:nameOrConnectionString){}
        
        #endregion

        #region Property
        /// <summary>
        /// Logs
        /// </summary>
        public virtual DbSet<Log> Logs { get; set; }
        #endregion
    }
}
