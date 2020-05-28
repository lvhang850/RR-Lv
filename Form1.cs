using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;



namespace System_scheduling
{

    public partial class Form1 : Form
    {
        private List<Instructions> InsList;          // 指令列表
        private List<PCB> AllQueue;                  // 全部队列
        private List<PCB> ReadyQueue;                // 就绪队列
        private List<PCB> ReserveQueue;              // 后备就绪队列
        private List<PCB> InputQueue;                // 输入等待队列
        private List<PCB> OutputQueue;               // 输出等待队列
        private List<PCB> OtherQueue;                // 其它等待队列
        public Form1()
        {
            InitializeComponent();
        }



        #region 读取文件
        private void Button_OpenFile_Click(object sender, EventArgs e)
        {
            ListBox_ReadyQueue.Items.Clear();           // 清除列表
            AllQueue = new List<PCB>();              // 初始化全部进程队列
            ReadyQueue = new List<PCB>();
            ReserveQueue = new List<PCB>();
            InputQueue = new List<PCB>();
            OutputQueue = new List<PCB>();
            OtherQueue = new List<PCB>();

            OpenFileDialog OFD = new OpenFileDialog();//获取文件路径并读取
            OFD.ShowDialog();
            string Path = OFD.FileName;
            Console.WriteLine(Path);//输出屏幕
            if (Path != String.Empty)
            {
                StreamReader SR = new StreamReader(Path, Encoding.Default);

                string Content = @"";
                string ProcessName = @"";
                while ((Content = SR.ReadLine()) != null)
                {
                    if (Content.StartsWith("P") || Content.StartsWith("p"))
                    {
                        ProcessName = Content;
                        ListBox_ReadyQueue.Items.Add(ProcessName);
                        InsList = new List<Instructions>();
                    }
                    else if (Content.StartsWith("H"))
                    {
                        /*
                         * 这一部分处理最后获取的结束指令，代表进程结束，将指令列表添加进PCB列表
                         * 从文件中读取下列指令：
                         * IName: 指令类型
                         * IRuntime:指令运行时间
                         * IRemainTime:指令剩余运行时间
                         */
                        char IName = char.Parse(Content.Substring(0, 1));
                        double IRunTime = double.Parse(Content.Substring(1, 2));
                        double IRemainTime = double.Parse(Content.Substring(1, 2));

                        // 指令生成
                        Instructions Ins = new Instructions(IName, IRunTime, IRemainTime);

                        // 往指令列表中添加指令
                        InsList.Add(Ins);

                        /*
                         * 进程生成
                         * 进程初始化：进程名称，进程指令列表，指令索引初始化
                         */
                        PCB PCB_P = new PCB(ProcessName, InsList, 0);

                        // 往进程表中添加进程
                        AllQueue.Add(PCB_P);
                    }
                    else
                    {
                        /*
                    * 这一部分主要处理非 P & H 开头的指令
                    * 处理过程同上...
                    */
                        char IName = char.Parse(Content.Substring(0, 1));
                        double IRunTime = double.Parse(Content.Substring(1, 2));
                        double IRemainTime = double.Parse(Content.Substring(1, 2));

                        Instructions Ins = new Instructions(IName, IRunTime, IRemainTime);
                        InsList.Add(Ins);
                    }
                    Button_Start.Enabled = true;
                    Button_OpenFile.Enabled = false;
                }
            }
        }
        #endregion

        #region 控件刷新
        public void F5()
        {
            ListBox_ReadyAfterQueue.Items.Clear();
            for (int i = 0; i < ReserveQueue.Count(); i++)
            {
                ListBox_ReadyAfterQueue.Items.Add(ReserveQueue[i].PName);
            }

            ListBox_ReadyQueue.Items.Clear();
            for (int i = 0; i < ReadyQueue.Count(); i++)
            {
                ListBox_ReadyQueue.Items.Add(ReadyQueue[i].PName);
            }

            ListBox_OtherWait.Items.Clear();
            for (int i = 0; i < OtherQueue.Count(); i++)
            {
                ListBox_OtherWait.Items.Add(OtherQueue[i].PName);
            }

            ListBox_ReadyIn.Items.Clear();
            for (int i = 0; i < InputQueue.Count(); i++)
            {
                ListBox_ReadyIn.Items.Add(InputQueue[i].PName);
            }

            ListBox_ReadyOut.Items.Clear();
            for (int i = 0; i < OutputQueue.Count(); i++)
            {
                ListBox_ReadyOut.Items.Add(OutputQueue[i].PName);
            }
        }

