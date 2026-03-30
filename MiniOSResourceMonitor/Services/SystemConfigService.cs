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
    /// Manages the fixed system hardware configuration.
    /// Configuration is set once before simulation and remains immutable during it.
    /// </summary>
    public class SystemConfigService : IConfigurationService
    {
        private SystemConfig _config;

        public SystemConfigService()
        {
            // Default configuration on startup
            _config = new SystemConfig
            {
                TotalCpuUnits = 100,
                TotalMemoryMB = 1024,
                TotalIoUnits = 10
            };
        }

        /// <inheritdoc/>
        public SystemConfig GetConfig() => _config;

        /// <inheritdoc/>
        public void SetConfig(SystemConfig config)
        {
            if (ValidateConfig(config))
                _config = config;
        }

        /// <inheritdoc/>
        public bool ValidateConfig(SystemConfig config)
        {
            return config != null
                && config.TotalCpuUnits > 0
                && config.TotalMemoryMB > 0
                && config.TotalIoUnits > 0
                && config.TotalCpuUnits <= 1000
                && config.TotalMemoryMB <= 65536   // cap at 64 GB
                && config.TotalIoUnits <= 100;
        }
    }
}