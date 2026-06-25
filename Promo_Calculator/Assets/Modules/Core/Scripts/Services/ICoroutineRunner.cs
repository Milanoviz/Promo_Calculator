using System.Collections;
using UnityEngine;

namespace Modules.Core.Scripts.Services
{
    public interface ICoroutineRunner
    {
        Coroutine StartCoroutine(IEnumerator coroutine);
    }
}