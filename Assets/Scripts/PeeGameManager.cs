using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeeGameManager : MonoBehaviour
{

    public Camera mainCamera;
    public GameObject newCameraPosition;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("StartTutorial");
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator StartTutorial(){
        //need to make some UI to show how to play pee game
        //then have button to click to start game

        Debug.Log("waiting 3 seconds to change transform and rotation");
        
        yield return new WaitForSeconds(1);
        
        mainCamera.transform.SetPositionAndRotation(newCameraPosition.transform.position, Quaternion.Euler(newCameraPosition.transform.eulerAngles));

    }
  
}
