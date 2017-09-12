using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fluxy.Infrastructure
{
    /// <summary>
    /// Ensures that a HTTP request URL can contain query string parameters with both upper-case and lower-case
    /// characters.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, Inherited = true, AllowMultiple = false)]
    public class NoLowercaseQueryStringAttribute : FilterAttribute
    {
    }
}