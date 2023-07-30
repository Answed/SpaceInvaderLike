using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonFunctions : MonoBehaviour
{
    private AudioManager audioManager;
    private Image background;


    private void Start()
    {
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        background = GetComponent<Image>();
        background.enabled = false;
    }

    public void OnButtonEnter()
    {
        audioManager.Play("HoverOverButton");
        background.enabled = true;
    }

    public void OnButtonExit()
    {
        background.enabled = false;
    }


}