        #endregion

        #region 初次分类
        public void SortFirst(PCB QueueName)
        {
            int temp1 = ReserveQueue.Count();//防止删除后越界
            for (int i = 0; i < temp1; i++)
            {
                if (QueueName.PName == ReserveQueue[i].PName)
                {
                    ReserveQueue.Remove(ReserveQueue[i]);
                    temp1 = ReserveQueue.Count();
                }
            }

            temp1 = ReadyQueue.Count();
            for (int i = 0; i < ReadyQueue.Count(); i++)
            {
                if (QueueName.PName == ReadyQueue[i].PName)
                {
                    ReadyQueue.Remove(ReadyQueue[i]);
                    temp1 = ReadyQueue.Count();
                }
            }

            int icount = QueueName.CurrentInstruction;
            if (icount < QueueName.PInstructions.Count())
            {
                switch (QueueName.PInstructions[icount].IName.ToString())//分辨指令类型
                {
                    #region CPU计算
                    case "C":
                        AddList(ReadyQueue, QueueName.PName, QueueName.PInstructions, QueueName.CurrentInstruction);//放入就绪队列
                        break;
                    #endregion

                    #region 输入
                    case "I":
                        AddList(InputQueue, QueueName.PName, QueueName.PInstructions, QueueName.CurrentInstruction);//放入输入队列
                        break;
                    #endregion

                    #region 输出
                    case "O":
                        AddList(OutputQueue, QueueName.PName, QueueName.PInstructions, QueueName.CurrentInstruction);//放入输入队列
                        break;
                    #endregion

                    #region 等
                    case "W":
                        AddList(OtherQueue, QueueName.PName, QueueName.PInstructions, QueueName.CurrentInstruction);//放入输入队列
                        break;
                    #endregion

                    #region 结束
                    case "H":
                        //下次再说
                        if (ReadyQueue.Count() + InputQueue.Count() + OutputQueue.Count() + OtherQueue.Count() == 0)
                        {
                            Box_Processing.Text = "";
                            MessageBox.Show("所有进程完成");
                            timer1.Enabled = false;
                            tcountsum = 1;
                        }
                        break;
                        #endregion
                }
                F5();
            }
        }
        #endregion

