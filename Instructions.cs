namespace System_scheduling
{
    public class Instructions
    {
        /*
        * IName: 指令类型
        * IRuntime:指令运行时间
        * IRemainTime:指令剩余运行时间
        */
        public char IName;
        public double IRunTime;
        public double IRemainTime;

        /*
         * 指令对象
         */
        public Instructions(char Name, double RunTime, double RemainTime)
        {
            this.IName = Name;
            this.IRunTime = RunTime;
            this.IRemainTime = RemainTime;
        }
    }
}
