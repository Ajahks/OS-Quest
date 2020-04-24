using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPrefabs : Minigame
{
    public float rate = 2f;
    public float range = 2f;
    float rateTimer;

    public Pickup spawnee;

    // Update is called once per frame
    protected override void Update()
    {
        rateTimer += Time.deltaTime;

        if(rateTimer >= rate)
        {
            Spawn();
        }

        base.Update();
    }

    void Spawn()
    {
        float offset = Random.Range(-range, range);

        // Let the pickup be instantiated
        Pickup e = Instantiate(spawnee, transform.position + Vector3.right*offset, transform.rotation);
        e.SetData(this);    // Tell the pickup about the master game object

        rateTimer = 0;
    }
}
