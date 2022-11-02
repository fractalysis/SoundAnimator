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

        SoundAnimator base_script = (SoundAnimator) target;
        if(GUILayout.Button("Generate")){
            base_script.GenerateAnimations();
        }
    }
}