        #region 指令分类
        public void SortOrder(PCB QueueName)
        {
            QueueName.CurrentInstruction++;//先转到下一条指令
            //先来个清理门户
            int temp1 = ReserveQueue.Count();//防止删除后越界
            for (int i = 0; i < temp1; i++)
            {
                if (QueueName.PName == ReserveQueue[i].PName)
                {
                    ReserveQueue.Remove(ReserveQueue[i]);
                    temp1 = ReserveQueue.Count();
                }
            }

            temp1 = ReadyQueue.Count();
            for (int i = 0; i < temp1; i++)
            {
                if (QueueName.PName == ReadyQueue[i].PName)
                {
                    ReadyQueue.Remove(ReadyQueue[i]);
                    temp1 = ReadyQueue.Count();
                }
            }

            temp1 = InputQueue.Count();
            for (int i = 0; i < temp1; i++)
            {
                if (QueueName.PName == InputQueue[i].PName)
                {
                    InputQueue.Remove(InputQueue[i]);
                    temp1 = InputQueue.Count();
                }
            }

            temp1 = OutputQueue.Count();
            for (int i = 0; i < temp1; i++)
            {
                if (QueueName.PName == OutputQueue[i].PName)
                {
                    OutputQueue.Remove(OutputQueue[i]);
                    temp1 = OutputQueue.Count();
                }
            }

            temp1 = OtherQueue.Count();
            for (int i = 0; i < temp1; i++)
            {
                if (QueueName.PName == OtherQueue[i].PName)
                {
                    OtherQueue.Remove(OtherQueue[i]);
                    temp1 = OtherQueue.Count();
                }
            }

            int icount = QueueName.CurrentInstruction;
            if (icount < QueueName.PInstructions.Count())
            {
                switch (QueueName.PInstructions[icount].IName.ToString())//分辨指令类型
                {
                    #region CPU计算
                    case "C":
                        AddList(ReadyQueue, QueueName.PName, QueueName.PInstructions, QueueName.CurrentInstruction);//放入就绪队列
                        break;
                    #endregion

                    #region 输入
                    case "I":
                        AddList(InputQueue, QueueName.PName, QueueName.PInstructions, QueueName.CurrentInstruction);//放入输入队列
                        break;
                    #endregion

                    #region 输出
                    case "O":
                        AddList(OutputQueue, QueueName.PName, QueueName.PInstructions, QueueName.CurrentInstruction);//放入输入队列
                        break;
                    #endregion

                    #region 等
                    case "W":
                        AddList(OtherQueue, QueueName.PName, QueueName.PInstructions, QueueName.CurrentInstruction);//放入输入队列
                        break;
                    #endregion

                    #region 结束
                    case "H":
                        //下次再说
                        if (ReadyQueue.Count() + InputQueue.Count() + OutputQueue.Count() + OtherQueue.Count() == 0)
                        {
                            Box_Processing.Text = "";
                            timer1.Enabled = false;
                            tcountsum = 1;
                            Button_Start.Enabled = false;
                            Button_OpenFile.Enabled = true;
                            Box_needtime.Text = "";
                            Box_timecount.Text = "";

                            MessageBox.Show("所有进程完成");
                        }
                        break;
                        #endregion
                }
                F5();
            }
        }
        #endregion

        #region 开始调度
        private void Button_Start_Click(object sender, EventArgs e)
        {
            ReserveQueue = AllQueue;

            if (ReserveQueue == null || Box_Time_Break.Text == "0")
            {
                MessageBox.Show("错误：文件未打开或时间片大小不能为0");
            }

            //初始化就绪进程表剩余时间
            for (int i = 0; i < AllQueue.Count(); i++)//遍历每个进程
            {
                for (int j = 0; j < AllQueue[i].PInstructions.Count(); j++)//遍历进程中的每个指令
                {
                    ReserveQueue[i].PInstructions[j].IRemainTime = AllQueue[i].PInstructions[j].IRunTime;
                }
            }

            decimal result;
            decimal.TryParse(Box_Time_Break.Text, out result);//提前判断非数字
            if (Box_Time_Break.Text == String.Empty)
            {
                MessageBox.Show("请填写时间片");
            }

            else if (result != 0)
            {
                if (int.Parse(Box_Time_Break.Text) > 0)
                {
                    //开始写日记
                    InitLog("进程名\t运行指令\t\t指令索引\t\t剩余时间\t\t日记生成时间");

                    //这里进行第一次也是最后一次分类。利用后备就绪将进程分别装进4个队列

                    int temp1 = ReserveQueue.Count();
                    for (int i = 0; i < temp1; i++)//我全都要
                    {
                        //进行分类
                        SortFirst(ReserveQueue[0]);//进程分配进各个队列
                    }

                    //开始周转
                    timer1.Interval = int.Parse(Box_Time_Break.Text);
                    timer1.Start();
                    timer1.Tick += new EventHandler(timer_Tick);

                    Button_Start.Enabled = false;
                }
                else
                {
                    MessageBox.Show("请用正整数");
                }
            }
            else
            {
                MessageBox.Show("请用数字");
            }
        }
        #endregion

        #region 删除窗体队列元素
        public void DeleteQueue(ListBox ListBoxName, PCB QueueName)
        {
            ListBoxName.Items.Remove(QueueName.PName);
        }
        #endregion

