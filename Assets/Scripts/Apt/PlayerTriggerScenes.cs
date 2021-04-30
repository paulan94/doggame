using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerTriggerScenes : MonoBehaviour
{

    public GameObject peePadTrigger;
    public GameObject sniperGameTrigger;

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject == peePadTrigger){
            Debug.Log("triggering pee pad game");
            SceneManager.LoadScene("PeePadGame");
        }
        if (other.gameObject == sniperGameTrigger){
            Debug.Log("triggering park game");
            SceneManager.LoadScene("SniperGame");
        }
    }
}
