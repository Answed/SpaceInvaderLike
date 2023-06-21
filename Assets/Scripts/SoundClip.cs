using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class SoundClip
{
    public string name;

    public string tag;

    public AudioClip soundClip;

    [Range(0f, 1f)]
    public float volume;
    [Range(0f, 1f)]
    public float pitch;

    public bool loop;

    [HideInInspector]
    public AudioSource audioSource;
}
