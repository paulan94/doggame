using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadShot : MonoBehaviour
{
    public SniperGameManager sniperGameManager;

    private void Awake() {
        sniperGameManager = FindObjectOfType<SniperGameManager>();
    }

    private void OnTriggerEnter(Collider other) {
        Debug.Log("trigger with" + other.gameObject.name);
        if (other.gameObject.tag == "Bullet"){
            sniperGameManager.scoreMultiplier = 1.5f;
        }

    }
}
