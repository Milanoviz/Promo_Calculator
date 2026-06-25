#if UNITY_EDITOR
using System.IO;
using UnityEditor;
using UnityEngine;

namespace Modules.Core.Editor
{
    public static class SaveTools
    {
        private const string FileName = "save.json";

        [MenuItem("Tools/Clear Save")]
        private static void ClearSave()
        {
            var savePath = Path.Combine(
                Application.persistentDataPath,
                FileName);

            if (!File.Exists(savePath))
            {
                Debug.Log("Save file not found.");
                return;
            }

            File.Delete(savePath);

            Debug.Log($"Save deleted: {savePath}");
        }
    }
}
#endif