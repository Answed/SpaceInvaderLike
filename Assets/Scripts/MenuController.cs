using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    public static void SwitchWindow(GameObject[] disableWindowObjects, GameObject[] enableWindowObjects)
    {
        DisableGameObjects(disableWindowObjects);
        EnableGameObjects(enableWindowObjects);
    }

    public static void DisableGameObjects(GameObject[] objects)
    {
        foreach (GameObject _object in objects) _object.SetActive(false);  //_object because in C# object can't be the name of a variable
    }

    public static void EnableGameObjects(GameObject[] objects)
    {
        foreach (GameObject _object in objects) _object.SetActive(true);
    }
}
