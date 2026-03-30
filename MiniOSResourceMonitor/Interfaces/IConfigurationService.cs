using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MiniOSResourceMonitor.Models;


namespace MiniOSResourceMonitor.Interfaces
{
    /// <summary>
    /// Contract for managing the system hardware configuration.
    /// </summary>
    public interface IConfigurationService
    {
        /// <summary>Returns the current system configuration.</summary>
        SystemConfig GetConfig();

        /// <summary>Applies a new configuration. Only valid before simulation starts.</summary>
        void SetConfig(SystemConfig config);

        /// <summary>Validates that the config values are within acceptable ranges.</summary>
        bool ValidateConfig(SystemConfig config);
    }
}