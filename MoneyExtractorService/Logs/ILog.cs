using MoneyExtractorService.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyExtractorService.Logs
{

    public interface ILog {

        void SaveLog(string logInfo);
    }
}
