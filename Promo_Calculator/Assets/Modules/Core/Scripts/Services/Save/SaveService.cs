using System;
using System.Collections.Generic;
using System.IO;
using Modules.Core.Scripts.Services.Save.Data;
using Modules.Core.Scripts.Services.Save.Modules;
using UnityEngine;

namespace Modules.Core.Scripts.Services.Save
{
    public class SaveService : ISaveService
    {
        private const string FileName = "save.json";
        
        private readonly string _saveFilePath;
        private readonly Dictionary<string, ISaveModule> _saveModules = new();
        private ApplicationState _applicationState;
        
        public SaveService()
        {
            _saveFilePath = Path.Combine(Application.persistentDataPath, FileName);
        }
        
        public void RegisterModule(ISaveModule module)
        {
            if (!_saveModules.ContainsKey(module.Id))
            {
                _saveModules.Add(module.Id, module);
            }
        }

        public void Load()
        {
            if (!File.Exists(_saveFilePath))
            {
                _applicationState = new ApplicationState();
                return;
            }

            try
            {
                var json = File.ReadAllText(_saveFilePath);
                _applicationState = JsonUtility.FromJson<ApplicationState>(json);

                if (_applicationState == null)
                {
                    _applicationState = new ApplicationState();
                    return;
                }

                foreach (var moduleState in _applicationState.ModuleStates)
                {
                    if (_saveModules.TryGetValue(moduleState.Id, out var module))
                    {
                        module.FromJson(moduleState.JsonData ?? string.Empty);
                    }
                }
            }
            catch (Exception e)
            {
                Debug.LogError($"Failed to load save: {e.Message}");
                _applicationState = new ApplicationState();
            }
        }

        public void Save()
        {
            try
            {
                _applicationState.ModuleStates.Clear();

                foreach (var module in _saveModules.Values)
                {
                    var moduleState = new ModuleState
                    {
                        Id = module.Id,
                        JsonData = module.ToJson()
                    };
                    _applicationState.ModuleStates.Add(moduleState);
                }

                var json = JsonUtility.ToJson(_applicationState, true);
                File.WriteAllText(_saveFilePath, json);
            }
            catch (Exception e)
            {
                Debug.LogError($"Failed to save: {e.Message}");
            }
        }
    }
}