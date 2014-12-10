// -----------------------------------------------------------------------
// <copyright file="$className$.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Linq;
using System.Reflection;
using System.Text;
using ThomsonReuters.Eikon.Toolkit.Interfaces;

namespace ThomsonReuters.Eikon.EikonMotionControl
{
    // AppServer: match the app name to namespace above, and the class name below in the UiToolkitApp attribute.
    [UiToolkitApp("ThomsonReuters.Eikon.EikonMotionControl.WebCallableFunctions")]
    public class WebCallableFunctions
    {
        // WebApp: use the following function signature: public string <NameOfFunction>(string query, string body, IAppServerServices services)
        public string ToUpper(string query, string body, IAppServerServices services)
        {
            services.Logger.LogInfo("ToUpper executing in version '{0}' for user '{1}'", GetMyVersion(), services.UserContext.UUID);
            var builder = new StringBuilder("Query: ");
            builder.Append(query.ToUpper());
            builder.Append("\nBody: ");
            builder.Append(body.ToUpper());

            return builder.ToString();
        }

        public string ToLower(string query, string body, IAppServerServices services)
        {
            services.Logger.LogInfo("ToLower executing in version '{0}' for user '{1}'", GetMyVersion(), services.UserContext.UUID);
            var builder = new StringBuilder("Query: ");
            builder.Append(query.ToLower());
            builder.Append("\nBody: ");
            builder.Append(body.ToLower());
            return builder.ToString();
        }

        public string GetVersion(string query, string body, IAppServerServices services)
        {
            var builder = new StringBuilder("Version: ");
            builder.Append(GetMyVersion());
            return builder.ToString();
        }

        public string GetEmail(string query, string body, IAppServerServices services)
        {
            var builder = new StringBuilder("Email: ");
            builder.Append(services.UserContext.EmailAddress);
            return builder.ToString();
        }

        private static Version GetMyVersion()
        {
            var myAssembly = Assembly.GetExecutingAssembly();
            return myAssembly.GetName().Version;
        }
    }
}

