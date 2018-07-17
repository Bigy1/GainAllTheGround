using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(Parallax))]
public class ParallaxEditor : Editor
{
    MonoScript script;

    void OnEnable()
    {
        script = MonoScript.FromMonoBehaviour((Parallax)target);
    }

    void OnSceneGUI()
    {
        Parallax pTarget = target as Parallax;

        Vector3 position = (Vector2)pTarget.transform.position;
        Vector3 offset = Vector3.forward * pTarget.maxDistance;

        Handles.color = Color.blue;
        Handles.DrawLine(position, position + offset);
        pTarget.maxDistance = Handles.Slider(position + offset, Vector3.forward, 2, Handles.SphereCap, 1).z;

        if (GUI.changed)
        {
            EditorUtility.SetDirty(target);
        }
    }
}
