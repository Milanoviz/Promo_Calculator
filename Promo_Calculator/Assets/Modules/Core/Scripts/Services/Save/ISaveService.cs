using Modules.Core.Scripts.Services.Save.Modules;

namespace Modules.Core.Scripts.Services.Save
{
    public interface ISaveService
    {
        void RegisterModule(ISaveModule module);
        
        void Load();
        void Save();
    }
}