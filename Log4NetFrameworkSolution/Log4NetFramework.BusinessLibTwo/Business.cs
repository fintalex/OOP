using Log4NetLibrary;

namespace Log4NetFramework.BusinessLibTwo
{
    public class Business
    {
        public Business()
        {
            ILogService logService = new FileLogService(typeof(Business));
            logService.Info("Just an information from a business library two");
        }
    }
}
