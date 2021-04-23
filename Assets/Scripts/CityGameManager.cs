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
    public GameObject mailPrefab1; //
    public GameObject mailPrefab2;
    public MailButtonManager mailButtonManager;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake() {
        beatPeeGame = PlayerPrefs.GetInt(beatPeeGameKey, 0);
        if (beatPeeGame == 1){
            //TODO: unlock stairway 
            stairCase.SetActive(true);
            // mailPrefab1.SetActive(true);
            mailButtonManager.FinishedPottyGameMail();
            Debug.Log("you have unlocked the stairway");
        }
        else{
            stairCase.SetActive(false);
            mailPrefab1.SetActive(false);
        }
        beatSniperGame = PlayerPrefs.GetInt(beatSniperGameKey, 0);
        if (beatSniperGame == 1){
            //TODO: unlock stairway 
            mailPrefab2.SetActive(true);
            mailButtonManager.FinishedSniperGameMail();
            Debug.Log("you have beat the sniper game");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
