using System;

namespace Modules.Core.Scripts.Services.Scene
{
    public interface ISceneService
    {
        void LoadScene(string sceneName, Action onLoaded = null);
    }
}