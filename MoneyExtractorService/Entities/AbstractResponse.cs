using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoneyExtractorService.Entities
{
    public abstract class AbstractResponse
    {
        public AbstractResponse()
        {
            this.ErrorReportList = new List<ErrorReport>();
        }

        internal List<ErrorReport> ErrorReportList { get; set; }

        public bool Success { get; set; }
    }
}