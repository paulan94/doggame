using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Bullet : MonoBehaviour
{
    private float fixedDeltaTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    

    private void Awake() {
        // Make a copy of the fixedDeltaTime, it defaults to 0.02f, but it can be changed in the editor
        this.fixedDeltaTime = Time.fixedDeltaTime;
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "CylinderCam"){
            CinemachineVirtualCamera killcam = other.gameObject.GetComponentInChildren<CinemachineVirtualCamera>();
            killcam.Priority = 150;
            if (Time.timeScale == 1.0f){
                Time.timeScale = 0.1f;
            }
            if (Time.timeScale == 0.1f){
                Time.timeScale = 0.02f;
            }
            else{
                Time.timeScale = 1.0f;
            }
            Time.fixedDeltaTime = this.fixedDeltaTime * Time.timeScale;
            Debug.Log("yoooo");
        }
        if (other.gameObject.tag == "Human"){
            Debug.Log("kill human logic here");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
