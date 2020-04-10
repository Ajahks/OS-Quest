using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowToggler : MonoBehaviour
{
    [SerializeField] GameObject window;

    public void toggleWindow()
    {
        window.SetActive(!window.activeSelf);
    }
}
