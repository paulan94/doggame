using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadShot : MonoBehaviour
{
    public SniperGameManager sniperGameManager;
    public AudioSource audioSource;
    public AudioClip headshotSound;
    public Canvas headShotCanvas;

    private void Awake() {
        sniperGameManager = FindObjectOfType<SniperGameManager>();
    }

    private void OnTriggerEnter(Collider other) {
        Debug.Log("trigger with" + other.gameObject.name);
        if (other.gameObject.tag == "Bullet"){
            sniperGameManager.scoreMultiplier = 1.5f;
            audioSource.PlayOneShot(headshotSound);
            StartCoroutine("ShowHeadShotCanvas", 1f);
        }

    }

    IEnumerator ShowHeadShotCanvas(float howLong){
        headShotCanvas.gameObject.SetActive(true);
        yield return new WaitForSeconds(howLong);
        
        headShotCanvas.gameObject.SetActive(false);
    }
}
