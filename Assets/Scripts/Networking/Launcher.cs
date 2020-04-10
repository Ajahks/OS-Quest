using Photon.Pun;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

//Will handle launching the user into game
public class Launcher : MonoBehaviour
{
    public bool isConnecting = false;
    // Private variables 
    string gameVersion = "1"; // The version of the game

    // Object References
    [SerializeField] GameObject connectPanel = null;
    [SerializeField] TextMeshProUGUI usernameText = null;
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
        if (connectPanel)
        {

            connectPanel.SetActive(false);
            connectText.SetActive(true);
        }

        if (PhotonNetwork.IsConnected)
        {
            changeNickName();
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

    // Change the nicknames
    public void changeNickName()
    {
        PhotonNetwork.NickName = usernameText.text;
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
