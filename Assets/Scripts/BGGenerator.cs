using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.UIElements.UxmlAttributeDescription;

public class BGGenerator : MonoBehaviour
{
    [SerializeField] private GameObject[] bgPresets;

    private bool generationComplete;

    // Start is called before the first frame update
    void Start()
    {
        generationComplete = false;
        FirstGeneration();
    }

    // Update is called once per frame
    void Update()
    {
        var bgCounter = GameObject.FindGameObjectsWithTag("BG");
        if (bgCounter.Length < 3 && generationComplete)
        {
            Instantiate(RandomeBG(), new Vector3(0, 18.9f, 0), transform.rotation);
        }
    }

    private void FirstGeneration()
    {
        var yCoordinate = 18.9f;
        for(int i = 0; i < 5;  i++)
        {
            Instantiate(RandomeBG(), new Vector3(0, yCoordinate, 0), transform.rotation);
            yCoordinate -= 12.80374f;
        }
        generationComplete = true;
    }

    private GameObject RandomeBG()
    {
        var randomBG = Random.Range(0, bgPresets.Length);
        return bgPresets[randomBG];
    }
}
