using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotator : MonoBehaviour
{
    [SerializeField] Transform centerPoint; // Rotate about this center
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(centerPoint) ;
        transform.Translate(Vector3.right * Time.deltaTime);
    }
}
