using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPrefabs : MonoBehaviour
{
    public float rate = 2f;
    float rateTimer;

    public GameObject prefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rateTimer += Time.deltaTime;

        if(rateTimer >= rate)
        {
            rateTimer = 0;
            GameObject go = Instantiate(prefab, transform.position, transform.rotation);
        }
    }
}
