using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverOverlay;
    public AudioSource src; 
    public AudioClip gameOversfx;
    public score score;
    public Text scoreText;
    public bool isGameOver = false;

    void Start()
    {
        gameOverOverlay.SetActive(false);
    }

    void Update()
    {
        if(isGameOver)
        {
            EndGame();
        }
    }

    public void triggerOverlay()
    {
        isGameOver = true;
        src.clip = gameOversfx;
        src.Play();
    }

    public void EndGame()
    {
        gameOverOverlay.SetActive(true);
        if(score.scoreValue == 0){
            StartCoroutine(txt());

        }else{
            scoreText.text = "Score: "+ score.scoreValue;

        }
    }

    public void restart()
    {
        score.scoreValue = 0;
        Time.timeScale = 1;
        SceneManager.LoadScene("Game");
    }

    public void menu()
    {
        score.scoreValue = 0;
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }

    IEnumerator txt(){
        yield return new WaitForSeconds(1);
        scoreText.text = "Skill Issue";
    }
}
