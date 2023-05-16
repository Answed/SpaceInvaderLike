using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterTime : MonoBehaviour
{
    [SerializeField] private float timeBeforeDestroyed;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DestroyObjectAfterTime());
    }
    IEnumerator DestroyObjectAfterTime()
    {
        yield return new WaitForSeconds(timeBeforeDestroyed);
        Destroy(gameObject);
    }
}
