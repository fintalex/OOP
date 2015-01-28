using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Multithreading
{
	public partial class Tread : Form
	{
		private Worker _worker;
		private SynchronizationContext _context;
		public Tread()
		{
			InitializeComponent();

			btn_Start.Click += btn_Start_Click;
			btn_Cancel.Click += btn_Cancel_Click;

			Load += Tread_Load;
		}

		private void Tread_Load(object sender, EventArgs e)
		{
			_context = SynchronizationContext.Current;
		}

		private void btn_Cancel_Click(object sender, EventArgs e)
		{
			_worker.Cancel();
		}
		private void btn_Start_Click(object sender, EventArgs e)
		{
			_worker = new Worker(worker_ProcessChanged, worker_WorkCompleted);
			
			btn_Start.Enabled = false;

			Thread thread = new Thread(_worker.Work);
			//thread.Start();
			thread.Start(_context);
		}



		private void worker_ProcessChanged(int progress)
		{ 
			progressBar1.Value = progress+1;
			progressBar1.Value = progress;
		}

		private void worker_WorkCompleted(bool canceled)
		{
			string message = canceled ? "Процесс отменем" : "Процесс завершен!";
			MessageBox.Show(message);
			btn_Start.Enabled = true;
		}

		

	}
}
