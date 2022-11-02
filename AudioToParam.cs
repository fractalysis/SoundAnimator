using System;
using UnityEngine;
using UnityEngine.Assertions;

public static class AudioToParam
{
    public static void AudioToCurve(ref AudioClip audio, ref AnimationCurve curve, float sampleRate){
        
        float[] raw = new float[audio.samples * audio.channels];
        audio.GetData(raw, 0);


        // Take the left channel

        float[] samples_mono = new float[audio.samples];
        for(int i=0; i<audio.samples; i++){
            samples_mono[i] = raw[i*audio.channels];
            //Assert.IsTrue(-0.01 <= samples_mono[i] && samples_mono[i] <= 1.01, "Audio sample was " + samples_mono[i]);
        }


        // Get one-sample derivatives

        float[] sample_derivatives = new float[audio.samples - 1];
        for(int i=0; i<sample_derivatives.Length; i++){
            // f(x+h)-f(x) / h, where h is time between samples i.e. 1/frequency
            sample_derivatives[i] = (samples_mono[i+1] - samples_mono[i]) * audio.frequency;
        }


        // Resample linearly to curve

        int num_keyframes = (int) Math.Ceiling( sampleRate * audio.length );

        curve.AddKey(new Keyframe( 0, samples_mono[0], 0, sample_derivatives[0] ));

        for(int i=1; i < (num_keyframes-1); i++){

            float time = i / sampleRate;
            float audio_index = time * audio.frequency;
            float val = LerpResample( ref samples_mono, audio_index );
            float deriv = LerpResample( ref sample_derivatives, audio_index );

            curve.AddKey(new Keyframe( time, val, deriv, deriv ));
        }


    }

    private static float LerpResample(ref float[] arr, float index){
        float t = index - (float) Math.Floor(index);
        return arr[ (int) Math.Floor(index) ] * (1-t) + arr[ (int) Math.Ceiling(index) ] * t;
    }
}