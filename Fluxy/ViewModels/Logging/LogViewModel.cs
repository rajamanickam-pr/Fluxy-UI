using System;
using System.ComponentModel.DataAnnotations;

namespace Fluxy.ViewModels.Logging
{
    public class LogViewModel
    {
        [Key]
        public string Id { get; set; }
        public int LogLevelId { get; set; }
        public string ApplicationObject { get; set; }
        public string FullMessage { get; set; }
        public string ControllerName { get; set; }
        public string ExceptionStackTrace { get; set; }
        public DateTime LogTime { get; set; }
        public string HelpLink { get; internal set; }
        public string InnerException { get; internal set; }
        public string Method { get; internal set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
    }
}