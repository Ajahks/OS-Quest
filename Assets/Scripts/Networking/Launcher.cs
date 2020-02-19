using Photon.Pun;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Will handle launching the user into game
public class Launcher : MonoBehaviour
{
    public bool isConnecting = false;
    // Private variables 
    string gameVersion = "1"; // The version of the game

    // Object References
    [SerializeField] GameObject connectButton = null;
    [SerializeField] GameObject connectText = null;


    #region Unity Callbacks

    private void Awake()
    {
        // makes sure that we can call LoadLevel() on master client and all clients in the same room sync their level automatically
        PhotonNetwork.AutomaticallySyncScene = true;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    #endregion


    /// <summary>
    /// Start the connection process
    /// - If already connected, attempt to join random room
    /// - If not connected, connect this application instance to Photon Cloud Network
    /// </summary>
    public void Connect()
    {
        if (connectButton)
        {

            connectButton.SetActive(false);
            connectText.SetActive(true);
        }

        if (PhotonNetwork.IsConnected)
        {
            // If already connected then we join a random room
            PhotonNetwork.JoinRandomRoom();
        }
        else
        {
            // First connect to Photon Online Server
            isConnecting = PhotonNetwork.ConnectUsingSettings();
            PhotonNetwork.GameVersion = gameVersion;
        }
    }
}
