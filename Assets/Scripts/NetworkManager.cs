using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NetworkManager : MonoBehaviour
{

    // Other components of this game object - will be connected in the awake method
    NetworkCallbacks callbacks = null;

    // UI Elements
    [SerializeField] Text text = null;
    [SerializeField] InputField nickName = null;
    [SerializeField] Text nicknameDisplay = null;
    public GameObject joinPanel = null;
    public GameObject gamePanel = null;


    private void Awake()
    {
        callbacks = GetComponent<NetworkCallbacks>();
    }
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
        
    }

    // Joins a room by name
    public void joinServer(string name)
    {
        if (callbacks.isConnectedToMaster)
        {
             PhotonNetwork.JoinRoom(name);
        }
        else
        {
            Debug.Log("Cannot Join Server: Not Connected");
        }
    }

    // Creates a room by name
    public void createServer(string name)
    {
        if (callbacks.isConnectedToMaster)
        {
            PhotonNetwork.CreateRoom(name);
        }
        else
        {
            Debug.Log("Cannot Create Server: Not Connected");
        }
    }

    // Leaves the current room
    public void leaveServer()
    {
        if (callbacks.isInRoom)
        {
            PhotonNetwork.LeaveRoom();
        }
    }

    //Refresh player list
    public void refreshPlayers()
    {
        string playerList = "";
        Debug.Log(PhotonNetwork.PlayerList.Length);
        foreach (Photon.Realtime.Player player in PhotonNetwork.PlayerList)
        {
            playerList += player.NickName + "\n";
        }

        text.text = playerList;
    }

    public void changeNickName()
    {
        PhotonNetwork.NickName = nickName.text;
        nicknameDisplay.text = PhotonNetwork.NickName;
    }

    // Switches to the game view
    public void switchToGameView()
    {
        gamePanel.SetActive(true);
        joinPanel.SetActive(false);
    }

    // Switches back to the join view
    public void switchToJoinView()
    {
        joinPanel.SetActive(true);
        gamePanel.SetActive(false);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
