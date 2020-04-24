/**
 * Adapted from Arren's test script
 */
using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetMove : MonoBehaviourPun
{
    #region Tweakables
    [Tooltip("1.0 is 180 degrees; 0, is 0 degrees cone in front of you")]
    public float throwSpread = 1.0f;
    #endregion
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

    #region external references
    [SerializeField] GameObject trash;
    #endregion

    float leftVal, rightVal, upVal, downVal = 0.0f;

    public float speed = 3.0f;
    public Animator animator;

    #region Helper Variables
    private bool trashThrow = false;
    #endregion

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

        // Trash toss ( will be moved to the other script shortly
        if (Input.GetKeyDown(KeyCode.T))
        {
            trashThrow = true;
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

        if (trashThrow)
        {
            GameObject trashSpawned = Instantiate(trash, transform.position + transform.forward * 2f + Vector3.up*1.5f, Quaternion.identity);

            trashSpawned.transform.rotation = transform.rotation;
            trashSpawned.GetComponent<Rigidbody>().velocity = ((trashSpawned.transform.forward + (trashSpawned.transform.right * Random.Range(-throwSpread,throwSpread))).normalized * 40.0f);
            trashSpawned.GetComponent<Rigidbody>().AddRelativeTorque(new Vector3(0, 0, 100.0f));
            trashThrow = false;
        }
    }
    #endregion

}