        #region 队列添加元素
        public void AddList(List<PCB> QueueList, string Name, List<Instructions> Instruct, int current)
        {
            PCB TmpQueue = new PCB(Name, Instruct, current);
            QueueList.Add(TmpQueue);
        }
        #endregion

        #region 运行进程

        #region 无参调用
        public void RunningProcess()
        {
            double timsplice = double.Parse(Box_Time_Break.Text) / 1000.0;
            Box_timecount.Text = Convert.ToString(tcountsum);

            Box_Processing.Text = "";
            Box_needtime.Text = "";

            #region 处理其他队列

            for (int i = 0; i < InputQueue.Count(); i++)//每个都要处理
            {
                if (InputQueue[i].PInstructions[InputQueue[i].CurrentInstruction].IRemainTime <= timsplice)//一次完成
                {
                    InputQueue[i].PInstructions[InputQueue[i].CurrentInstruction].IRemainTime = 0;
                }
                else//慢慢来
                {
                    InputQueue[i].PInstructions[InputQueue[i].CurrentInstruction].IRemainTime -= timsplice;
                }
            }

            for (int i = 0; i < OutputQueue.Count(); i++)//每个都要处理
            {
                if (OutputQueue[i].PInstructions[OutputQueue[i].CurrentInstruction].IRemainTime <= timsplice)//一次完成
                {
                    OutputQueue[i].PInstructions[OutputQueue[i].CurrentInstruction].IRemainTime = 0;
                }
                else//慢慢来
                {
                    OutputQueue[i].PInstructions[OutputQueue[i].CurrentInstruction].IRemainTime -= timsplice;
                }
            }

            for (int i = 0; i < OtherQueue.Count(); i++)//每个都要处理
            {
                if (OtherQueue[i].PInstructions[OtherQueue[i].CurrentInstruction].IRemainTime <= timsplice)//一次完成
                {
                    OtherQueue[i].PInstructions[OtherQueue[i].CurrentInstruction].IRemainTime = 0;
                }
                else//慢慢来
                {
                    OtherQueue[i].PInstructions[OtherQueue[i].CurrentInstruction].IRemainTime -= timsplice;
                }
            }

            //这次循环结束的，统一这里重新发配，当场发配会导致重复消耗时间，比如一个C结束变成了I，结果这一时间片就直接减了

            int tempt1 = InputQueue.Count();
            for (int i = 0; i < tempt1; i++)//每个都要处理
            {
                if (InputQueue[i].PInstructions[InputQueue[i].CurrentInstruction].IRemainTime == 0)//一次完成
                {
                    SortOrder(InputQueue[i]);//重新分配
                    tempt1 = InputQueue.Count();//重新分配后上限改变
                    i = 0;//并且我们要重头开始，直到这里没有待分配
                }
            }

            tempt1 = OutputQueue.Count();
            for (int i = 0; i < tempt1; i++)//每个都要处理
            {
                if (OutputQueue[i].PInstructions[OutputQueue[i].CurrentInstruction].IRemainTime == 0)//一次完成
                {
                    SortOrder(OutputQueue[i]);//重新分配
                    tempt1 = OutputQueue.Count();
                    i = 0;
                }
            }

            tempt1 = OtherQueue.Count();
            for (int i = 0; i < OtherQueue.Count(); i++)//每个都要处理
            {
                if (OtherQueue[i].PInstructions[OtherQueue[i].CurrentInstruction].IRemainTime == 0)//一次完成
                {
                    SortOrder(OtherQueue[i]);//重新分配
                    tempt1 = OtherQueue.Count();
                    i = 0;
                }
            }
            #endregion
        }
        #endregion

