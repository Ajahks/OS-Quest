using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserAuth : MonoBehaviour
{
    [SerializeField] GameObject LoginPanel; // Default panel for loging in
    [SerializeField] GameObject RegisterPanel; // Default panel for registering
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    // Use these two methods below to swap between the register and the login panel
    public void EnableRegisterPanel()
    {
        RegisterPanel.SetActive(true);
        LoginPanel.SetActive(false);
    }

    public void EnableLoginPanel()
    {
        LoginPanel.SetActive(true);
        RegisterPanel.SetActive(false);
    }
}
