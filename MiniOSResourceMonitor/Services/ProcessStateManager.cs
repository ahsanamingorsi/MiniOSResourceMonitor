using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MiniOSResourceMonitor.Interfaces;
using MiniOSResourceMonitor.Models;
using System.Collections.Generic;

namespace MiniOSResourceMonitor.Services
{
    /// <summary>
    /// Enforces strict OS process state transition rules.
    /// Called once per simulation step to advance all processes.
    ///
    /// Transition rules (no randomness):
    ///   New       → Ready      : if memory is available
    ///   Ready     → Running    : if CPU is available
    ///   Running   → Waiting    : if process has IoRequirement > 0 and hasn't done I/O yet
    ///   Running   → Terminated : when RemainingBurstTime reaches 0
    ///   Waiting   → Ready      : when IoWaitStepsRemaining reaches 0
    /// </summary>
    public class ProcessStateManager
    {
        private readonly IResourceAllocator _allocator;

        // Fixed number of steps a process spends in Waiting (I/O phase)
        private const int IO_WAIT_DURATION = 2;

        public ProcessStateManager(IResourceAllocator allocator)
        {
            _allocator = allocator;
        }

        /// <summary>
        /// Advances every process by one simulation step.
        /// Order matters: Waiting → Ready before Ready → Running.
        /// </summary>
        public void AdvanceStep(List<OsProcess> processes, int currentStep)
        {
            // ── Phase 1: Tick Running processes ──────────────────────────────
            // Decrement burst time; check for I/O trigger or completion.
            foreach (var p in processes)
            {
                if (p.State != ProcessState.Running) continue;

                p.RemainingBurstTime--;

                // Trigger I/O halfway through burst (if process has I/O needs)
                if (!p.HasDoneIo && p.IoRequirement > 0 && p.RemainingBurstTime == 1)
                {
                    // Running → Waiting
                    if (_allocator.IsIoAvailable(p))
                    {
                        _allocator.ReleaseCpu(p);          // CPU freed during I/O
                        _allocator.AllocateIo(p);          // I/O device seized
                        p.State = ProcessState.Waiting;
                        p.IoWaitStepsRemaining = IO_WAIT_DURATION;
                        p.HasDoneIo = true;
                        continue;
                    }
                    // If I/O not available, process keeps running until it is
                }

                // Running → Terminated
                if (p.RemainingBurstTime <= 0)
                {
                    _allocator.ReleaseCpu(p);
                    _allocator.ReleaseMemory(p);
                    p.State = ProcessState.Terminated;
                }
            }

            // ── Phase 2: Tick Waiting processes ──────────────────────────────
            // Count down I/O wait; transition back to Ready when done.
            foreach (var p in processes)
            {
                if (p.State != ProcessState.Waiting) continue;

                p.IoWaitStepsRemaining--;
                p.WaitingSteps++;
                p.TotalWaitingSteps++;

                if (p.IoWaitStepsRemaining <= 0)
                {
                    // Waiting → Ready
                    _allocator.ReleaseIo(p);
                    p.State = ProcessState.Ready;
                }
            }

            // ── Phase 3: New → Ready ──────────────────────────────────────────
            // Admit new processes if memory is available.
            foreach (var p in processes)
            {
                if (p.State != ProcessState.New) continue;

                if (_allocator.IsMemoryAvailable(p))
                {
                    _allocator.AllocateMemory(p);
                    p.State = ProcessState.Ready;
                    p.StepCreated = currentStep;
                }
                // If memory not available, process stays in New state
            }

            // ── Phase 4: Ready → Running ──────────────────────────────────────
            // Schedule ready processes onto available CPU (FCFS order).
            foreach (var p in processes)
            {
                if (p.State != ProcessState.Ready) continue;

                if (_allocator.IsCpuAvailable(p))
                {
                    _allocator.AllocateCpu(p);
                    p.State = ProcessState.Running;
                    p.StepEnteredRunning = currentStep;
                }
                // If CPU not available, process stays in Ready queue
            }

            // ── Phase 5: Accumulate waiting time for Ready processes ──────────
            foreach (var p in processes)
            {
                if (p.State == ProcessState.Ready)
                    p.TotalWaitingSteps++;
            }
        }
    }
}