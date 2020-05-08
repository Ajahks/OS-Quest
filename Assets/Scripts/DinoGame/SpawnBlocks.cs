using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBlocks : MonoBehaviour
{
    public TopBlock block;
    public BotBlock bblock;
    float delay = 3.0f;
    float count = 0.0f;
    float time = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (count >= delay)
        {
            spawnNewBlock();
            count = 0f;
        }
        count += Time.deltaTime;
        time += Time.deltaTime;
        if (time >= 10)
        {
            if (delay > 1.0f)
            {
                delay -= 0.5f;
            }
            else
            {
                delay = 1.0f;
            }
            time = 0;
        }
    }

    public void spawnNewBlock()
    {
        Vector3 pos;
        pos.x = 10.0f;
        pos.z = 0.0f;
        if (Random.value < 0.3f)
        {
            pos.y = 0.4f;
            TopBlock newBlock = Instantiate(block, pos, Quaternion.identity);
        }
        else
        {
            pos.y = -1.1f;
            BotBlock newBlock = Instantiate(bblock, pos, Quaternion.identity);
        }

    }
}
