using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(Rigidbody))]
public class GravityCustom : MonoBehaviour {
    // Gravity Scale editable on the inspector
    // providing a gravity scale per object

    public float gravityScale = 1.0f;
    public float fallAdd = 0f;// For falling faster

    // Global Gravity doesn't appear in the inspector. Modify it here in the code
    // (or via scripting) to define a different default gravity for all objects.

    public static float globalGravity = -9.81f;

    Rigidbody m_rb;

    void OnEnable()
    {
        m_rb = GetComponent<Rigidbody>();
        m_rb.useGravity = false;
    }

    void FixedUpdate()
    {
        Vector3 gravity = globalGravity * gravityScale * Vector3.up;
        m_rb.AddForce(gravity, ForceMode.Acceleration);

        if (fallAdd > 0f) {
            if(m_rb.velocity.y < -0.1f)
            {
                Vector3 fall = globalGravity * fallAdd * Vector3.up;
                m_rb.AddForce(fall, ForceMode.Acceleration);
            }
        }
    }
}