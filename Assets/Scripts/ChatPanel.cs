using ExitGames.Client.Photon;
using Photon.Chat;
using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChatPanel : MonoBehaviour, IChatClientListener
{

    [SerializeField] Text chatBox = null;
    [SerializeField] InputField input = null;
    [SerializeField] ScrollRect scroll = null;

    Queue<string> messages = null;

    ChatClient userChatClient;

    bool isConnected = false;

    void Awake()
    {
        userChatClient = new ChatClient(this);

        messages = new Queue<string>();
    }
    
    // Start is called before the first frame update
    void Start()
    {
        connect();
    }

    void OnEnable()
    {
        if (!isConnected)
        {
            connect();
        }
    }

    // Update is called once per frame
    void Update()
    {
        userChatClient.Service();   //Will constantly be updating the chat
    }

    public void connect()
    {
        userChatClient.Connect("0f62b849-2975-4595-b1da-eed177458940", "1.0", null);

        //Clear the chat
        chatBox.text = "";
    }

    public void disconnect()
    {
        // sendInfoMessage("has left the chat."); broken (need to pause?)

        userChatClient.Disconnect();

        input.interactable = false;
    }

    // Send the current message to the chat
    public void sendMessage()
    {
        if (isConnected)
        {
            string message = input.text;
            if (input.text != "") // Check if not empty
            {
                message = PhotonNetwork.NickName + ": " + message;

                // Send the message
                userChatClient.PublishMessage("global", message);

                // Clear the input
                input.text = "";

                // Select the input again
                input.ActivateInputField();
            }
            else
            {
                return;
            }
        }
    }

    public void sendInfoMessage(string m)
    {
        if (isConnected)
        {
            string message =  "*" + PhotonNetwork.NickName + " " + m;

            // Send the message
            userChatClient.PublishMessage("global", message);
        }
    }

    public void DebugReturn(DebugLevel level, string message)
    {
        Debug.Log(level + ": " + message);
    }

    public void OnDisconnected()
    {
        isConnected = false;
        userChatClient.SetOnlineStatus(ChatUserStatus.Offline);
    }

    public void OnConnected()
    {
        isConnected = true;
        userChatClient.Subscribe(new string[] { "global" });
        userChatClient.SetOnlineStatus(ChatUserStatus.Online);

        input.interactable = true;  // You can now use the chat box

        sendInfoMessage("has entered the chat.");
    }

    public void OnChatStateChange(ChatState state)
    {
        Debug.Log(state);
    }

    public void OnGetMessages(string channelName, string[] senders, object[] messages)
    {
        //Go through each message and add them to the chat
        for(int i = 0; i < senders.Length; i++)
        {
            string message = messages[i].ToString();
            message = message + "\n";
            chatBox.text = chatBox.text + message;
            scroll.verticalNormalizedPosition= 0;
        }


    }

    public void OnPrivateMessage(string sender, object message, string channelName)
    {
        throw new System.NotImplementedException();
    }

    public void OnSubscribed(string[] channels, bool[] results)
    {
          
    }

    public void OnUnsubscribed(string[] channels)
    {
        throw new System.NotImplementedException();
    }

    public void OnStatusUpdate(string user, int status, bool gotMessage, object message)
    {
        throw new System.NotImplementedException();
    }

    public void OnUserSubscribed(string channel, string user)
    {
        throw new System.NotImplementedException();
    }

    public void OnUserUnsubscribed(string channel, string user)
    {
        throw new System.NotImplementedException();
    }
}
