using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBG : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if(transform.position.y <= -19.64f)
            Destroy(gameObject);
    }
}
