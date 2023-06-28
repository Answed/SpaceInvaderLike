using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextAnimation : MonoBehaviour
{
    [Range(0f, 1f)]
    [SerializeField] private float interpolateSpeed;

    private TextMeshProUGUI text;
    private bool fadeOut;
    private float interpolate;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();  
        fadeOut = true;
    }

    // Update is called once per frame
    void Update()
    {
        interpolate += interpolateSpeed * Time.deltaTime;
        if (fadeOut)
            text.color = new Color(text.color.r, text.color.g, text.color.b, Mathf.Lerp(1, 0, interpolate));
        else
            text.color = new Color(text.color.r, text.color.g, text.color.b, Mathf.Lerp(0, 1, interpolate));

        if (text.color.a >= 1)
        {
            fadeOut = true;
            interpolate = 0;
        }
        else if (text.color.a <= 0)
        {
            fadeOut = false;
            interpolate = 0;
        }
    }
}
