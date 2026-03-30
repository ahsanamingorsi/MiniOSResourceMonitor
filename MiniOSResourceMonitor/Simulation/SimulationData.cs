using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MiniOSResourceMonitor.Interfaces;
using MiniOSResourceMonitor.Models;
using MiniOSResourceMonitor.Services;
using System.Collections.Generic;

namespace MiniOSResourceMonitor.Simulation
{
    /// <summary>
    /// Central orchestrator that wires all services together.
    /// MainForm talks only to SimulationData — never directly to services.
    /// </summary>
    public class SimulationData
    {
        // ── Services (internal) ───────────────────────────────────────────────
        private readonly IConfigurationService _configService;
        private readonly IProcessService _processService;
        private readonly IResourceAllocator _allocator;
        private readonly ProcessStateManager _stateManager;
        private readonly IPerformanceService _perfCalculator;

        // ── Simulation State ──────────────────────────────────────────────────
        public int CurrentStep { get; private set; } = 0;
        public bool IsStarted { get; private set; } = false;
        public bool IsConfigLocked { get; private set; } = false;

        public SimulationData()
        {
            _configService = new SystemConfigService();
            _processService = new ProcessService();
            _allocator = new ResourceAllocator(_configService);
            _stateManager = new ProcessStateManager(_allocator);
            _perfCalculator = new PerformanceCalculator(
                                  _processService, _allocator, _configService);
        }

        // ── Configuration ─────────────────────────────────────────────────────

        /// <summary>Apply system config. Blocked once simulation has started.</summary>
        public bool ApplyConfig(SystemConfig config)
        {
            if (IsConfigLocked) return false;
            if (!_configService.ValidateConfig(config)) return false;
            _configService.SetConfig(config);
            return true;
        }

        public SystemConfig GetConfig() => _configService.GetConfig();

        // ── Process Management ────────────────────────────────────────────────

        public int AddProcess(OsProcess process)
            => _processService.AddProcess(process);

        public bool RemoveProcess(int processId)
            => _processService.RemoveProcess(processId);

        public bool UpdateProcess(OsProcess process)
            => _processService.UpdateProcess(process);

        public List<OsProcess> GetAllProcesses()
            => _processService.GetAllProcesses();

        public OsProcess? GetProcessById(int id)
            => _processService.GetProcessById(id);

        // ── Simulation Control ────────────────────────────────────────────────

        /// <summary>
        /// Locks the configuration and marks simulation as started.
        /// Must be called before NextStep().
        /// </summary>
        public void Start()
        {
            IsStarted = true;
            IsConfigLocked = true;
        }

        /// <summary>
        /// Advances simulation by one step.
        /// Triggers state transitions then recalculates metrics.
        /// </summary>
        public PerformanceMetrics NextStep()
        {
            if (!IsStarted) Start();

            CurrentStep++;
            var processes = _processService.GetAllProcesses();
            _stateManager.AdvanceStep(processes, CurrentStep);

            return _perfCalculator.Calculate(CurrentStep);
        }

        /// <summary>
        /// Resets entire simulation back to initial state.
        /// Unlocks configuration so it can be changed again.
        /// </summary>
        public void Reset()
        {
            _processService.Reset();
            _allocator.Reset();
            CurrentStep = 0;
            IsStarted = false;
            IsConfigLocked = false;
        }

        /// <summary>Returns the latest performance metrics without advancing.</summary>
        public PerformanceMetrics GetMetrics()
            => _perfCalculator.Calculate(CurrentStep);
    }
}