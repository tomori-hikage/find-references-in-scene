using UnityEditor;
using System;
using System.Reflection;

namespace SIN.Editor
{
    public class FindReferencesInScene
    {
        [MenuItem("CONTEXT/Component/Find References In Scene")]
        private static void _FindReferencesInScene(MenuCommand command)
        {
            SetSearchFilter(string.Format("ref:{0}:", command.context.GetInstanceID()));
        }

        private static void SetSearchFilter(
            string searchString,
            SearchableEditorWindow.SearchMode searchMode = SearchableEditorWindow.SearchMode.All,
            bool setAll = false)
        {
            var sceneHierarchyWindowType = Type.GetType("UnityEditor.SceneHierarchyWindow,UnityEditor");
            var window = EditorWindow.GetWindow(sceneHierarchyWindowType);
            var setSearchMethodInfo = typeof(SearchableEditorWindow).GetMethod("SetSearchFilter", BindingFlags.NonPublic | BindingFlags.Instance);
            var parameters = new object[] { searchString, searchMode, setAll };
            setSearchMethodInfo.Invoke(window, parameters);
        }
    }
}