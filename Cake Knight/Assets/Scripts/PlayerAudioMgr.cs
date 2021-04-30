using UnityEngine;
using UnityEngine.Audio;
using System;


public class PlayerAudioMgr : MonoBehaviour
{

    public Sound[] sounds;
    public Sound[] hurtSounds;
    public Sound[] BGM;
    // Start is called before the first frame update
    void Awake()
    {
       foreach (Sound s in sounds) {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }

        foreach (Sound s in hurtSounds) {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
        foreach (Sound s in BGM) {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }


    }


    public void Play(string name) {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
            return;
        
        // Special delay for sword crash
        if (name == "SwordCrash") {
            s.source.PlayDelayed(0.5f);
        
        // Play other sounds normally
        } else {
            s.source.Play();
        }
    }

    public void Stop(string name) {

        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
            return;

        s.source.volume = 0;
        s.source.pitch = 0;
    }

    public void PlayDmg() { 
        Sound s = hurtSounds[UnityEngine.Random.Range(0, hurtSounds.Length)];
        s.source.Play();
    }

    public void PlayBGM(string name) {
        Sound s = Array.Find(BGM, music => music.name == name);
        if (s == null)
            return;
        
        s.source.Play();

    }

    public void StopBGM(string name) {

        Sound s = Array.Find(BGM, music => music.name == name);
        if (s == null)
            return;

        s.source.volume = 0;
        s.source.pitch = 0;
    }



}
