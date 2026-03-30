using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MiniOSResourceMonitor.Interfaces;
using MiniOSResourceMonitor.Models;

namespace MiniOSResourceMonitor.Services
{
    /// <summary>
    /// Tracks and manages allocation of CPU, Memory, and I/O resources.
    /// All decisions are rule-based — no randomness.
    /// </summary>
    public class ResourceAllocator : IResourceAllocator
    {
        private readonly IConfigurationService _configService;

        // Running totals of currently allocated resources
        private int _usedCpu = 0;
        private int _usedMemory = 0;
        private int _usedIo = 0;

        public ResourceAllocator(IConfigurationService configService)
        {
            _configService = configService;
        }

        // ── Availability Checks ───────────────────────────────────────────────

        /// <inheritdoc/>
        public bool IsCpuAvailable(OsProcess process)
        {
            var cfg = _configService.GetConfig();
            return (_usedCpu + process.CpuRequirement) <= cfg.TotalCpuUnits;
        }

        /// <inheritdoc/>
        public bool IsMemoryAvailable(OsProcess process)
        {
            var cfg = _configService.GetConfig();
            return (_usedMemory + process.MemoryRequirementMB) <= cfg.TotalMemoryMB;
        }

        /// <inheritdoc/>
        public bool IsIoAvailable(OsProcess process)
        {
            var cfg = _configService.GetConfig();
            return (_usedIo + process.IoRequirement) <= cfg.TotalIoUnits;
        }

        // ── Allocation ────────────────────────────────────────────────────────

        /// <inheritdoc/>
        public void AllocateCpu(OsProcess process)
            => _usedCpu += process.CpuRequirement;

        /// <inheritdoc/>
        public void AllocateMemory(OsProcess process)
            => _usedMemory += process.MemoryRequirementMB;

        /// <inheritdoc/>
        public void AllocateIo(OsProcess process)
            => _usedIo += process.IoRequirement;

        // ── Release ───────────────────────────────────────────────────────────

        /// <inheritdoc/>
        public void ReleaseCpu(OsProcess process)
            => _usedCpu = System.Math.Max(0, _usedCpu - process.CpuRequirement);

        /// <inheritdoc/>
        public void ReleaseMemory(OsProcess process)
            => _usedMemory = System.Math.Max(0, _usedMemory - process.MemoryRequirementMB);

        /// <inheritdoc/>
        public void ReleaseIo(OsProcess process)
            => _usedIo = System.Math.Max(0, _usedIo - process.IoRequirement);

        // ── Totals ────────────────────────────────────────────────────────────

        public int GetUsedCpu() => _usedCpu;
        public int GetUsedMemory() => _usedMemory;
        public int GetUsedIo() => _usedIo;

        /// <inheritdoc/>
        public void Reset()
        {
            _usedCpu = 0;
            _usedMemory = 0;
            _usedIo = 0;
        }
    }
}