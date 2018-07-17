using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(Door))]
public class DoorEditor : Editor
{
    /*
    MonoScript script;

    void OnEnable()
    {
        script = MonoScript.FromMonoBehaviour((Door)target);
    }
    */
    void OnSceneGUI()
    {
        Door dTarget = target as Door;
        
        Vector3 triggerPosition = dTarget.triggerPosition;
        float triggerRadius = dTarget.triggerRadius;

        if (dTarget.triggerOffset.sqrMagnitude != 0)
        {
            dTarget.triggerOffset = Handles.PositionHandle(triggerPosition, Quaternion.identity) - dTarget.transform.position;
            triggerPosition = dTarget.triggerPosition;
        }

        Handles.color = Color.blue;
        Handles.DrawCapFunction drawCap = Handles.SphereCap;

        Vector3 up = triggerPosition + Vector3.up * triggerRadius;
        triggerRadius =   (Handles.Slider(up,    Vector3.up,    GetHandleSize(up)    * 0.125f, drawCap, 1) - triggerPosition).y;

        Vector3 down = triggerPosition + Vector3.down * triggerRadius;
        triggerRadius =  -(Handles.Slider(down,  Vector3.down,  GetHandleSize(down)  * 0.125f, drawCap, 1) - triggerPosition).y;

        Vector3 right = triggerPosition + Vector3.right * triggerRadius;
        triggerRadius =   (Handles.Slider(right, Vector3.right, GetHandleSize(right) * 0.125f, drawCap, 1) - triggerPosition).x;

        Vector3 left = triggerPosition + Vector3.left * triggerRadius;
        triggerRadius =  -(Handles.Slider(left,  Vector3.left,  GetHandleSize(left)  * 0.125f, drawCap, 1) - triggerPosition).x;

        dTarget.triggerRadius = Mathf.Clamp(triggerRadius, 0, float.MaxValue);
        Handles.DrawWireDisc(triggerPosition, Vector3.back, triggerRadius);

        if (GUI.changed)
        {
            EditorUtility.SetDirty(target);
        }
    }
    
    float GetHandleSize(Vector3 position)
    {
        return HandleUtility.GetHandleSize(position);
    }
}
