/**
 * by Matthew Lawrence
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseControl : MonoBehaviour
{
    public bool xAxis = true;
    public bool yAxis = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 v3 = Input.mousePosition;
        v3 = Camera.main.ScreenToWorldPoint(v3);
        v3.z = transform.position.z;

        if (!yAxis)
            v3 = Vector3.Scale(v3, new Vector3(1f, 0f, 1f));

        transform.position = v3;
    }
}
