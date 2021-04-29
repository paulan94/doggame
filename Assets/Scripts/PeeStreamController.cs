using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeeStreamController : MonoBehaviour
{
    float rotX;
    float rotY;

    public ParticleSystem part;
    public List<ParticleCollisionEvent> collisionEvents;
    public PeeGameManager peeGameManager;

    public bool yellowPeeBoost;
    public int yellowPeeBoostDuration = 4;

    private float peeAcceleration = 5f;

    public float originalR = 241.0F;
    public float originalG = 231.0F;
    public float originalB = 69.0F;
    public float originalA = 255.0F;
    
    public float peeBuffTime = 0f;

    // Start is called before the first frame update
    void Start()
    {
        part = GetComponent<ParticleSystem>();
        collisionEvents = new List<ParticleCollisionEvent>();

    }

    private void OnParticleCollision(GameObject other) {
        if (other.tag == "Flower"){
            var flower = other.gameObject.GetComponent<SpawnedFlower>();
            if (yellowPeeBoost){
                flower.TakeDamage(4);
            }
            flower.TakeDamage(1);
        } 
    }


    // Update is called once per frame
    void Update()
    {
        if (peeGameManager.gameStarted){
            ChangePeeColor();
            MovePeeStream();
        }

    }

    void ChangePeeColor(){

        if (peeBuffTime <= 0){
            var main = part.main;
            main.startColor = new Color(originalR, originalG, originalB, originalA);
        }
        else if (peeBuffTime > 0){
            peeBuffTime -= Time.deltaTime;
            var main = part.main;
            main.startColor = Color.yellow;
            yellowPeeBoost = true;
        }
    }

    //todo: clamp the stream so it doesnt go out of bounds? or maybe keep it like this so if it goes out of bounds, player loses points or something.
    void MovePeeStream(){

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);;
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit)) {

            Vector3 target = hit.point;
            target.y = 0;
            target.y = transform.localScale.y / 2f;

            transform.LookAt (target);
        }

    }

}
