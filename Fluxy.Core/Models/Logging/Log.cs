using Fluxy.Core.Common;
using System;

namespace Fluxy.Core.Models.Logging
{
    public class Log:AuditableEntity<string>
    {
        public int LogLevelId { get; set; }
        public string ApplicationObject { get; set; }
        public string FullMessage { get; set; }
        public string ControllerName { get; set; }
        public string ExceptionStackTrace { get; set; }
        public DateTime LogTime { get; set; }
        public string HelpLink { get; internal set; }
        public string InnerException { get; internal set; }
        public string Method { get; internal set; }
    }
}
