using log4net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using System.Diagnostics;

namespace Log4NetLibrary
{
	public sealed class DBLogService : IDBLogService
	{
		readonly ILog _logger;

		static DBLogService()
		{
			// эта конфигурация проходит один раз для домена и больше не заходит сюда
			var log4NetConfigDirectory = AppDomain.CurrentDomain.RelativeSearchPath ?? AppDomain.CurrentDomain.BaseDirectory;

			var log4NetConfigFilePath = Path.Combine(log4NetConfigDirectory, "log4net.config");
			log4net.Config.XmlConfigurator.ConfigureAndWatch(new FileInfo(log4NetConfigFilePath));

		}

		public DBLogService()
		{
			_logger = LogManager.GetLogger("Billing.DBLogger");
		}

		public void SetCallerProperties()
		{
			StackTrace stackTrace = new StackTrace();
			string callerMethodName = stackTrace.GetFrame(2).GetMethod().Name;
			string callerClassName = stackTrace.GetFrame(2).GetMethod().ReflectedType.ToString();
			log4net.LogicalThreadContext.Properties["CallerName"] = callerClassName + "." + callerMethodName;
		}

		public void Fatal(string errorMessage)
		{
			if (_logger.IsFatalEnabled)
				_logger.Fatal(errorMessage);
		}

		public void Error(string errorMessage)
		{
			SetCallerProperties();
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
			SetCallerProperties();
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
