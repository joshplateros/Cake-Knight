using UnityEngine;
using UnityEngine.Audio;
using System;


public class AudioMgr : MonoBehaviour
{

    public Sound[] playerSounds;
    public Sound[] hurtSounds;
    public Sound[] BGM;
    public Sound[] Mobs;
    public Sound[] TrapsAndEnvironment;
    // Start is called before the first frame update
    void Awake()
    {
       foreach (Sound s in playerSounds) {
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
        foreach (Sound s in Mobs) {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
        foreach (Sound s in TrapsAndEnvironment) {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }





    }


    public void Play(string name) {
        Sound s = Array.Find(playerSounds, sound => sound.name == name);
        if (s == null)
            return;
        
        // Special delay for sword crash
        if (name == "SwordCrash") {
            s.source.PlayDelayed(0.9f);
        
        // Play other sounds normally
        } else {
            s.source.Play();
        }
    }

    public void Stop(string name) {

        Sound s = Array.Find(playerSounds, sound => sound.name == name);
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

    public void PlayMob(string name) {
        Sound s = Array.Find(Mobs, sound => sound.name == name);
        if (s == null)
            return;

        s.source.Play();
    }

    public void PlayTrap(string name) {
        Sound s = Array.Find(TrapsAndEnvironment, sound => sound.name == name);
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
    public void StopMob(string name) {

        Sound s = Array.Find(Mobs, sound => sound.name == name);
        if (s == null)
            return;

        s.source.volume = 0;
        s.source.pitch = 0;
    }
    public void StopTrap(string name) {

        Sound s = Array.Find(TrapsAndEnvironment, sound => sound.name == name);
        if (s == null)
            return;

        s.source.volume = 0;
        s.source.pitch = 0;
    }


}
