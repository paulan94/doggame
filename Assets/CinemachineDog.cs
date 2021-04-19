using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CinemachineDog : MonoBehaviour
{
    public CinemachineVirtualCamera closerCM;

    public GameObject closerUpTriggerArea;

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "SnipeZone"){
            closerCM.Priority = 25;
        }
    }
    private void OnTriggerExit(Collider other) {
        if (other.gameObject.tag == "SnipeZone"){
            closerCM.Priority = 15;
        }
    }
}
