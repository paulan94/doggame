using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CityGameManager : MonoBehaviour
{

    string beatPeeGameKey = "beatPeeGame";
    public int beatPeeGame = 0;

    string beatSniperGameKey = "beatSniperGame";
    public int beatSniperGame = 0;

    public GameObject stairCase;
    public GameObject mailPrefab1;
    public GameObject mailPrefab2;
    public MailButtonManager mailButtonManager;

    public Canvas escapeCanvas;
    public bool escapeActive = false;


    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1.0f;
    }

    private void Awake() {
        beatPeeGame = PlayerPrefs.GetInt(beatPeeGameKey, 0);
        Debug.Log("beatpeegame?:" + beatPeeGame);
        if (beatPeeGame == 1){
            stairCase.SetActive(true);
            mailPrefab1.SetActive(true);
        }
        else{
            stairCase.SetActive(false);
            mailPrefab1.SetActive(false);
        }
        beatSniperGame = PlayerPrefs.GetInt(beatSniperGameKey, 0);
        Debug.Log("beatsniper?:" + beatSniperGame);
        if (beatSniperGame == 1){
            mailPrefab2.SetActive(true);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !escapeActive){
            escapeCanvas.gameObject.SetActive(true);
            escapeActive = true;
            PauseGame();
            Cursor.lockState = CursorLockMode.None;
        }
        else if (Input.GetKeyDown(KeyCode.Escape)){
            escapeCanvas.gameObject.SetActive(false);
            escapeActive = false;
            Cursor.lockState = CursorLockMode.Locked;
            ResumeGame();
        }
    }

    public void PauseGame(){
        Time.timeScale = 0f;
    }

    public void QuitGame(){
        Application.Quit();
    }

    public void ResumeGame(){
        escapeCanvas.gameObject.SetActive(false);
        Time.timeScale = 1.0f;
    }
}
