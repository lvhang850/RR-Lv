using System.Collections.Generic;
//用来使用集合 List<T>

namespace System_scheduling
{

    public class PCB
    {
        /*
         * PName:进程名称
         * PInstructions:进程中的指令列表
         * CurrentInstruction:当前运行指令索引
         */
        public string PName;
        public List<Instructions> PInstructions;
        public int CurrentInstruction;

        public PCB(string Name, List<Instructions> Instruct, int current)
        {
            this.PName = Name;
            this.PInstructions = Instruct;
            this.CurrentInstruction = current;
        }
    }
}

