using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public AudioSource[] sources;

    public void PlaySound(string name) //Starts playing the sound
    {
        AudioSource source = Array.Find(sources, sound => sound.clip.name == name);
        
        if(source == null)
        {
            Debug.LogWarning("Could not find sound with name: " + name);
            return;
        }
        else
        {
            source.Play();
        }
    }

    public void StopSound(string name) //Stops playing the sound
    {
        AudioSource source = Array.Find(sources, sound => sound.clip.name == name);

        if(source == null)
        {
            Debug.LogWarning("Could not find sound with name: " + name);
            return;
        }
        else
        {
            source.Stop();
        }
    }
}
