using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AptCubeTrigger : MonoBehaviour
{
    public AudioSource citySoundAudioSource;

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player"){
            citySoundAudioSource.Stop();
        }
    }
    private void OnTriggerExit(Collider other) {
        if (other.tag == "Player"){
            citySoundAudioSource.Play();
        }
    }
}
