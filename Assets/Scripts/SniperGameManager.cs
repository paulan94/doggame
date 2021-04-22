using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class SniperGameManager : MonoBehaviour
{

    public GameObject[] humanTargets;

    private void Start() {
        ChooseTarget();
    }

    void ChooseTarget(){
        int targetIdx = Random.Range(0,humanTargets.Length);
        Test_script target = humanTargets[targetIdx].GetComponent<Test_script>();
        target.SetSelfTarget();

    }

    public void DisableNonTargetCameras(){
        foreach (GameObject human in humanTargets)
        {
            if (!human.GetComponent<Test_script>().isTarget){ //if not target, disable cams
                CinemachineVirtualCamera vcam = human.GetComponentInChildren<CinemachineVirtualCamera>();
                vcam.gameObject.SetActive(false);
                vcam.Priority = 0;
            }
        }
    }
    
}
