using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    Text text;
    private float time;
    private bool go;
    // Start is called before the first frame update
    void Start()
    {
        go = true;
        text = GetComponent<Text>();
        time = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (go)
        {
            time += Time.deltaTime;
            text.text = "Total time: " + time.ToString("F2");
        }
    }

    public void endTime()
    {
        go = false;
    }
    public float getTime()
    {
        return time;
    }
}
