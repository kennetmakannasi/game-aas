using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;


public class Pause : MonoBehaviour
{
    public GameObject pausescreen;
    public AudioSource src; 
    public AudioClip klik;
    public bool ispaused = false;
    
    void Start()
    {
        pausescreen.SetActive(false);
    }

    void Update()
    {
        if(Keyboard.current.escapeKey.isPressed){
            overlay();
            sfx();
        }
    }

    public void overlay()
    {
        ispaused = true;
        Time.timeScale = 0;
        pausescreen.SetActive(true);
    }

    public void resume()
    {
        sfx();
        Time.timeScale = 1;
        pausescreen.SetActive(false);    
    }

    public void sfx()
    {
        src.clip = klik;
        src.Play();
    }

}