        #region 带参调用
        public void RunningProcess(PCB QueueName)
        {
            int icount = QueueName.CurrentInstruction;
            double timsplice = double.Parse(Box_Time_Break.Text) / 1000.0;
            double rmtime = QueueName.PInstructions[icount].IRemainTime;

            Box_Processing.Text = QueueName.PName;
            Box_needtime.Text = Convert.ToString(rmtime);
            Box_timecount.Text = Convert.ToString(tcountsum);

            #region 处理就绪队列
            AddLog(QueueName.PName + "\tC\t\t" + QueueName.CurrentInstruction + "\t\t" + QueueName.PInstructions[icount].IRemainTime + "\t\t");
            if (rmtime <= timsplice)//一次完成
            {
                QueueName.PInstructions[icount].IRemainTime = 0;
            }
            else
            {
                QueueName.PInstructions[icount].IRemainTime = rmtime - timsplice;
                QueueName.CurrentInstruction = icount;
            }
            #endregion

            #region 处理其他队列
            for (int i = 0; i < InputQueue.Count(); i++)//每个都要处理
            {
                AddLog(InputQueue[i].PName + "\tI\t\t" + InputQueue[i].CurrentInstruction + "\t\t" + InputQueue[i].PInstructions[icount].IRemainTime + "\t\t");
                if (InputQueue[i].PInstructions[InputQueue[i].CurrentInstruction].IRemainTime <= timsplice)//一次完成
                {
                    InputQueue[i].PInstructions[InputQueue[i].CurrentInstruction].IRemainTime = 0;
                }
                else//慢慢来
                {
                    InputQueue[i].PInstructions[InputQueue[i].CurrentInstruction].IRemainTime -= timsplice;
                }
            }

            for (int i = 0; i < OutputQueue.Count(); i++)//每个都要处理
            {
                AddLog(OutputQueue[i].PName + "\tO\t\t" + OutputQueue[i].CurrentInstruction + "\t\t" + OutputQueue[i].PInstructions[icount].IRemainTime + "\t\t");
                if (OutputQueue[i].PInstructions[OutputQueue[i].CurrentInstruction].IRemainTime <= timsplice)//一次完成
                {
                    OutputQueue[i].PInstructions[OutputQueue[i].CurrentInstruction].IRemainTime = 0;
                }
                else//慢慢来
                {
                    OutputQueue[i].PInstructions[OutputQueue[i].CurrentInstruction].IRemainTime -= timsplice;
                }
            }

            for (int i = 0; i < OtherQueue.Count(); i++)//每个都要处理
            {
                AddLog(OtherQueue[i].PName + "\tW\t\t" + OtherQueue[i].CurrentInstruction + "\t\t" + OtherQueue[i].PInstructions[icount].IRemainTime + "\t\t");
                if (OtherQueue[i].PInstructions[OtherQueue[i].CurrentInstruction].IRemainTime <= timsplice)//一次完成
                {
                    OtherQueue[i].PInstructions[OtherQueue[i].CurrentInstruction].IRemainTime = 0;
                }
                else//慢慢来
                {
                    OtherQueue[i].PInstructions[OtherQueue[i].CurrentInstruction].IRemainTime -= timsplice;
                }
            }

            //这次循环结束的，统一这里重新发配，当场发配会导致重复消耗时间，比如一个C结束变成了I，结果这一时间片就直接减了

            if (QueueName.PInstructions[icount].IRemainTime == 0)
            {
                SortOrder(QueueName);
            }
            else
            {
                SortFirst(QueueName);
            }

            int tempt1 = InputQueue.Count();
            for (int i = 0; i < tempt1; i++)//每个都要处理
            {
                if (InputQueue[i].PInstructions[InputQueue[i].CurrentInstruction].IRemainTime == 0)//一次完成
                {
                    SortOrder(InputQueue[i]);//重新分配
                    tempt1 = InputQueue.Count();//重新分配后上限改变
                    i = 0;//并且我们要重头开始，直到这里没有待分配
                }
            }

            tempt1 = OutputQueue.Count();
            for (int i = 0; i < tempt1; i++)//每个都要处理
            {
                if (OutputQueue[i].PInstructions[OutputQueue[i].CurrentInstruction].IRemainTime == 0)//一次完成
                {
                    SortOrder(OutputQueue[i]);//重新分配
                    tempt1 = OutputQueue.Count();
                    i = 0;
                }
            }

            tempt1 = OtherQueue.Count();
            for (int i = 0; i < OtherQueue.Count(); i++)//每个都要处理
            {
                if (OtherQueue[i].PInstructions[OtherQueue[i].CurrentInstruction].IRemainTime == 0)//一次完成
                {
                    SortOrder(OtherQueue[i]);//重新分配
                    tempt1 = OtherQueue.Count();
                    i = 0;
                }
            }
            #endregion

        }
        #endregion
        #endregion

