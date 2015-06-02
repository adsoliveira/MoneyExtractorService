using Dlp.Framework.Container;

namespace MoneyExtractorService.Logs
{
    public static class LogFactory {

        public static ILog Create(int logId) {

            switch (logId) {
                default:
                    return null;
                case 1:
                    return IocFactory.ResolveByName<ILog>("MoneyExtractor.Core.Logs.FileLog");
                case 2:
                    return IocFactory.ResolveByName<ILog>("MoneyExtractor.Core.Logs.EventViewerLog");
            }
        }

    }
}
