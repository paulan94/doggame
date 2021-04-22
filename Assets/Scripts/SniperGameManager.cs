using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.SceneManagement;
using TMPro;

public class SniperGameManager : MonoBehaviour
{
    public int points = 0;

    public GameObject[] humanTargets;
    public Canvas gameEndCanvas;
    public TMP_Text endGameText;

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

    public void KilledTargetUIChange(){
        gameEndCanvas.gameObject.SetActive(true);
    }

    public void MissedTargetUIChange(){
        gameEndCanvas.gameObject.SetActive(true);
        endGameText.text = "You missed your target. Panic ensued in the crowd, and your target got away. Mission Failed...";
    }

    public void RestartGame(){
        SceneManager.LoadScene("SniperGame");
    }

    public void GoBackToApt(){
        SceneManager.LoadScene("Main");
    }
    
}
