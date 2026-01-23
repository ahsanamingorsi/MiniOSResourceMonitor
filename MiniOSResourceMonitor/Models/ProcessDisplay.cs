using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;

public class ProcessDisplay
{
    public int ProcessID { get; set; }
    public int CPU { get; set; }
    public int Memory { get; set; }
    public int IO { get; set; }
    public string State { get; set; }
    public int WaitingTime { get; set; }
    public int TurnaroundTime { get; set; }
}
