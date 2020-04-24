using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Handles the despawning of thrown trash
public class Trash : MonoBehaviour
{
    #region Variables
    [SerializeField] float despawnTime = 5.0f;

    float timer = 0.0f;
    #endregion


    private void FixedUpdate()
    {
        // Handle despawning
        timer += Time.deltaTime;
        if(timer >= despawnTime)
        {
            Destroy(gameObject);
        }
    }
}
