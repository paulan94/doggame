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


    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
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
        // if (Input.)
    }
}
