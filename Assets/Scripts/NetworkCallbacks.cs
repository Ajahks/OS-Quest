using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Handles callbacks that are made from the network manager calls
public class NetworkCallbacks : MonoBehaviourPunCallbacks
{
    public bool isConnectedToMaster = false;
    public bool isInRoom = false;   //Whether or not we are in a room or not

    // Outside references
    [SerializeField] PlayerList playerList = null;
    [SerializeField] ChatPanel chat = null;

    public override void OnConnectedToMaster()
    {
        Debug.Log("We are now connected to the " + PhotonNetwork.CloudRegion + " server!");
        PhotonNetwork.AutomaticallySyncScene = true; // Makes it so whatever scene the master client has loaded is the scene all other clients will load

        //If there is no nickname, then set one
        if(PhotonNetwork.NickName == "")
        {
            PhotonNetwork.NickName = "Default"; // Set a default nickname for the player. In the future, we would be loading this nickname
        }
        isConnectedToMaster = true; 
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        base.OnJoinRoomFailed(returnCode, message);
        Debug.Log("Join room failed: " + message);
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        base.OnCreateRoomFailed(returnCode, message);
        Debug.Log("Create room failed: " + message);
    }

    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        Debug.Log("Successfuly joined room!");
        isInRoom = true;
        GetComponent<NetworkManager>().switchToGameView(); // Switch to the game view
        playerList.refreshPlayers();
        chat.connect();
    }

    public override void OnCreatedRoom()
    {
        base.OnCreatedRoom();
        Debug.Log("Successfuly created room!");
        GetComponent<NetworkManager>().switchToGameView(); // Switch to the game view
        playerList.refreshPlayers();
    }

    public override void OnLeftRoom()
    {
        base.OnLeftRoom();
        Debug.Log("Successfuly exited room!");
        isInRoom = false;
        chat.disconnect(); //Leave the chat

        GetComponent<NetworkManager>().switchToJoinView(); // Switch back to the join view
    }

    //When a new player enters the room we refresh the player list
    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        base.OnPlayerEnteredRoom(newPlayer);
        playerList.refreshPlayers();
    }
}
