using Log4NetFramework.BusinessLibOne;
using Log4NetLibrary;

namespace Log4NetFramework.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            ILogService logService = new FileLogService(typeof(Program));
            logService.Info("Just an information from console app");
            //Call business library as well
            new Business();
            System.Console.WriteLine("Log is written successfully. Press any key to exit");
            System.Console.Read();

			ILogService logService2 = new FileLogService();
			logService2.Error(" aaaaaaaaaaaaaa ");
			ILogService logService3 = new DBLogService();
			logService3.Error(" DBLogService ");
        }
    }
}
