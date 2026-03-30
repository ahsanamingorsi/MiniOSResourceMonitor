using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniOSResourceMonitor.Models
{
    /// <summary>
    /// Snapshot of OS performance at a given simulation step.
    /// Calculated fresh after every step transition.
    /// </summary>
    public class PerformanceMetrics
    {
        /// <summary>Simulation step this snapshot belongs to.</summary>
        public int SimulationStep { get; set; }

        // ── Resource Utilization ──────────────────────────────────────────────

        /// <summary>CPU units currently in use by all Running processes.</summary>
        public int UsedCpuUnits { get; set; }

        /// <summary>Total CPU units configured in the system.</summary>
        public int TotalCpuUnits { get; set; }

        /// <summary>CPU Utilization % = (UsedCpuUnits / TotalCpuUnits) * 100</summary>
        public double CpuUtilizationPercent =>
            TotalCpuUnits > 0 ? (UsedCpuUnits / (double)TotalCpuUnits) * 100.0 : 0;

        /// <summary>Memory in MB currently allocated to non-Terminated processes.</summary>
        public int UsedMemoryMB { get; set; }

        /// <summary>Total memory configured in the system.</summary>
        public int TotalMemoryMB { get; set; }

        /// <summary>Memory utilization % = (UsedMemoryMB / TotalMemoryMB) * 100</summary>
        public double MemoryUtilizationPercent =>
            TotalMemoryMB > 0 ? (UsedMemoryMB / (double)TotalMemoryMB) * 100.0 : 0;

        /// <summary>I/O units currently in use by all Waiting processes.</summary>
        public int UsedIoUnits { get; set; }

        /// <summary>Total I/O units configured in the system.</summary>
        public int TotalIoUnits { get; set; }

        // ── Throughput & Waiting ──────────────────────────────────────────────

        /// <summary>Total processes that have reached Terminated state.</summary>
        public int CompletedProcesses { get; set; }

        /// <summary>
        /// Throughput = CompletedProcesses / SimulationStep
        /// (processes completed per simulation step)
        /// </summary>
        public double Throughput =>
            SimulationStep > 0 ? (double)CompletedProcesses / SimulationStep : 0;

        /// <summary>
        /// Average waiting time across all processes that have ever been in Waiting state.
        /// </summary>
        public double AverageWaitingTime { get; set; }

        /// <summary>Number of processes currently in Ready queue.</summary>
        public int ReadyQueueCount { get; set; }

        /// <summary>Number of processes currently Running.</summary>
        public int RunningCount { get; set; }

        /// <summary>Number of processes currently Waiting on I/O.</summary>
        public int WaitingCount { get; set; }
    }
}