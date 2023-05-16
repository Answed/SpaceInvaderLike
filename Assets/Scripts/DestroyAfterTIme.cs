using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterTIme : MonoBehaviour
{
    [SerializeField] private float timeBeforeDestroyed;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    IEnumerator DestroyAfterTime()
    {
        yield return new WaitForSeconds(timeBeforeDestroyed);
        Destroy(gameObject);
    }
}
