using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MiniOSResourceMonitor.Models;

namespace MiniOSResourceMonitor.Interfaces
{
    /// <summary>
    /// Contract for computing and retrieving performance metrics.
    /// </summary>
    public interface IPerformanceService
    {
        /// <summary>
        /// Calculates a fresh PerformanceMetrics snapshot based on
        /// current process states and resource usage.
        /// </summary>
        PerformanceMetrics Calculate(int currentStep);

        /// <summary>Returns the most recently calculated metrics snapshot.</summary>
        PerformanceMetrics GetLatest();
    }
}