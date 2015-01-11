using System.ComponentModel;
namespace @as.Data
{
    /// <summary>
    /// All Attribute
    /// </summary>
    public class Attirubute
    {
        /// <summary>
        /// Resource Attirubute
        /// </summary>
        public class ResourceDisplayNameAttribute : DisplayNameAttribute
        {
            /// <summary>
            /// Model Display Attribute
            /// </summary>
            /// <param name="displayName"></param>
            public ResourceDisplayNameAttribute(string displayName) : base(getResource(displayName)) { }

            /// <summary>
            /// Internal Resource
            /// </summary>
            /// <param name="displayName"></param>
            /// <returns></returns>
            private static string getResource(string displayName)
            {
                string result = displayName;
                //result = Resource.Manager.Get(displayName);
                return result;
            }

            /// <summary>
            /// Base Display Override
            /// </summary>
            public override string DisplayName
            {
                get
                {
                    return base.DisplayName;
                }
            }

        }
    }
}
