using System.Collections;
using System.Collections.Generic;
using Unity.EditorCoroutines.Editor;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Application))]
public class ApplicationEditor : Editor
{
    Application app;
    bool autoPlaying = false;

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        app = (Application)target;

        if (GUILayout.Button("Auto Play"))
        {
            autoPlaying = true;

            app.Init();

            foreach (IIntelligent i in app.Intelligents)
            {
                EditorCoroutineUtility.StartCoroutineOwnerless(i.Behaviour());
            }
            EditorCoroutineUtility.StartCoroutineOwnerless(Ticker());
        }

        if (GUILayout.Button("Stop"))
        {
            autoPlaying = false;
            app.Reset();
        }

        if (GUILayout.Button("Reset Golds"))
        {
            World.ResetGold();
            app.PlaceGold();
        }
    }

    IEnumerator Ticker()
    {
        while (autoPlaying)
        {
            yield return null;
            app.Tick();
        }
    }
}
