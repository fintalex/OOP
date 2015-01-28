using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Multithreading
{
	public class Worker
	{
		private bool _cancelled = false;
		public void Cancel()
		{
			_cancelled = true;
		}
		public Worker(Action<int> processChanged, Action<bool> workCompleted)
		{
			ProcessChanged = processChanged;
			WorkCompleted = workCompleted;
		}

		public void Work(object param)
		{
			SynchronizationContext context = (SynchronizationContext)param;
			for (int i = 0; i < 100; i++)
			{
				if (_cancelled)
					break; // прерываем наш цикл
				Thread.Sleep(50); // эмулируем некоторую работу
				//ProcessChanged(i); // вызываем событие - уведомляя подписчиков что мы сдвинулись вперед
				context.Send(OnProgressChanged, i);
			}
			// уведомляем всех подписчиков, что процесс закончился
			// _canceled будет говорить, остановили ли мы его, или он просто закончился
			// WorkCompleted(_cancelled);
			context.Send(OnWorkCompleted, _cancelled);
		}

		public event Action<int> ProcessChanged;
		public event Action<bool> WorkCompleted;

		public void OnProgressChanged(object i)
		{
			if (ProcessChanged != null)
				ProcessChanged((int)i);
		}
		public void OnWorkCompleted(object cancelled)
		{
			if (WorkCompleted != null)
				WorkCompleted((bool)cancelled);
		}
	}
}
