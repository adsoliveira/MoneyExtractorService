using System;
using Dlp.Framework;
using MoneyExtractorService.Utility;
using Dlp.Framework.Container;

namespace MoneyExtractorService.Logs
{

    public class LogManager {

        public LogManager() { }

        public void SaveLog(object logData, LogType logType, string method) {

            string serializedData = Serializer.JsonSerialize(logData);

            string logInfo = String.Format("Date:{0};LogType:{1};Method:{2};LogData{3}",
                DateTime.UtcNow, logType.ToString(), method, serializedData);

            // Solicita ao container a classe concreta que implementa a interface IConfigurationUtility.
            IConfigurationUtility configuration = IocFactory.Resolve<IConfigurationUtility>();

            ILog abstractLog = LogFactory.Create(configuration.LogType);

            if (abstractLog == null) { throw new Exception(); }

            abstractLog.SaveLog(logInfo);
        }
    }
}
