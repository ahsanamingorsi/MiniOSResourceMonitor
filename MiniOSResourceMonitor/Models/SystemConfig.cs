using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace MiniOSResourceMonitor.Models
{
    /// <summary>
    /// Represents the fixed hardware configuration of the simulated OS.
    /// Set once before simulation begins.
    /// </summary>
    public class SystemConfig
    {
        /// <summary>Total CPU units available in the system (e.g., 100 = 100%).</summary>
        public int TotalCpuUnits { get; set; } = 100;

        /// <summary>Total RAM available in megabytes.</summary>
        public int TotalMemoryMB { get; set; } = 1024;

        /// <summary>Total I/O device slots/units available.</summary>
        public int TotalIoUnits { get; set; } = 10;

        /// <summary>Validates that all config values are positive integers.</summary>
        public bool IsValid()
        {
            return TotalCpuUnits > 0
                && TotalMemoryMB > 0
                && TotalIoUnits > 0;
        }
    }
}

