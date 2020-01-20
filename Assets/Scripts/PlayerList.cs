using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerList : MonoBehaviour
{
    [SerializeField] Text playerListText = null;
    [SerializeField] float updateInterval = 5.0f;   // Time to update the player list

    // Private helper variables here
    float timer = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // We want to update the player list every so often
        if (timer < updateInterval)
        {
            timer += Time.deltaTime;
        }
        else
        {
            refreshPlayers();
            timer = 0.0f;
        }
    }

    //Refresh player list
    public void refreshPlayers()
    {
        string playerList = "";
        foreach (Photon.Realtime.Player player in PhotonNetwork.PlayerList)
        {
            playerList += player.NickName + "\n";
        }

        playerListText.text = playerList;
    }
}
