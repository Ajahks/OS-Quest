using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Photon.Pun;

/// <summary>
/// The super class of any score-based minigame.
/// </summary>
public class Minigame : MonoBehaviour
{
    public int overworldBuildIndex = 1;
    public Transform player;

    public Text textScore;
    public Text textLives;

    int score = 0;
    int lives = 3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if (textScore) textScore.text = "Score: " + score;
        if (textLives) textLives.text = "Lives: " + lives;
    }

    /// <summary>
    /// Add to the score of the player for this minigame.
    /// </summary>
    /// <param name="amt">The amount of points to add.</param>
    public void AddScore(int amt)
    {
        score += amt;
    }

    public void LoseLife(int amt)
    {
        lives -= amt;

        if(lives <= 0)
        {
            LoseGame();
        }
    }

    /// <summary>
    /// Should probably show a screen with scores before exiting the minigame scene.
    /// </summary>
    public void LoseGame()
    {
        PhotonNetwork.LoadLevel(overworldBuildIndex);
    }
}
