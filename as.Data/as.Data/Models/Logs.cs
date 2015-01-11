using System;
using System.ComponentModel.DataAnnotations;//Ef
using System.ComponentModel.DataAnnotations.Schema;//Ef
using System.Runtime.Serialization;//System.Runtime.Serialization.dll
namespace @as.Data.Models
{
    /// <summary>
    /// Log Table
    /// </summary>
    [DataContract(IsReference = true)]
    [Table("Logs")]
    [Serializable()]
    public class Log
    {
        /// <summary>
        /// Primary Key [Auto]
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DataMember]
        [Attirubute.ResourceDisplayName("Data.Models.Log.id")]
        public int id { get; set; }

        /// <summary>
        /// Log Date
        /// </summary>
        [DataMember]
        [Attirubute.ResourceDisplayName("Data.Models.Log.dateTime")]
        public DateTime dateTime { get; set; }
        /// <summary>
        /// Log Info
        /// </summary>
        [DataMember]
        [Attirubute.ResourceDisplayName("Data.Models.Log.info")]
        public string info { get; set; }

    }
}
