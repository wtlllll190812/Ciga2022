using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AppIcon : MonoBehaviour
{
    public GameObject app;

    public void Onclick()
    {
        app.SetActive(!app.activeSelf);
    }
}
