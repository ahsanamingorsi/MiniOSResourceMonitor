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
    /// Computes performance metrics from current simulation state.
    /// All values are derived deterministically — no estimation or randomness.
    /// </summary>
    public class PerformanceCalculator : IPerformanceService
    {
        private readonly IProcessService _processService;
        private readonly IResourceAllocator _allocator;
        private readonly IConfigurationService _configService;

        private PerformanceMetrics _latest = new();

        public PerformanceCalculator(
            IProcessService processService,
            IResourceAllocator allocator,
            IConfigurationService configService)
        {
            _processService = processService;
            _allocator = allocator;
            _configService = configService;
        }

        /// <inheritdoc/>
        public PerformanceMetrics Calculate(int currentStep)
        {
            var cfg = _configService.GetConfig();
            var processes = _processService.GetAllProcesses();

            // ── Resource Usage ────────────────────────────────────────────────
            int usedCpu = _allocator.GetUsedCpu();
            int usedMemory = _allocator.GetUsedMemory();
            int usedIo = _allocator.GetUsedIo();

            // ── Process Counts ────────────────────────────────────────────────
            int completed = processes.Count(p => p.State == ProcessState.Terminated);
            int readyCount = processes.Count(p => p.State == ProcessState.Ready);
            int runCount = processes.Count(p => p.State == ProcessState.Running);
            int waitCount = processes.Count(p => p.State == ProcessState.Waiting);

            // ── Average Waiting Time ──────────────────────────────────────────
            // Calculated over all processes that have spent at least 1 step waiting
            var waitingProcesses = processes.Where(p => p.TotalWaitingSteps > 0).ToList();
            double avgWait = waitingProcesses.Any()
                ? waitingProcesses.Average(p => p.TotalWaitingSteps)
                : 0;

            _latest = new PerformanceMetrics
            {
                SimulationStep = currentStep,
                UsedCpuUnits = usedCpu,
                TotalCpuUnits = cfg.TotalCpuUnits,
                UsedMemoryMB = usedMemory,
                TotalMemoryMB = cfg.TotalMemoryMB,
                UsedIoUnits = usedIo,
                TotalIoUnits = cfg.TotalIoUnits,
                CompletedProcesses = completed,
                AverageWaitingTime = avgWait,
                ReadyQueueCount = readyCount,
                RunningCount = runCount,
                WaitingCount = waitCount
            };

            return _latest;
        }

        /// <inheritdoc/>
        public PerformanceMetrics GetLatest() => _latest;
    }
}