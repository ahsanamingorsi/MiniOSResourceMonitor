 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public enum ProcessState
{
    New,
    Ready,
    Running,
    Waiting,
   Terminated
}
public class ProcessModel
{
    public int ProcessId { get; set; }

    public int CpuRequired { get; set; }     // percentage
    public int MemoryRequired { get; set; }  // MB
    public int IoRequired { get; set; }       // units

    public ProcessState State { get; set; }

    public int WaitingTime { get; set; }
    public int TurnaroundTime { get; set; }
}
