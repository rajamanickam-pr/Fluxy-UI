using Fluxy.Core.Models.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fluxy.Data.Mappings.Logging
{
    public class LogMap:FluxyEntityTypeConfiguration<Log>
    {
        public LogMap()
        {
            this.ToTable("Log");
            this.HasKey(sm => sm.Id);
            this.Property(sm => sm.FullMessage).IsRequired();
            this.Property(sm => sm.ApplicationObject);
            this.Property(sm => sm.ExceptionStackTrace);
            this.Property(sm => sm.InnerException);
            this.Property(sm => sm.HelpLink);
        }
    }
}
