using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
public class SystemConfig
{
    public int TotalCPU { get; set; }       // percentage, example 100
    public int TotalMemory { get; set; }    // MB
    public int TotalIO { get; set; }         // units

    public bool IsConfigured { get; set; }
}

