/**
 * Adapted from Arren's test script
 */
using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetMove : MonoBehaviourPun
{
    #region inputVars

    bool rightHeld = false;
    bool leftHeld = false;
    bool upHeld = false;
    bool downHeld = false;
    float dashTime = 0;
    float dashCD = 0;

    #endregion

    #region internal references
    Rigidbody rb = null;
    #endregion

    float leftVal, rightVal, upVal, downVal = 0.0f;

    public float speed = 3.0f;
    public Animator animator;

    #region Unity Callbacks
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        if (photonView.IsMine == false && PhotonNetwork.IsConnected == true)
        {
            return;
        }

        rightHeld = Input.GetKey(KeyCode.D) ? true : false;
        leftHeld = Input.GetKey(KeyCode.A) ? true : false;
        upHeld = Input.GetKey(KeyCode.W) ? true : false;
        downHeld = Input.GetKey(KeyCode.S) ? true : false;
        if (Input.GetKeyDown(KeyCode.LeftShift) && dashCD <= 0)
        {
            dashTime = .5f;
        }
    }

    private void FixedUpdate()
    {
        leftVal = leftHeld ? 1.0f : 0.0f;
        rightVal = rightHeld ? 1.0f : 0.0f;
        upVal = upHeld ? 1.0f : 0.0f;
        downVal = downHeld ? 1.0f : 0.0f;

        float zVal = upVal - downVal;
        float xVal = rightVal - leftVal;

        Vector3 moveDir = new Vector3(xVal, 0f, zVal).normalized * speed;

        // Rotation
        if (moveDir != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(moveDir, Vector3.up);
        }

        if (dashTime == .5f)
        {
            dashCD = 2.0f;
        }
        // Dash
        if (dashTime > 0)
        {
            moveDir *= 3f;
        }
        // Update movement
        rb.velocity = moveDir;

        dashCD -= Time.deltaTime;

        if (animator)
        {
            animator.SetFloat("speed", rb.velocity.magnitude);
        }
    }
    #endregion

}
