using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class RotationTest : MonoBehaviour
{
    Rigidbody2D rb = null;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddTorque(10.0f);
        rb.AddForce(new Vector2(10.0f, 0));
    }

    // Update is called once per frame
    void FixedUpdate()
    {

    }
}
