namespace System_scheduling
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.Button_OpenFile = new System.Windows.Forms.Button();
            this.Button_Start = new System.Windows.Forms.Button();
            this.Button_Pause = new System.Windows.Forms.Button();
            this.Label_Time_Break1 = new System.Windows.Forms.Label();
            this.Box_Time_Break = new System.Windows.Forms.TextBox();
            this.Label_Time_Break_s = new System.Windows.Forms.Label();
            this.Label_Processing = new System.Windows.Forms.Label();
            this.Box_Processing = new System.Windows.Forms.TextBox();
            this.Label_Ready = new System.Windows.Forms.Label();
            this.ListBox_ReadyQueue = new System.Windows.Forms.ListBox();
            this.Label_Ready_After = new System.Windows.Forms.Label();
            this.ListBox_ReadyAfterQueue = new System.Windows.Forms.ListBox();
            this.ListBox_ReadyIn = new System.Windows.Forms.ListBox();
            this.Label_ReadyIn = new System.Windows.Forms.Label();
            this.Lable_ReadyOut = new System.Windows.Forms.Label();
            this.ListBox_ReadyOut = new System.Windows.Forms.ListBox();
            this.Label_OtherWait = new System.Windows.Forms.Label();
            this.ListBox_OtherWait = new System.Windows.Forms.ListBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.Box_needtime = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Box_timecount = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Button_OpenFile
            // 
            this.Button_OpenFile.BackColor = System.Drawing.SystemColors.Control;
            this.Button_OpenFile.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Button_OpenFile.Location = new System.Drawing.Point(1, -1);
            this.Button_OpenFile.Name = "Button_OpenFile";
            this.Button_OpenFile.Size = new System.Drawing.Size(93, 30);
            this.Button_OpenFile.TabIndex = 0;
            this.Button_OpenFile.Text = "打开文件";
            this.Button_OpenFile.UseVisualStyleBackColor = false;
            this.Button_OpenFile.Click += new System.EventHandler(this.Button_OpenFile_Click);
            // 
            // Button_Start
            // 
            this.Button_Start.BackColor = System.Drawing.SystemColors.Control;
            this.Button_Start.Enabled = false;
            this.Button_Start.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Button_Start.Location = new System.Drawing.Point(108, -1);
            this.Button_Start.Name = "Button_Start";
            this.Button_Start.Size = new System.Drawing.Size(93, 30);
            this.Button_Start.TabIndex = 1;
            this.Button_Start.Text = "开始调度";
            this.Button_Start.UseVisualStyleBackColor = false;
            this.Button_Start.Click += new System.EventHandler(this.Button_Start_Click);
            // 
            // Button_Pause
            // 
            this.Button_Pause.BackColor = System.Drawing.SystemColors.Control;
            this.Button_Pause.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Button_Pause.Location = new System.Drawing.Point(218, -1);
            this.Button_Pause.Name = "Button_Pause";
            this.Button_Pause.Size = new System.Drawing.Size(93, 30);
            this.Button_Pause.TabIndex = 2;
            this.Button_Pause.Text = "暂停调度";
            this.Button_Pause.UseVisualStyleBackColor = false;
            this.Button_Pause.Click += new System.EventHandler(this.Button_Pause_Click);
            // 
            // Label_Time_Break1
            // 
            this.Label_Time_Break1.AutoSize = true;
            this.Label_Time_Break1.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Label_Time_Break1.Location = new System.Drawing.Point(338, 20);
            this.Label_Time_Break1.Name = "Label_Time_Break1";
            this.Label_Time_Break1.Size = new System.Drawing.Size(107, 25);
            this.Label_Time_Break1.TabIndex = 3;
            this.Label_Time_Break1.Text = "时间片大小";
            // 
            // Box_Time_Break
            // 
            this.Box_Time_Break.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Box_Time_Break.Location = new System.Drawing.Point(451, 20);
            this.Box_Time_Break.Name = "Box_Time_Break";
            this.Box_Time_Break.Size = new System.Drawing.Size(113, 27);
            this.Box_Time_Break.TabIndex = 4;
            this.Box_Time_Break.Text = "1000";
            // 
            // Label_Time_Break_s
            // 
            this.Label_Time_Break_s.AutoSize = true;
            this.Label_Time_Break_s.Cursor = System.Windows.Forms.Cursors.Default;
            this.Label_Time_Break_s.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Label_Time_Break_s.Location = new System.Drawing.Point(570, 20);
            this.Label_Time_Break_s.Name = "Label_Time_Break_s";
            this.Label_Time_Break_s.Size = new System.Drawing.Size(50, 25);
            this.Label_Time_Break_s.TabIndex = 5;
            this.Label_Time_Break_s.Text = "毫秒";
            // 
            // Label_Processing
            // 
            this.Label_Processing.AutoSize = true;
            this.Label_Processing.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Label_Processing.Location = new System.Drawing.Point(12, 90);
            this.Label_Processing.Name = "Label_Processing";
            this.Label_Processing.Size = new System.Drawing.Size(132, 27);
            this.Label_Processing.TabIndex = 6;
            this.Label_Processing.Text = "当前运行进程";
            // 
            // Box_Processing
            // 
            this.Box_Processing.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Box_Processing.Location = new System.Drawing.Point(17, 120);
            this.Box_Processing.Name = "Box_Processing";
            this.Box_Processing.Size = new System.Drawing.Size(127, 27);
            this.Box_Processing.TabIndex = 7;
            // 
            // Label_Ready
            // 
            this.Label_Ready.AutoSize = true;
            this.Label_Ready.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Label_Ready.Location = new System.Drawing.Point(12, 187);
            this.Label_Ready.Name = "Label_Ready";
            this.Label_Ready.Size = new System.Drawing.Size(92, 27);
            this.Label_Ready.TabIndex = 8;
            this.Label_Ready.Text = "就绪队列";
            // 
            // ListBox_ReadyQueue
            // 
            this.ListBox_ReadyQueue.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ListBox_ReadyQueue.FormattingEnabled = true;
            this.ListBox_ReadyQueue.ItemHeight = 20;
            this.ListBox_ReadyQueue.Location = new System.Drawing.Point(17, 217);
            this.ListBox_ReadyQueue.Name = "ListBox_ReadyQueue";
            this.ListBox_ReadyQueue.Size = new System.Drawing.Size(145, 204);
            this.ListBox_ReadyQueue.TabIndex = 9;
            // 
            // Label_Ready_After
            // 
            this.Label_Ready_After.AutoSize = true;
            this.Label_Ready_After.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Label_Ready_After.Location = new System.Drawing.Point(199, 187);
            this.Label_Ready_After.Name = "Label_Ready_After";
            this.Label_Ready_After.Size = new System.Drawing.Size(132, 27);
            this.Label_Ready_After.TabIndex = 10;
            this.Label_Ready_After.Text = "后备就绪队列";
            // 
            // ListBox_ReadyAfterQueue
            // 
            this.ListBox_ReadyAfterQueue.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ListBox_ReadyAfterQueue.FormattingEnabled = true;
            this.ListBox_ReadyAfterQueue.ItemHeight = 20;
            this.ListBox_ReadyAfterQueue.Location = new System.Drawing.Point(204, 217);
            this.ListBox_ReadyAfterQueue.Name = "ListBox_ReadyAfterQueue";
            this.ListBox_ReadyAfterQueue.Size = new System.Drawing.Size(145, 204);
            this.ListBox_ReadyAfterQueue.TabIndex = 11;
            // 
            // ListBox_ReadyIn
            // 
            this.ListBox_ReadyIn.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ListBox_ReadyIn.FormattingEnabled = true;
            this.ListBox_ReadyIn.ItemHeight = 20;
            this.ListBox_ReadyIn.Location = new System.Drawing.Point(389, 217);
            this.ListBox_ReadyIn.Name = "ListBox_ReadyIn";
            this.ListBox_ReadyIn.Size = new System.Drawing.Size(145, 204);
            this.ListBox_ReadyIn.TabIndex = 12;
            this.ListBox_ReadyIn.SelectedIndexChanged += new System.EventHandler(this.ListBox_ReadyIn_SelectedIndexChanged);
            // 
            // Label_ReadyIn
            // 
            this.Label_ReadyIn.AutoSize = true;
            this.Label_ReadyIn.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Label_ReadyIn.Location = new System.Drawing.Point(384, 187);
            this.Label_ReadyIn.Name = "Label_ReadyIn";
            this.Label_ReadyIn.Size = new System.Drawing.Size(132, 27);
            this.Label_ReadyIn.TabIndex = 13;
            this.Label_ReadyIn.Text = "输入等待队列";
            // 
            // Lable_ReadyOut
            // 
            this.Lable_ReadyOut.AutoSize = true;
            this.Lable_ReadyOut.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Lable_ReadyOut.Location = new System.Drawing.Point(570, 187);
            this.Lable_ReadyOut.Name = "Lable_ReadyOut";
            this.Lable_ReadyOut.Size = new System.Drawing.Size(132, 27);
            this.Lable_ReadyOut.TabIndex = 14;
            this.Lable_ReadyOut.Text = "输出等待队列";
            // 
            // ListBox_ReadyOut
            // 
            this.ListBox_ReadyOut.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ListBox_ReadyOut.FormattingEnabled = true;
            this.ListBox_ReadyOut.ItemHeight = 20;
            this.ListBox_ReadyOut.Location = new System.Drawing.Point(575, 217);
            this.ListBox_ReadyOut.Name = "ListBox_ReadyOut";
            this.ListBox_ReadyOut.Size = new System.Drawing.Size(145, 204);
            this.ListBox_ReadyOut.TabIndex = 15;
            // 
            // Label_OtherWait
            // 
            this.Label_OtherWait.AutoSize = true;
            this.Label_OtherWait.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Label_OtherWait.Location = new System.Drawing.Point(761, 187);
            this.Label_OtherWait.Name = "Label_OtherWait";
            this.Label_OtherWait.Size = new System.Drawing.Size(132, 27);
            this.Label_OtherWait.TabIndex = 16;
            this.Label_OtherWait.Text = "其他等待队列";
            // 
            // ListBox_OtherWait
            // 
            this.ListBox_OtherWait.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ListBox_OtherWait.FormattingEnabled = true;
            this.ListBox_OtherWait.ItemHeight = 20;
            this.ListBox_OtherWait.Location = new System.Drawing.Point(766, 217);
            this.ListBox_OtherWait.Name = "ListBox_OtherWait";
            this.ListBox_OtherWait.Size = new System.Drawing.Size(145, 204);
            this.ListBox_OtherWait.TabIndex = 17;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(384, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 27);
            this.label2.TabIndex = 20;
            this.label2.Text = "剩余时间片";
            // 
            // Box_needtime
            // 
            this.Box_needtime.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Box_needtime.Location = new System.Drawing.Point(389, 120);
            this.Box_needtime.Name = "Box_needtime";
            this.Box_needtime.Size = new System.Drawing.Size(127, 27);
            this.Box_needtime.TabIndex = 21;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(570, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 27);
            this.label3.TabIndex = 22;
            this.label3.Text = "当前时间片";
            // 
            // Box_timecount
            // 
            this.Box_timecount.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Box_timecount.Location = new System.Drawing.Point(575, 120);
            this.Box_timecount.Name = "Box_timecount";
            this.Box_timecount.Size = new System.Drawing.Size(127, 27);
            this.Box_timecount.TabIndex = 23;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(956, 493);
            this.Controls.Add(this.Box_timecount);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Box_needtime);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ListBox_OtherWait);
            this.Controls.Add(this.Label_OtherWait);
            this.Controls.Add(this.ListBox_ReadyOut);
            this.Controls.Add(this.Lable_ReadyOut);
            this.Controls.Add(this.Label_ReadyIn);
            this.Controls.Add(this.ListBox_ReadyIn);
            this.Controls.Add(this.ListBox_ReadyAfterQueue);
            this.Controls.Add(this.Label_Ready_After);
            this.Controls.Add(this.ListBox_ReadyQueue);
            this.Controls.Add(this.Label_Ready);
            this.Controls.Add(this.Box_Processing);
            this.Controls.Add(this.Label_Processing);
            this.Controls.Add(this.Label_Time_Break_s);
            this.Controls.Add(this.Box_Time_Break);
            this.Controls.Add(this.Label_Time_Break1);
            this.Controls.Add(this.Button_Pause);
            this.Controls.Add(this.Button_Start);
            this.Controls.Add(this.Button_OpenFile);
            this.Name = "Form1";
            this.Text = "时间片轮转";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Button_OpenFile;
        private System.Windows.Forms.Button Button_Start;
        private System.Windows.Forms.Button Button_Pause;
        private System.Windows.Forms.Label Label_Time_Break1;
        private System.Windows.Forms.TextBox Box_Time_Break;
        private System.Windows.Forms.Label Label_Time_Break_s;
        private System.Windows.Forms.Label Label_Processing;
        private System.Windows.Forms.TextBox Box_Processing;
        private System.Windows.Forms.Label Label_Ready;
        private System.Windows.Forms.ListBox ListBox_ReadyQueue;
        private System.Windows.Forms.Label Label_Ready_After;
        private System.Windows.Forms.ListBox ListBox_ReadyAfterQueue;
        private System.Windows.Forms.ListBox ListBox_ReadyIn;
        private System.Windows.Forms.Label Label_ReadyIn;
        private System.Windows.Forms.Label Lable_ReadyOut;
        private System.Windows.Forms.ListBox ListBox_ReadyOut;
        private System.Windows.Forms.Label Label_OtherWait;
        private System.Windows.Forms.ListBox ListBox_OtherWait;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Box_needtime;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Box_timecount;
    }
}

