using System;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using System.Linq;


public class SoundAnimator : MonoBehaviour
{
	public AudioClip source;
	public AnimationClip dest;
    public float sampleRate = 30;

    [Serializable]
    public class RecordSlot
    {
        public enum PropertiesSet
        {
            Material, ParticleSystem, BlendShape, Transform, Parameter
        };
        public string name;
        public string relativePath;
        public string componentType;
        public float rangeMin = 0, rangeMax = 1;

        public RecordSlot() { }
    }
    public List<RecordSlot> recordSlots;
	
    public void GenerateAnimations(){

        Debug.Log("Generating keyframes...");

        AnimationCurve generated_keyframes = new AnimationCurve();
        AudioToParam.AudioToCurve(ref source, ref generated_keyframes, sampleRate);

        Debug.Log("Saving to animation clip...");

        foreach(RecordSlot r in recordSlots){
            Type component = System.Type.GetType(r.componentType);

            dest.SetCurve( r.relativePath, component, r.name, generated_keyframes );
        }
        
        Debug.Log("Done.");
    }
}
