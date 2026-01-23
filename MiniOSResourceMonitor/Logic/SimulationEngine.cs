using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Linq;

public class SimulationEngine
{
    private ProcessController _controller;
    public int CurrentTime { get; private set; }

    public SimulationEngine(ProcessController controller)
    {
        _controller = controller;
        CurrentTime = 0;
    }

    public void Step()
    {
        CurrentTime++;

        UpdateTimes();
        _controller.MoveNewToReady();
        _controller.TryRunReadyProcesses();
        _controller.MoveWaitingToReady();
    }

    private void UpdateTimes()
    {
        foreach (var p in _controller.GetAllProcesses())
        {
            if (p.State == ProcessState.Ready || p.State == ProcessState.Waiting)
            {
                p.WaitingTime++;
            }

            if (p.State != ProcessState.Terminated)
            {
                p.TurnaroundTime++;
            }
        }
    }
}
