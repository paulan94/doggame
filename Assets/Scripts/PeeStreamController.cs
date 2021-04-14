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
                //Todo: change pee color and speed?
                //Todo: add some sound cues/better input feedback
            }
            flower.TakeDamage(1);
            // Destroy(other.gameObject); //maybe pee on it for a while before it dies?
        } 
    }


    // Update is called once per frame
    void Update()
    {
        MovePeeStream();
        
    }


    //todo: clamp the stream so it doesnt go out of bounds? or maybe keep it like this so if it goes out of bounds, player loses points or something.
    void MovePeeStream(){

        Vector3 upAxis = new Vector3(-1,-1,-1);
        Vector3 mouseScreenPosition = Input.mousePosition;
        //set mouse y,z to your targets
        mouseScreenPosition.z = transform.position.z;
        Vector3 mouseWorldSpace = Camera.main.ScreenToWorldPoint(mouseScreenPosition);
        transform.LookAt(mouseWorldSpace, upAxis);

        //zero out all rotations except the axis I want
        transform.eulerAngles = new Vector3(-transform.eulerAngles.x,-transform.eulerAngles.y,-transform.eulerAngles.z);

    }

    
    public void YellowPeeBostTrigger(){ //disable after x seconds
        yellowPeeBoost = true;
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
