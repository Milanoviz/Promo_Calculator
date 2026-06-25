using System;
using System.Collections.Generic;

namespace Modules.Core.Scripts.Services.Save.Data
{
    [Serializable]
    public class ApplicationState
    {
        public List<ModuleState> ModuleStates =  new();
    }
}