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
    public int yellowPeeBoostDuration = 7;

    private float peeAcceleration = 5f;

    public float originalR = 241.0F;
    public float originalG = 231.0F;
    public float originalB = 69.0F;
    public float originalA = 255.0F;

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
        ChangePeeColor();
        MovePeeStream();
    }

    void ChangePeeColor(){
        if (yellowPeeBoost){

            var main = part.main;
            main.startColor = Color.yellow;
        }
        else{
            var main = part.main;
            main.startColor = new Color(originalR, originalG, originalB, originalA);
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

    
    public void YellowPeeBostTrigger(){ //disable after x seconds
        yellowPeeBoost = true;
        //todo: handle velocity later
        var velocityOverLifetime = part.velocityOverLifetime;
        velocityOverLifetime.xMultiplier += peeAcceleration;
        velocityOverLifetime.yMultiplier += peeAcceleration;
        velocityOverLifetime.zMultiplier += peeAcceleration;

        StartCoroutine("SetRegularPee");

    }

    IEnumerator SetRegularPee(){
        Debug.Log("waiting secs: " + yellowPeeBoostDuration);
        yield return new WaitForSeconds(yellowPeeBoostDuration);
        yellowPeeBoost = false;
    }

}
