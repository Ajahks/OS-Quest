using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;
    float horizontal;
    float vertical;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        horizontal = 0;
        vertical = 0;
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = 0;
        vertical = 0;
        if (Input.GetKey("a")) horizontal -= 0.1f;
        if (Input.GetKey("d")) horizontal += 0.1f;
        if (Input.GetKey("w")) vertical += 0.1f;
        if (Input.GetKey("s")) vertical -= 0.1f;
    }

    private void FixedUpdate()
    {
        if(horizontal != 0 && vertical != 0)
        {
            float change = Mathf.Sqrt(Mathf.Pow(horizontal, 2) + Mathf.Pow(vertical, 2))/2;
            if(horizontal > 0 && vertical > 0)
            {
                rb.position = new Vector3(transform.position.x + change, transform.position.y + change, 0);
            }
            else if(horizontal > 0 && vertical < 0)
            {
                rb.position = new Vector3(transform.position.x + change, transform.position.y - change, 0);
            }
            else if(horizontal < 0 && vertical > 0)
            {
                rb.position = new Vector3(transform.position.x - change, transform.position.y + change, 0);
            }
            else
            {
                rb.position = new Vector3(transform.position.x - change, transform.position.y - change, 0);
            }
        }
        else
        {
            rb.position = new Vector3(transform.position.x + horizontal, transform.position.y + vertical, 0);
        }
    }
}
