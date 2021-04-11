using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerTriggerScenes : MonoBehaviour
{

    public GameObject peePadTrigger;
    public GameObject parkGameTrigger;


    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject == peePadTrigger){
            Debug.Log("triggering pee pad game");
            SceneManager.LoadScene("PeePadGame");
        }
        if (other.gameObject == parkGameTrigger){
            Debug.Log("triggering park game");
            SceneManager.LoadScene("PeePadGame"); //chgange this to park game.
        }
    }
}
