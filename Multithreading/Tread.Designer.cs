namespace Multithreading
{
	partial class Tread
	{
		/// <summary>
		/// Требуется переменная конструктора.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Освободить все используемые ресурсы.
		/// </summary>
		/// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Код, автоматически созданный конструктором форм Windows

		/// <summary>
		/// Обязательный метод для поддержки конструктора - не изменяйте
		/// содержимое данного метода при помощи редактора кода.
		/// </summary>
		private void InitializeComponent()
		{
			this.btn_Start = new System.Windows.Forms.Button();
			this.btn_Cancel = new System.Windows.Forms.Button();
			this.progressBar1 = new System.Windows.Forms.ProgressBar();
			this.SuspendLayout();
			// 
			// btn_Start
			// 
			this.btn_Start.Location = new System.Drawing.Point(562, 115);
			this.btn_Start.Name = "btn_Start";
			this.btn_Start.Size = new System.Drawing.Size(75, 23);
			this.btn_Start.TabIndex = 0;
			this.btn_Start.Text = "Старт";
			this.btn_Start.UseVisualStyleBackColor = true;
			// 
			// btn_Cancel
			// 
			this.btn_Cancel.Location = new System.Drawing.Point(696, 115);
			this.btn_Cancel.Name = "btn_Cancel";
			this.btn_Cancel.Size = new System.Drawing.Size(75, 23);
			this.btn_Cancel.TabIndex = 1;
			this.btn_Cancel.Text = "Отменить";
			this.btn_Cancel.UseVisualStyleBackColor = true;
			// 
			// progressBar1
			// 
			this.progressBar1.Location = new System.Drawing.Point(53, 35);
			this.progressBar1.Name = "progressBar1";
			this.progressBar1.Size = new System.Drawing.Size(756, 23);
			this.progressBar1.TabIndex = 2;
			// 
			// Tread
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(884, 631);
			this.Controls.Add(this.progressBar1);
			this.Controls.Add(this.btn_Cancel);
			this.Controls.Add(this.btn_Start);
			this.Name = "Tread";
			this.Text = "Потоки";
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button btn_Start;
		private System.Windows.Forms.Button btn_Cancel;
		private System.Windows.Forms.ProgressBar progressBar1;
	}
}

