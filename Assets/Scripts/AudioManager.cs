using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    public Sound[] music;

    public static AudioManager instance;


    void Awake()
    {
        //AudioMixer mixer = Resources.Load("AudioMixer1") as AudioMixer;

        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach(Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.outputAudioMixerGroup = s.audioMixerGroup;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
        foreach (Sound s in music)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.outputAudioMixerGroup = s.audioMixerGroup;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    void Start()
    {
        //PlaySFX("Test Music");
        //PlayMusic("Test Music");
    }


    public void PlaySFX(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound " + name + " not found and could not be played!");
            return;
        }
        s.source.Play();
    }

    public void PlayMusic(string name)
    {
        Sound s = Array.Find(music, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Music " + name + " not found and could not be played!");
            return;
        }
        s.source.Play();
    }

    public void StopSFX(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound " + name + " not found and could not be stopped!");
            return;
        }
        s.source.Stop();
    }

    public void StopMusic(string name)
    {
        Sound s = Array.Find(music, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound " + name + " not found and could not be stopped!");
            return;
        }
        s.source.Stop();
    }
}
