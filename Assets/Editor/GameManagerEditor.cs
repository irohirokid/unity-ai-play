using System.Collections;
using System.Collections.Generic;
using Unity.EditorCoroutines.Editor;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(GameManager))]
public class GameManagerEditor : Editor
{
    GameManager app;
    bool autoPlaying = false;

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        app = (GameManager)target;

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
            Physics.autoSimulation = false;
            Physics.Simulate(Time.fixedDeltaTime);
            Physics.autoSimulation = true;
            app.Tick();
        }
    }
}
