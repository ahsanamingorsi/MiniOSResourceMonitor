using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections.Generic;
using System.Linq;

public class ResourceManager
{
    private SystemConfig _config;
    private ResourceStatus _status;

    public ResourceManager(SystemConfig config, ResourceStatus status)
    {
        _config = config;
        _status = status;
    }

    public bool CanAllocate(ProcessModel process)
    {
        if (_status.UsedCPU + process.CpuRequired > _config.TotalCPU)
            return false;

        if (_status.UsedMemory + process.MemoryRequired > _config.TotalMemory)
            return false;

        if (_status.UsedIO + process.IoRequired > _config.TotalIO)
            return false;

        return true;
    }

    public void Allocate(ProcessModel process)
    {
        _status.UsedCPU += process.CpuRequired;
        _status.UsedMemory += process.MemoryRequired;
        _status.UsedIO += process.IoRequired;

        process.State = ProcessState.Running;
    }

    public void Release(ProcessModel process)
    {
        _status.UsedCPU -= process.CpuRequired;
        _status.UsedMemory -= process.MemoryRequired;
        _status.UsedIO -= process.IoRequired;

        if (_status.UsedCPU < 0) _status.UsedCPU = 0;
        if (_status.UsedMemory < 0) _status.UsedMemory = 0;
        if (_status.UsedIO < 0) _status.UsedIO = 0;

        process.State = ProcessState.Terminated;
    }
}
