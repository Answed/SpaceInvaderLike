using UnityEngine.Audio;
using System;
using UnityEngine;
using SaveLoadSystem;
using Unity.VisualScripting;

public class AudioManager : MonoBehaviour
{

    [SerializeField] private SoundClip[] soundClips;

    // Start is called before the first frame update
    void Awake()
    {
        foreach (SoundClip clip in soundClips)
        {
           ApplayValuesToClip(clip);
        }
        ApplySettings();
    }

    private void ApplySettings()
    {
        var settingsData = SaveLoadSystem.SaveSystemManager.LoadSettings();
        UpdateSoundVolume(settingsData.musicVolume, settingsData.effectsVolume);
    }

    private void ApplayValuesToClip(SoundClip clip)
    {
        clip.audioSource = gameObject.AddComponent<AudioSource>();
        clip.audioSource.clip = clip.soundClip;

        clip.audioSource.volume = clip.volume;
        clip.audioSource.pitch = clip.pitch;
        clip.audioSource.loop = clip.loop;
    }

    public void Play(string name)
    {
        SoundClip clip = Array.Find(soundClips, sound => sound.name == name);
        if (clip == null)
            return;
        clip.audioSource.Play();
    }

    public void UpdateSoundVolume(float musicVolume, float effectVolume)
    {
        foreach(SoundClip clip in soundClips)
        {
            if (clip.tag == "music")
            {
                clip.volume = musicVolume;
                clip.audioSource.volume = musicVolume;
            }
            else
            {
                clip.volume = effectVolume;
                clip.audioSource.volume = effectVolume;
            }
        }
    }
}
