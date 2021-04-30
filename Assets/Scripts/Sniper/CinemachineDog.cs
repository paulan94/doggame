using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CinemachineDog : MonoBehaviour
{
    public CinemachineVirtualCamera closerCM;
    public CinemachineVirtualCamera sniperCM;

    public GameObject closerUpTriggerArea;
    public GameObject sniperZoneTriggerArea;

    public GameObject sniperDog;

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "ZoomZone"){
            closerCM.Priority = 25;
        }
        if (other.gameObject.tag == "SnipeZone"){
            //lock dog onto roof and allow sniper to show.
            Debug.Log("changing sniper cm prior to 30");
            sniperCM.Priority = 30;
            PlayerMovement playerMovement = GetComponent<PlayerMovement>();
            playerMovement.isSniping = true;
            sniperDog.SetActive(true);

        }
    }
    private void OnTriggerExit(Collider other) {
        if (other.gameObject.tag == "ZoomZone"){
            closerCM.Priority = 15;
        }
    }
}
