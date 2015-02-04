using System;
using System.IO;
using log4net;

namespace Log4NetLibrary
{
    public sealed class FileLogService : ILogService
    {
        readonly ILog _logger;

		static FileLogService()
		{
			// эта конфигурация проходит один раз для домена и больше не заходит сюда
			var log4NetConfigDirectory = AppDomain.CurrentDomain.RelativeSearchPath ?? AppDomain.CurrentDomain.BaseDirectory;

			var log4NetConfigFilePath = Path.Combine(log4NetConfigDirectory, "log4net.config");
			log4net.Config.XmlConfigurator.ConfigureAndWatch(new FileInfo(log4NetConfigFilePath));
			//log4net.Config.XmlConfigurator.Configure();

		}

		public FileLogService(Type type)
		{
			_logger = LogManager.GetLogger(type);
		}

		public FileLogService()
		{
			_logger = LogManager.GetLogger("Billing.FileLogger");
		}


        public void Fatal(string errorMessage)
        {
            if (_logger.IsFatalEnabled)
                _logger.Fatal(errorMessage);
        }

        public void Error(string errorMessage)
        {
            if (_logger.IsErrorEnabled)
                _logger.Error(errorMessage);
        }

        public void Warn(string message)
        {
            if (_logger.IsWarnEnabled)
                _logger.Warn(message);
        }

        public void Info(string message)
        {
            if (_logger.IsInfoEnabled)
                _logger.Info(message);
        }

        public void Debug(string message)
        {
            if (_logger.IsDebugEnabled)
                _logger.Debug(message);
        }
    }
}
