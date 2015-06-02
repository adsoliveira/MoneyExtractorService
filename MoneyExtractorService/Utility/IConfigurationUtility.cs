using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoneyExtractorService.Utility
{

    public interface IConfigurationUtility
    {

        string FileName { get; }

        string FullPath { get; }

        string Path { get; }

        int LogType { get; }
    }
}