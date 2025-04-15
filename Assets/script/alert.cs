using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class alert : MonoBehaviour
{
    public GameObject alertoverlay;
    public bool spawn = false;
    void Start()
    {
    }

    void Update()
    {
        if(spawn)
        {
        alertactive();    
        }
    }

    public void triggeractive()
    {
        spawn = true;
    }

    public void alertactive()
    {
        IEnumerator alert(){
            alertoverlay.SetActive(true);
            yield return new WaitForSeconds(1f);
            alertoverlay.SetActive(false);
            spawn = false;
        }
        StartCoroutine(alert());
    }
}
