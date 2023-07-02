using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSounds : MonoBehaviour
{
    private AudioManager audioManager;

    private void Start()
    {
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
    }

    public void OnButtonEnter()
    {
        audioManager.Play("HoverOverButton");
    }

    public void PlayClickSound()
    {
        audioManager.Play("Click");
    }
}
