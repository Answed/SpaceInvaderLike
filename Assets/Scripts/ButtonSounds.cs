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

    private void OnMouseOver()
    {
        audioManager.Play("HoverOverButton");
    }

    public void PlayClickSound()
    {
        audioManager.Play("Click");
    }
}
