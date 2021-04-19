using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityGameManager : MonoBehaviour
{

    string beatPeeGameKey = "beatPeeGame";
    public int beatPeeGame = 0;
    public GameObject stairCase;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake() {
        beatPeeGame = PlayerPrefs.GetInt(beatPeeGameKey, 0);
        if (beatPeeGame == 1){
            //TODO: unlock stairway 
            stairCase.SetActive(true);
            Debug.Log("you have unlocked the stairway");
        }
        else{
            stairCase.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