        #region 时间片函数
        int tcountsum = 1;
        private void timer_Tick(object sender, EventArgs e)
        {
            int tempt1 = ReadyQueue.Count();
            if (ReadyQueue.Count() > 0)//按进程一个个运行
            {
                RunningProcess(ReadyQueue[0]);//依次运行
                tcountsum++;//计算总时间片
            }
            else//当没有人使用CPU时
            {
                RunningProcess( );//生活依然要继续
                tcountsum++;//计算总时间片
            }
        }

        #endregion

        #region 暂停调度
        private void Button_Pause_Click(object sender, EventArgs e)
        {
            if (Button_Pause.Text == "暂停调度")
            {
                Button_Pause.Text = "继续调度";
                timer1.Enabled = false;
            }
            else
            {
                Button_Pause.Text = "暂停调度";
                timer1.Enabled = true;
            }
        }
        #endregion

        #region 日志部分
        //初始化
        public static void InitLog(string msg)
        {
            string saveFolder = "Record";//日志文件保存路径  
            string tishiMsg = "";
            try
            {
                string fileName = DateTime.Now.ToString("yyyy-MM-dd");
                string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, saveFolder);
                if (Directory.Exists(filePath) == false)
                {
                    Directory.CreateDirectory(filePath);
                }
                string fileAbstractPath = filePath + "\\" + fileName + ".txt";
                FileStream fs = new FileStream(fileAbstractPath, FileMode.Append);
                StreamWriter sw = new StreamWriter(fs);
                //开始写入       
                string time = DateTime.Now.ToString("HH:mm:ss.fff");
                msg = msg + System.Environment.NewLine;
                sw.Write(msg);
                //清空缓冲区                 
                sw.Flush();
                //关闭流                 
                sw.Close();
                sw.Dispose();
                fs.Close();
                fs.Dispose();

                tishiMsg = "写入日志成功";
            }
            catch (Exception ex)
            {
                string datetime = DateTime.Now.ToString("HH:mm:ss.fff");
                tishiMsg = "[" + datetime + "]写入日志出错：" + ex.Message;
            }
        }

        //添加
        public static void AddLog(string msg)
        {
            string saveFolder = "Record";//日志文件保存路径  
            string tishiMsg = "";
            try
            {
                string fileName = DateTime.Now.ToString("yyyy-MM-dd");
                string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, saveFolder);
                if (Directory.Exists(filePath) == false)
                {
                    Directory.CreateDirectory(filePath);
                }
                string fileAbstractPath = filePath + "\\" + fileName + ".txt";
                FileStream fs = new FileStream(fileAbstractPath, FileMode.Append);
                StreamWriter sw = new StreamWriter(fs);
                //开始写入       
                string time = DateTime.Now.ToString("HH:mm:ss.fff");
                //msg = time + "," + msg + System.Environment.NewLine;
                msg = msg + time + System.Environment.NewLine;
                sw.Write(msg);
                //清空缓冲区                 
                sw.Flush();
                //关闭流                 
                sw.Close();
                sw.Dispose();
                fs.Close();
                fs.Dispose();

                tishiMsg = "写入日志成功";
            }
            catch (Exception ex)
            {
                string datetime = DateTime.Now.ToString("HH:mm:ss.fff");
                tishiMsg = "[" + datetime + "]写入日志出错：" + ex.Message;
            }
        }
        #endregion

        #region 手贱点错了
        private void ListBox_ReadyIn_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        #endregion







    }
}
