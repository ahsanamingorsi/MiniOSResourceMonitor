using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiniOSResourceMonitor.Interfaces;
using MiniOSResourceMonitor.Models;
using System.Collections.Generic;
using System.Linq;

namespace MiniOSResourceMonitor.Services
{
    /// <summary>
    /// Manages the collection of simulated OS processes.
    /// Handles creation, retrieval, editing, and deletion.
    /// </summary>
    public class ProcessService : IProcessService
    {
        private readonly List<OsProcess> _processes = new();
        private int _nextId = 1;

        /// <inheritdoc/>
        public int AddProcess(OsProcess process)
        {
            process.ProcessId = _nextId++;
            process.Name = string.IsNullOrWhiteSpace(process.Name)
                                    ? $"Process_{process.ProcessId}"
                                    : process.Name;
            process.State = ProcessState.New; // Always starts as New
            _processes.Add(process);
            return process.ProcessId;
        }

        /// <inheritdoc/>
        public bool RemoveProcess(int processId)
        {
            var process = GetProcessById(processId);
            if (process == null) return false;

            // Do not remove a Running process mid-step — caller must check
            if (process.State == ProcessState.Running) return false;

            _processes.Remove(process);
            return true;
        }

        /// <inheritdoc/>
        public bool UpdateProcess(OsProcess updated)
        {
            var existing = GetProcessById(updated.ProcessId);
            if (existing == null) return false;

            // Only allow editing if process hasn't moved past New/Ready
            if (existing.State == ProcessState.Running ||
                existing.State == ProcessState.Waiting ||
                existing.State == ProcessState.Terminated)
                return false;

            existing.Name = updated.Name;
            existing.CpuRequirement = updated.CpuRequirement;
            existing.MemoryRequirementMB = updated.MemoryRequirementMB;
            existing.IoRequirement = updated.IoRequirement;
            existing.RemainingBurstTime = updated.RemainingBurstTime;
            return true;
        }

        /// <inheritdoc/>
        public OsProcess? GetProcessById(int processId)
            => _processes.FirstOrDefault(p => p.ProcessId == processId);

        /// <inheritdoc/>
        public List<OsProcess> GetAllProcesses() => _processes.ToList();

        /// <inheritdoc/>
        public List<OsProcess> GetProcessesByState(ProcessState state)
            => _processes.Where(p => p.State == state).ToList();

        /// <inheritdoc/>
        public void Reset()
        {
            _processes.Clear();
            _nextId = 1;
        }
    }
}