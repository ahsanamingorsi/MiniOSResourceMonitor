using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MiniOSResourceMonitor.Models;

namespace MiniOSResourceMonitor.Interfaces
{
    /// <summary>
    /// Contract for allocating and releasing CPU, Memory, and I/O resources.
    /// </summary>
    public interface IResourceAllocator
    {
        // ── Availability Checks ───────────────────────────────────────────────

        /// <summary>Returns true if enough CPU units are free for the given process.</summary>
        bool IsCpuAvailable(OsProcess process);

        /// <summary>Returns true if enough Memory is free for the given process.</summary>
        bool IsMemoryAvailable(OsProcess process);

        /// <summary>Returns true if enough I/O units are free for the given process.</summary>
        bool IsIoAvailable(OsProcess process);

        // ── Allocation ────────────────────────────────────────────────────────

        /// <summary>Reserves CPU units for a Running process.</summary>
        void AllocateCpu(OsProcess process);

        /// <summary>Reserves Memory for a process entering Ready state.</summary>
        void AllocateMemory(OsProcess process);

        /// <summary>Reserves I/O units for a Waiting process.</summary>
        void AllocateIo(OsProcess process);

        // ── Release ───────────────────────────────────────────────────────────

        /// <summary>Frees CPU units when process leaves Running state.</summary>
        void ReleaseCpu(OsProcess process);

        /// <summary>Frees Memory when process reaches Terminated state.</summary>
        void ReleaseMemory(OsProcess process);

        /// <summary>Frees I/O units when process leaves Waiting state.</summary>
        void ReleaseIo(OsProcess process);

        // ── Totals ────────────────────────────────────────────────────────────

        int GetUsedCpu();
        int GetUsedMemory();
        int GetUsedIo();

        /// <summary>Resets all allocated resource counters to zero.</summary>
        void Reset();
    }
}