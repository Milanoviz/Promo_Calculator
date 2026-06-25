using System;
using System.Collections;
using UnityEngine.SceneManagement;

namespace Modules.Core.Scripts.Services.Scene
{
    public class SceneService : ISceneService
    {
        private readonly ICoroutineRunner _coroutineRunner;

        public SceneService(ICoroutineRunner coroutineRunner)
        {
            _coroutineRunner = coroutineRunner;
        }

        public void LoadScene(string sceneName, Action onLoaded = null)
        {
            _coroutineRunner.StartCoroutine(LoadSceneCoroutine(sceneName, onLoaded));
        }
        
        private IEnumerator LoadSceneCoroutine(string sceneName, Action onLoaded = null)
        {
            if (SceneManager.GetActiveScene().name == sceneName)
            {
                onLoaded?.Invoke();
                yield break;
            }
      
            var sceneAsyncOperation = SceneManager.LoadSceneAsync(sceneName);
            while (sceneAsyncOperation is { isDone: false })
            {
                yield return null;
            }
            
            onLoaded?.Invoke();
        }
    }
}