using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiniOSResourceMonitor.Models;
using System.Collections.Generic;

namespace MiniOSResourceMonitor.Interfaces
{
    /// <summary>
    /// Contract for creating, retrieving, editing, and removing processes.
    /// </summary>
    public interface IProcessService
    {
        /// <summary>Adds a new process to the simulation. Returns assigned Process ID.</summary>
        int AddProcess(OsProcess process);

        /// <summary>Removes a process by ID. Only allowed if not currently Running.</summary>
        bool RemoveProcess(int processId);

        /// <summary>Updates editable fields of a process (before it has started).</summary>
        bool UpdateProcess(OsProcess updated);

        /// <summary>Returns a process by its ID, or null if not found.</summary>
        OsProcess? GetProcessById(int processId);

        /// <summary>Returns all processes currently in the simulation.</summary>
        List<OsProcess> GetAllProcesses();

        /// <summary>Returns all processes in a specific state.</summary>
        List<OsProcess> GetProcessesByState(ProcessState state);

        /// <summary>Resets all processes — clears the list entirely.</summary>
        void Reset();
    }
}