namespace TasksAndTPL
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.AsyncWithNewTask = new System.Windows.Forms.Button();
            this.AsyncWithTaskRun = new System.Windows.Forms.Button();
            this.AsyncWithTaskFactory = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.SyncProcess = new System.Windows.Forms.Button();
            this.AsyncCallBack = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // AsyncWithNewTask
            // 
            this.AsyncWithNewTask.Location = new System.Drawing.Point(12, 12);
            this.AsyncWithNewTask.Name = "AsyncWithNewTask";
            this.AsyncWithNewTask.Size = new System.Drawing.Size(192, 47);
            this.AsyncWithNewTask.TabIndex = 0;
            this.AsyncWithNewTask.Text = "AsyncWithNewTask";
            this.AsyncWithNewTask.UseVisualStyleBackColor = true;
            this.AsyncWithNewTask.Click += new System.EventHandler(this.AsyncWithNewTask_Click);
            // 
            // AsyncWithTaskRun
            // 
            this.AsyncWithTaskRun.Location = new System.Drawing.Point(301, 12);
            this.AsyncWithTaskRun.Name = "AsyncWithTaskRun";
            this.AsyncWithTaskRun.Size = new System.Drawing.Size(179, 47);
            this.AsyncWithTaskRun.TabIndex = 1;
            this.AsyncWithTaskRun.Text = "AsyncWithTaskRun";
            this.AsyncWithTaskRun.UseVisualStyleBackColor = true;
            this.AsyncWithTaskRun.Click += new System.EventHandler(this.AsyncWithTaskRun_Click);
            // 
            // AsyncWithTaskFactory
            // 
            this.AsyncWithTaskFactory.Location = new System.Drawing.Point(559, 12);
            this.AsyncWithTaskFactory.Name = "AsyncWithTaskFactory";
            this.AsyncWithTaskFactory.Size = new System.Drawing.Size(192, 46);
            this.AsyncWithTaskFactory.TabIndex = 2;
            this.AsyncWithTaskFactory.Text = "AsyncWithTaskFactory";
            this.AsyncWithTaskFactory.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 258);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(886, 378);
            this.textBox1.TabIndex = 3;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 217);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(886, 23);
            this.progressBar1.TabIndex = 4;
            // 
            // SyncProcess
            // 
            this.SyncProcess.Location = new System.Drawing.Point(12, 109);
            this.SyncProcess.Name = "SyncProcess";
            this.SyncProcess.Size = new System.Drawing.Size(192, 47);
            this.SyncProcess.TabIndex = 5;
            this.SyncProcess.Text = "SyncProcess";
            this.SyncProcess.UseVisualStyleBackColor = true;
            this.SyncProcess.Click += new System.EventHandler(this.SyncProcess_Click);
            // 
            // AsyncCallBack
            // 
            this.AsyncCallBack.Location = new System.Drawing.Point(301, 109);
            this.AsyncCallBack.Name = "AsyncCallBack";
            this.AsyncCallBack.Size = new System.Drawing.Size(192, 47);
            this.AsyncCallBack.TabIndex = 6;
            this.AsyncCallBack.Text = "AsyncCallBack";
            this.AsyncCallBack.UseVisualStyleBackColor = true;
            this.AsyncCallBack.Click += new System.EventHandler(this.AsyncCallBack_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(910, 643);
            this.Controls.Add(this.AsyncCallBack);
            this.Controls.Add(this.SyncProcess);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.AsyncWithTaskFactory);
            this.Controls.Add(this.AsyncWithTaskRun);
            this.Controls.Add(this.AsyncWithNewTask);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button AsyncWithNewTask;
        private System.Windows.Forms.Button AsyncWithTaskRun;
        private System.Windows.Forms.Button AsyncWithTaskFactory;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button SyncProcess;
        private System.Windows.Forms.Button AsyncCallBack;
    }
}

