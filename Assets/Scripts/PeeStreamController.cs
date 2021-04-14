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
    public int yellowPeeBoostDuration = 10;

    private float peeAcceleration = 5f;


    // public AudioSource peeSound;

    // Start is called before the first frame update
    void Start()
    {
        part = GetComponent<ParticleSystem>();
        collisionEvents = new List<ParticleCollisionEvent>();
        
        // peeSound.Play();
    }

    private void OnParticleCollision(GameObject other) {
        if (other.tag == "Flower"){
            var flower = other.gameObject.GetComponent<SpawnedFlower>();
            if (yellowPeeBoost){
                flower.TakeDamage(4);
                //Todo: change pee color and speed?
                //Todo: add some sound cues/better input feedback
            }
            flower.TakeDamage(1);
        } 
    }


    // Update is called once per frame
    void Update()
    {
        
        MovePeeStream();
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

    
    public void YellowPeeBostTrigger(){ //disable after x seconds
        yellowPeeBoost = true;
        //todo: handle velocity later
        var velocityOverLifetime = part.velocityOverLifetime;
        velocityOverLifetime.xMultiplier += peeAcceleration;
        velocityOverLifetime.yMultiplier += peeAcceleration;
        velocityOverLifetime.zMultiplier += peeAcceleration;

        Invoke("SetRegularPee", yellowPeeBoostDuration);

    }

    private void SetRegularPee(){
        yellowPeeBoost = false;
    }

}
