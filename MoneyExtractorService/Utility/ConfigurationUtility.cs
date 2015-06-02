using MoneyExtractorService.Utility;
using System;
using System.Configuration;

namespace MoneyExtractorService.Utility
{
    public sealed class ConfigurationUtility : IConfigurationUtility
    {

        public ConfigurationUtility() { }

        public string Path { get { return ConfigurationManager.AppSettings["Path"]; } }

        public string FileName { get { return ConfigurationManager.AppSettings["FileName"]; } }

        public string FullPath { get { return System.IO.Path.Combine(this.Path, this.FileName); } }

        public int LogType { get { return Convert.ToInt32(ConfigurationManager.AppSettings["LogType"]); } }
    }
}