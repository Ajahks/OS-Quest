using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinoMovement : MonoBehaviour
{
    bool downHeld = false;
    bool jump = false;

    bool onFloor = false;
    bool jumpHold = false;

    public float jumpSpeed = 5.0f;
    float jumpTimer = 0f;

    Rigidbody rb = null;
    CapsuleCollider cc = null;
    Vector3 crouch;
    Vector3 stand;

    TimeManager timeManager;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cc = GetComponent<CapsuleCollider>();
        crouch.y = -0.5f;
        timeManager = GameObject.FindObjectOfType<TimeManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W)) && onFloor)
        {
            jump = true;
            jumpHold = true;
            jumpTimer = 0.6f;
        }
        if (Input.GetKey(KeyCode.Space))
        {
            jumpHold = true;
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            jumpHold = false;
        }
        downHeld = Input.GetKey(KeyCode.S) ? true : false;
    }

    private void FixedUpdate()
    {
        if (jumpHold && !jump && !onFloor && jumpTimer > 0f)
        {
            rb.AddForce(Vector3.up * jumpSpeed * 2.2f, ForceMode.Force);
            jumpTimer -= Time.deltaTime;
        }
        if (jump)
        {
            rb.AddForce(Vector3.up * jumpSpeed * 2.2f, ForceMode.Impulse);
            jump = false;
            onFloor = false;

            /*if (anim)
            {
                anim.SetBool("grounded", onFloor);
                anim.ResetTrigger("ground");
                anim.SetTrigger("jump");
            }*/
        }

        if (downHeld && onFloor)
        {
            cc.height = 1;
            cc.center = crouch;
            // Duck
            /*if (anim)
            {
                anime.SetBool("duck", onFloor);
            }*/
        }
        else if (!downHeld && onFloor)
        {
            cc.height = 2;
            cc.center = stand;
            /*if(anim)
            {
                anim.SetBool("stand", onFloor);
            }*/
        }
        else if (downHeld && !onFloor)
        {
            // Fast fall
            rb.AddForce(Vector3.down * 6.0f, ForceMode.Impulse);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Floor" && !onFloor)
        {
            onFloor = true;
        }
        if(collision.gameObject.tag == "End")
        {
            print("You lost");
            timeManager.endTime();
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            onFloor = false;
            rb.velocity = new Vector3(0, rb.velocity.y, 0);
            rb.angularVelocity = new Vector3(0, rb.angularVelocity.y, 0);
        }
        else
        {
            rb.velocity = new Vector3(0, 0, 0);
            rb.angularVelocity = new Vector3(0, 0, 0);
        }
    }
}
