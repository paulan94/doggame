using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.SceneManagement;
using TMPro;

public class SniperGameManager : MonoBehaviour
{
    public int points = 0;

    public GameObject[] humanTargets;
    public Canvas gameEndCanvas;
    public TMP_Text endGameText;
    public bool startTimer = false;
    public bool gameStart = false;
    //todo: add UI for score

    //scoring
    public int score = 9999;
    public int highScore = 0;
    public float scoreMultiplier = 1f;

    string highScoreKey = "SniperHighScore";
    string beatSniperGameKey = "beatSniperGame";

    public TMP_Text scoreText;
    public TMP_Text highScoreText;

    public Canvas scoreCanvas;
    public Canvas highScoreCanvas;

    public Canvas escapeCanvas;
    public bool escapeActive = false;

    private void Start() {
        
        highScore = PlayerPrefs.GetInt(highScoreKey, 0); //init highscore
        highScoreText.text = "High Score: " + highScore.ToString();
        ChooseTarget();
        Time.timeScale = 1.0f;
        
    }

    private void Update() {
        if (!gameStart && Input.GetKeyDown(KeyCode.Escape) && !escapeActive){
            escapeCanvas.gameObject.SetActive(true);
            escapeActive = true;
            PauseGame();
            Cursor.lockState = CursorLockMode.None;
        }
        else if (!gameStart && Input.GetKeyDown(KeyCode.Escape)){
            escapeCanvas.gameObject.SetActive(false);
            escapeActive = false;
            ResumeGame();
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

    void ChooseTarget(){
        int targetIdx = Random.Range(0,humanTargets.Length);
        Test_script target = humanTargets[targetIdx].GetComponent<Test_script>();
        target.SetSelfTarget();
    }

    public void StartScoringCoroutine(){
        scoreCanvas.gameObject.SetActive(true);
        StartCoroutine("StartScoring");
    }

    public void StopScoringCoroutine(){
        PlayerPrefs.GetInt("SniperHighScore", 0);
        score = (int)(score * scoreMultiplier);
        scoreText.text = "Score: " + score;
        if (score > highScore){
            highScoreText.text = "High Score: " + score.ToString();
            PlayerPrefs.SetInt(highScoreKey, score);
            PlayerPrefs.Save();
        }
        if (score > 9700){
            PlayerPrefs.SetInt(beatSniperGameKey, 1);
            PlayerPrefs.Save();
        }
        if (highScore > 9700){ //TODO: modify score
            PlayerPrefs.SetInt(beatSniperGameKey, 1);
            PlayerPrefs.Save();
        }
        StopCoroutine("StartScoring");
        //if missed update score
    }

    IEnumerator StartScoring(){
        while (score > 10){
            scoreText.text = "Score: " + score;
            score -= 10;
            yield return new WaitForSeconds(1f);
        }
    }

    public void DisableNonTargetCameras(){
        foreach (GameObject human in humanTargets)
        {
            if (!human.GetComponent<Test_script>().isTarget){ //if not target, disable cams
                CinemachineVirtualCamera vcam = human.GetComponentInChildren<CinemachineVirtualCamera>();
                vcam.gameObject.SetActive(false);
                vcam.Priority = 0;
            }
        }
    }

    public void KilledTargetUIChange(){
        gameEndCanvas.gameObject.SetActive(true);
    }

    public void MissedTargetUIChange(){
        gameEndCanvas.gameObject.SetActive(true);
        endGameText.text = "You missed your target. Panic ensued in the crowd, and your target got away. Mission Failed...";
    }

    public void RestartGame(){
        SceneManager.LoadScene("SniperGame");
    }

    public void GoBackToApt(){
        SceneManager.LoadScene("Main");
    }
    
}
