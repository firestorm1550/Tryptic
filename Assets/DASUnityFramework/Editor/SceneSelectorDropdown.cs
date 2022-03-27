using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;

namespace DASUnityFramework.Editor
{
    public class SceneSelectorDropdown
    {
        private static bool save, cancelSceneChange;
        
        public static void LoadScene(string scenePath)
        {
            if (SceneManager.GetActiveScene().isDirty)
                AskToSave();

            if (cancelSceneChange) return;
            if (save) EditorSceneManager.SaveOpenScenes();

            EditorSceneManager.OpenScene(scenePath);
        }

        public static void AskToSave()
        {
            int result = EditorUtility.DisplayDialogComplex("Unsaved Scene Changes!",
                "You have unsaved changes in the current scene. Would you like to save them?",
                "Yes!", "No, delete them", "Cancel");

            save = result == 0;
            cancelSceneChange = result == 2;
        }
        
        // Usage Example:
        
        // [MenuItem("Scenes/Main Menu")]
        // static void LoadMainMenu() => LoadScene("Assets/Scenes/MainMenu.unity");
    }
}