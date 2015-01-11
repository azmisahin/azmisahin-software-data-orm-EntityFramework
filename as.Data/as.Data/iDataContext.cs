using @as.Data.Models;
using System.Data.Entity;

namespace @as.Data
{
    /// <summary>
    /// Data Context Interface
    /// </summary>
    interface iDataContext
    {
        /// <summary>
        /// Logs Table
        /// </summary>
        DbSet<Log> Logs { get; set; }
    }
}
