using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PeeGameManager : MonoBehaviour
{

    public Camera mainCamera;
    public GameObject newCameraPosition;
    public Canvas peeCanvas;
    public Canvas scoreBoardCanvas;
    public TMP_Text scoreText;

    public Canvas endGameCanvas;
    public TMP_Text highScoreText;

    public int score = 0;
    public int highScore = 0;
    string highScoreKey = "HighScore";
    public PeeTargetSpawner spawner;
    public bool gameStarted = false;

    private void Start() {
        //get highscore from prefs
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        highScoreText.text = "High Score: " + highScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + score;

        if (spawner.gameEnd == true){
            EndGame();
        }
    }

    public void StartTutorial(){
        
        mainCamera.transform.SetPositionAndRotation(newCameraPosition.transform.position, Quaternion.Euler(newCameraPosition.transform.eulerAngles));
        peeCanvas.gameObject.SetActive(false);
        scoreBoardCanvas.gameObject.SetActive(true);
        gameStarted = true;
        //only start stream when game starts

    }

    public void EndGame(){
        //update scoreboard
        if (score > highScore){
            PlayerPrefs.SetInt(highScoreKey, score);
            PlayerPrefs.Save();
        }
        highScoreText.text = "High Score: " + PlayerPrefs.GetInt("HighScore").ToString();
        endGameCanvas.gameObject.SetActive(true);
        gameStarted = false;
    }

    public void LoadMainScene(){
        SceneManager.LoadScene(0);
    }
  
}
