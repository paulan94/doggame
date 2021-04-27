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
    public TMP_Text unlockText;

    public int score = 0;
    public int highScore = 0;
    string highScoreKey = "HighScore";
    string beatPeeGameKey = "beatPeeGame";
    public PeeTargetSpawner spawner;
    public bool gameStarted = false;

    public AudioSource audioSource;

    public Canvas escapeCanvas;
    public bool escapeActive = false;

    public GameObject peeStreamParent;


    private void Start() {
        //get highscore from prefs
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        highScoreText.text = "High Score: " + highScore.ToString();
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (spawner.gameEnd){
            EndGame();
        }
        else{
            scoreText.text = "Score: " + score;

        if (gameStarted && Input.GetKeyDown(KeyCode.Escape) && !escapeActive){
            escapeCanvas.gameObject.SetActive(true);
            escapeActive = true;
            PauseGame();
            Cursor.lockState = CursorLockMode.None;
        }
        else if (gameStarted && Input.GetKeyDown(KeyCode.Escape)){
            escapeCanvas.gameObject.SetActive(false);
            escapeActive = false;
            ResumeGame();
            }
        }
    }

    public void PauseGame(){
        Time.timeScale = 0f;
        Cursor.visible = true;
    }

    public void ResumeGame(){
        escapeCanvas.gameObject.SetActive(false);
        Time.timeScale = 1.0f;
        Cursor.visible = false;
    }

    public void StartTutorial(){
        peeStreamParent.SetActive(true);
        Debug.Log("starting why");
        mainCamera.transform.SetPositionAndRotation(newCameraPosition.transform.position, Quaternion.Euler(newCameraPosition.transform.eulerAngles));
        Cursor.visible = false;
        peeCanvas.gameObject.SetActive(false);
        scoreBoardCanvas.gameObject.SetActive(true);
        gameStarted = true;
        audioSource.Play();

    }

    public void EndGame(){
        Cursor.visible = true;
        audioSource.Stop();
        //update scoreboard
        if (score > highScore){
            PlayerPrefs.SetInt(highScoreKey, score);
            PlayerPrefs.Save();
        }
        if (score > 2500){ //this should be called just once, so some feedback to show they beat the game.
            PlayerPrefs.SetInt(beatPeeGameKey, 1);
            PlayerPrefs.Save();
            unlockText.gameObject.SetActive(true);
        }
        if (highScore > 2500){
            Debug.Log("beat pee game, saving progress");
            PlayerPrefs.SetInt(beatPeeGameKey, 1);
            PlayerPrefs.Save();
            unlockText.gameObject.SetActive(true);
        }
        highScoreText.text = "High Score: " + PlayerPrefs.GetInt("HighScore").ToString();
        endGameCanvas.gameObject.SetActive(true);
        gameStarted = false;
    }

    public void LoadMainScene(){
        SceneManager.LoadScene("Main");
    }

    public void LoadPeeScene(){
        SceneManager.LoadScene("PeePadGame");
    }
  
}
