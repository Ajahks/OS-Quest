using System.Collections;
using System.Collections.Generic;
using UnityEngine;



// This script will always look at the camera
public class BillboardEffect : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        transform.rotation = Camera.main.transform.rotation;
    }
}
