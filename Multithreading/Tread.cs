using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Multithreading
{
	public partial class Tread : Form
	{
		private Worker _worker;
		public Tread()
		{
			InitializeComponent();

			btn_Start.Click += btn_Start_Click;
			btn_Cancel.Click += btn_Cancel_Click;
		}

		private void btn_Cancel_Click(object sender, EventArgs e)
		{
			_worker = new Worker();
			_worker.ProcessChanged += worker_ProcessChanged;
			_worker.WorkCompleted += worker_WorkCompleted;
			
			btn_Start.Enabled = false;
			_worker.Work();

		}
		private void btn_Start_Click(object sender, EventArgs e)
		{
			throw new NotImplementedException();
		}



		private void worker_ProcessChanged(int progress)
		{
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
