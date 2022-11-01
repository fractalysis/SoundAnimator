using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(SoundAnimator))]
public class SoundAnimatorEditor : Editor
{
    GameObject targetGO;

    public override void OnInspectorGUI(){
        DrawDefaultInspector();

        if(GUILayout.Button("Generate"))
        {
            
        }
    }
}
