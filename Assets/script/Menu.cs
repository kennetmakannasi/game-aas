using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject anggota;
    public AudioSource src; 
    public AudioClip klik;

    void Start()
    {
        anggota.SetActive(false);
    }

    public void MainMenu()
    {
        IEnumerator MainMenu(){
            sfx();
            yield return new WaitForSeconds(0.12f);
            SceneManager.LoadScene("MainMenu");    
        }
        StartCoroutine(MainMenu());
    }

    public void startGame()
    {
        IEnumerator startGame(){
            sfx();
            yield return new WaitForSeconds(0.12f);
            SceneManager.LoadScene("Game");    
        }
        StartCoroutine(startGame());
    }

    public void openanggota()
    {
        sfx();
        anggota.SetActive(true);
    }

    public void closeanggota()
    {
        sfx();
        anggota.SetActive(false);
    }

    public void sfx()
    {
        src.clip = klik;
        src.Play();
    }

    public void exit()
    {
        IEnumerator exit(){
            sfx();
            yield return new WaitForSeconds(0.12f);
            Application.Quit();  
        }
        StartCoroutine(exit());
    }

}
