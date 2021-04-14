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

    public int score = 0;


    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + score;
    }

    public void StartTutorial(){
        
        mainCamera.transform.SetPositionAndRotation(newCameraPosition.transform.position, Quaternion.Euler(newCameraPosition.transform.eulerAngles));
        peeCanvas.gameObject.SetActive(false);
        scoreBoardCanvas.gameObject.SetActive(true);
        //hide UI once game starts
        //only start stream when game starts

    }

    public void LoadMainScene(){
        SceneManager.LoadScene(0);
    }


  
}
