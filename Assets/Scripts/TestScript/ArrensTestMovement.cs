using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrensTestMovement : MonoBehaviourPun
{
    #region inputVars

    bool rightHeld = false;
    bool leftHeld = false;
    bool upHeld = false;
    bool downHeld = false;

    #endregion

    #region internal references
    Rigidbody rb = null;
    #endregion

    float leftVal, rightVal, upVal, downVal = 0.0f;

    public float speed = 3.0f;

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

        if (Input.GetKey(KeyCode.D))
        {
            rightHeld = true;
        }
        else
        {
            rightHeld = false;
        }
        if (Input.GetKey(KeyCode.A))
        {
            leftHeld = true;
        }
        else
        {
            leftHeld = false;
        }
        if (Input.GetKey(KeyCode.W))
        {
            upHeld = true;
        }
        else
        {
            upHeld = false;
        }
        if (Input.GetKey(KeyCode.S))
        {
            downHeld = true;
        }
        else
        {
            downHeld = false;
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

        rb.velocity = new Vector3(xVal, 0, zVal) * speed;
    }
    #endregion

}
