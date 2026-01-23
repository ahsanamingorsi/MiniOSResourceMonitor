using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections.Generic;
using System.Linq;

public class ProcessController
{
    private List<ProcessModel> _processes;
    private ResourceManager _resourceManager;

    public ProcessController(ResourceManager resourceManager)
    {
        _processes = new List<ProcessModel>();
        _resourceManager = resourceManager;
    }

    public void AddProcess(ProcessModel process)
    {
        process.State = ProcessState.New;
        _processes.Add(process);
    }

    public List<ProcessModel> GetAllProcesses()
    {
        return _processes;
    }

    public void MoveNewToReady()
    {
        foreach (var p in _processes.Where(x => x.State == ProcessState.New))
        {
            p.State = ProcessState.Ready;
        }
    }

    public void TryRunReadyProcesses()
    {
        foreach (var p in _processes.Where(x => x.State == ProcessState.Ready))
        {
            if (_resourceManager.CanAllocate(p))
            {
                _resourceManager.Allocate(p);
            }
            else
            {
                p.State = ProcessState.Waiting;
            }
        }
    }

    public void MoveWaitingToReady()
    {
        foreach (var p in _processes.Where(x => x.State == ProcessState.Waiting))
        {
            if (_resourceManager.CanAllocate(p))
            {
                p.State = ProcessState.Ready;
            }
        }
    }

    public void TerminateProcess(int processId)
    {
        var process = _processes.FirstOrDefault(p => p.ProcessId == processId);
        if (process == null) return;

        if (process.State == ProcessState.Running)
        {
            _resourceManager.Release(process);
        }
    }
}

