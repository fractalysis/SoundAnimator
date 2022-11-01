using System;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using System.Linq;


public class SoundAnimator : MonoBehaviour
{
	public AudioClip s;
	public AnimationClip dest;

    public enum PropertyType
    {
        Float, Range
    }
    [Serializable]
    public class RecordSlot
    {
        public enum PropertiesSet
        {
            Material, ParticleSystem, BlendShape, Transform, Parameter
        };
        public PropertyType type;
        public PropertiesSet typeSet;
        public string name;
        public float rangeMin, rangeMax;

        public RecordSlot() { }
        public RecordSlot(RecordSlot slot)
        {
            type = slot.type;
            typeSet = slot.typeSet;
            name = slot.name;
            rangeMin = slot.rangeMin;
            rangeMax = slot.rangeMax;
        }
    }
    public List<RecordSlot> recordSlots;
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
