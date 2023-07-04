using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGGenerator : MonoBehaviour
{
    [SerializeField] private GameObject[] bgPresets;

    // Start is called before the first frame update
    void Start()
    {
        FirstGeneration();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FirstGeneration()
    {
        var yCoordinate = 19f;
        for(int i = 0; i < 5;  i++)
        {
            Instantiate(RandomeBG(), new Vector3(0, yCoordinate, 0), transform.rotation);
            yCoordinate -= 12.82f;
        }
    }

    private GameObject RandomeBG()
    {
        var randomBG = Random.Range(0, bgPresets.Length);
        return bgPresets[randomBG];
    }
}
