using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniOSResourceMonitor.Models
{
    /// <summary>
    /// Represents a simulated OS process with its resource requirements and lifecycle state.
    /// </summary>
    public class OsProcess
    {
        // ── Identity ──────────────────────────────────────────────────────────

        /// <summary>Unique auto-assigned Process ID.</summary>
        public int ProcessId { get; set; }

        /// <summary>Human-readable name for display (e.g., "Process_1").</summary>
        public string Name { get; set; } = string.Empty;

        // ── Resource Requirements ─────────────────────────────────────────────

        /// <summary>CPU units this process needs while Running (e.g., 20 = 20 units).</summary>
        public int CpuRequirement { get; set; }

        /// <summary>Memory in MB this process needs from New → Terminated.</summary>
        public int MemoryRequirementMB { get; set; }

        /// <summary>I/O units needed when transitioning to Waiting state.</summary>
        public int IoRequirement { get; set; }

        // ── Lifecycle ─────────────────────────────────────────────────────────

        /// <summary>Current state in the OS process lifecycle.</summary>
        public ProcessState State { get; set; } = ProcessState.New;

        /// <summary>How many simulation steps this process has been in Waiting state.</summary>
        public int WaitingSteps { get; set; } = 0;

        /// <summary>
        /// Steps remaining before process completes while Running.
        /// Decrements by 1 each step the process is in Running state.
        /// </summary>
        public int RemainingBurstTime { get; set; } = 3;

        /// <summary>
        /// Steps remaining in I/O wait before returning to Ready.
        /// Set when process enters Waiting state.
        /// </summary>
        public int IoWaitStepsRemaining { get; set; } = 0;

        /// <summary>Simulation step number when this process entered Running state.</summary>
        public int StepEnteredRunning { get; set; } = -1;

        /// <summary>Simulation step number when process was first created/added.</summary>
        public int StepCreated { get; set; } = 0;

        /// <summary>Total steps spent waiting (accumulated across all Waiting phases).</summary>
        public int TotalWaitingSteps { get; set; } = 0;

        /// <summary>True if this process has already triggered its I/O phase.</summary>
        public bool HasDoneIo { get; set; } = false;

        // ── Computed Display ──────────────────────────────────────────────────

        /// <summary>Returns a display-friendly string for the current state.</summary>
        public string StateDisplay => State.ToString();
    }

    /// <summary>
    /// Enumeration of valid OS process states (strict OS theory lifecycle).
    /// </summary>
    public enum ProcessState
    {
        New,        // Just created, awaiting memory check
        Ready,      // In queue, waiting for CPU
        Running,    // Currently executing on CPU
        Waiting,    // Blocked on I/O
        Terminated  // Finished execution, resources released
    }
}