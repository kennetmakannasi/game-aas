using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeDisplay : MonoBehaviour
{
    public Text timeText;
    public float timecount = 0;

    
    void Start()
    {
    }

    void Update()
    {
        timecount += Time.deltaTime;

        int minutes = Mathf.FloorToInt(timecount / 60);
        int seconds = Mathf.FloorToInt(timecount % 60);

        if (minutes > 0)
        {
            timeText.text = minutes + ":" + seconds;
        }
        else
        {
            timeText.text = "0:"+ seconds;
        }
    }
}
