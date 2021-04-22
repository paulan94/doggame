using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Bullet : MonoBehaviour
{
    private float fixedDeltaTime;
    public ParticleSystem bloodSplatParticle;
    public SniperGameManager sniperGameManager;

    private void Awake() {
        // Make a copy of the fixedDeltaTime, it defaults to 0.02f, but it can be changed in the editor
        this.fixedDeltaTime = Time.fixedDeltaTime;
        sniperGameManager = FindObjectOfType<SniperGameManager>();
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "CylinderCam"){
            CinemachineVirtualCamera killcam = other.gameObject.GetComponentInChildren<CinemachineVirtualCamera>();
            killcam.Priority = 150;
        }
        if (other.gameObject.tag == "Human"){
            Test_script target = other.gameObject.GetComponentInParent<Test_script>();
            if (target.isTarget){
                sniperGameManager.DisableNonTargetCameras();
                target.HandleDeath();
                Debug.Log("kill human logic here");
            }
            var instantiatedParticle = Instantiate(bloodSplatParticle, transform.position, Quaternion.identity);
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.gameObject.tag == "Human"){
            Debug.Log("exit body trigger");
            var instantiatedParticle = Instantiate(bloodSplatParticle, transform.position, Quaternion.identity);
        }
        //on exit, if we hit our target, send mail and handle restart/scene reset, etc.
    }

    // Update is called once per frame
    void Update()
    {
        
        Debug.Log(Time.fixedDeltaTime);
    }
}
