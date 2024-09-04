using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    public GameObject gameOverScreen;
    public GameObject gameWinScreen;
    public GameObject restartText;
    public AudioSource gameOverAudSrc;
    public AudioSource victoryAudSrc;

    private void Start()
    {
        restartText.SetActive(true);
    }
    private void Update()
    {
        if (restartText.activeSelf)
        {
            if (Input.GetKey(KeyCode.R) == true) {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }
    public void winGame() {
        restartText.SetActive(false);
        gameWinScreen.SetActive(true);
        victoryAudSrc.Play();

    }
    

    public void GameOver(){
       restartText.SetActive(false);
       gameOverScreen.SetActive(true);
       gameOverAudSrc.Play();
    }
}
