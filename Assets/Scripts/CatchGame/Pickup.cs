using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Pickup : MonoBehaviour
{
    Minigame game;

    public UnityEvent OnPlayerContact;
    public UnityEvent OnOtherContact;

    Rigidbody rb;

    public void SetData(Minigame god)
    {
        game = god;

        rb = GetComponent<Rigidbody>();
        if (rb)
        {
            float a = 100f;
            rb.AddTorque(0f, 0f, Random.Range(-a, a));
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(game && collision.transform == game.player)
        {
            OnPlayerContact.Invoke();
        } else if (game)
        {
            OnOtherContact.Invoke();
        }
    }

    public void AddGameScore(int add)
    {
        if (!game) return;

        game.AddScore(add);
    }

    public void LoseGameLife(int lose)
    {
        if (!game) return;

        game.LoseLife(lose);
    }

    /// <summary>
    /// Deletes the object.
    /// </summary>
    public void Destroy()
    {
        Destroy(gameObject);
    }
}
