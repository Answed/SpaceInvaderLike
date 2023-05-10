using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    public void SwitchWindow(GameObject[] disableWindowObjects, GameObject[] enableWindowObjects)
    {
        DisableGameObjects(disableWindowObjects);
        EnableGameObjects(enableWindowObjects);
    }

    public void DisableGameObjects(GameObject[] objects)
    {
        foreach (GameObject _object in objects) _object.SetActive(false);  //_object because in C# object can't be the name of a variable
    }

    public void EnableGameObjects(GameObject[] objects)
    {
        foreach (GameObject _object in objects) _object.SetActive(true);
    }
}
