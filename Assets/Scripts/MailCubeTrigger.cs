using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MailCubeTrigger : MonoBehaviour
{
    public Canvas mailBoxCanvas;

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player"){
            mailBoxCanvas.gameObject.SetActive(true);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }
    private void OnTriggerExit(Collider other) {
        if (other.tag == "Player"){
            mailBoxCanvas.gameObject.SetActive(false);
        }
    }
}
