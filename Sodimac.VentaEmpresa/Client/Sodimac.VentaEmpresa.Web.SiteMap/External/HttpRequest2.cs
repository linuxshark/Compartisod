#region Using directives

using System;
using System.Reflection;
using System.Web;

#endregion

namespace MvcSiteMapProvider.External
{
    /// <summary>
    /// HttpRequest2 wrapper.
    /// </summary>
    public class HttpRequest2 : HttpRequestWrapper
    {
        private HttpRequest httpRequest;

        /// <summary>
        /// Initializes a new instance of the <see cref="HttpRequest2"/> class.
        /// </summary>
        /// <param name="httpRequest">The object that this wrapper class provides access to.</param>
        /// <exception cref="T:System.ArgumentNullException">
        /// 	<paramref name="httpRequest"/> is null.
        /// </exception>
        public HttpRequest2(HttpRequest httpRequest)
            : base(httpRequest)
        {
            this.httpRequest = httpRequest;
        }

        /// <summary>
        /// Gets the virtual path of the application root and makes it relative by using the tilde (~) notation for the application root (as in "~/page.aspx").
        /// </summary>
        /// <value></value>
        /// <returns>
        /// The virtual path of the application root for the current request with the tilde operator added.
        /// </returns>
        public override string AppRelativeCurrentExecutionFilePath
        {
            get
            {
                return System.Web.VirtualPathUtility.ToAppRelative(this.CurrentExecutionFilePath);
            }
        }

        /// <summary>
        /// Gets the virtual path of the current request.
        /// </summary>
        /// <value></value>
        /// <returns>
        /// The virtual path of the page handler that is currently executing.
        /// </returns>
        public override string CurrentExecutionFilePath
        {
            get { return base.FilePath; }
        }
    }
}