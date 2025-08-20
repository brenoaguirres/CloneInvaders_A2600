using UnityEditor;
using UnityEngine;

namespace AlienInvaders.Tools.EngineHelp
{
    [InitializeOnLoad]
    public static class CustomGameObjects
    {
        [MenuItem("Criminal/Tools/CGObject")]
        [MenuItem("Assets/Create/Criminal/Tools/CGObject %g")]
        public static void CreateCustomGameObjects()
        {
            GameObject go = new GameObject();
            GameObject graphics = new GameObject();
            GameObject colliders = new GameObject();
            GameObject logic = new GameObject();

            graphics.transform.parent = go.transform;
            colliders.transform.parent = go.transform;
            logic.transform.parent = go.transform;

            go.name = "CGObject";
            graphics.name = "Graphics";
            colliders.name = "Colliders";
            logic.name = "Logic";
        }
    }
}
