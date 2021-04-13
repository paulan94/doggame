using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeeStreamController : MonoBehaviour
{

    public float clampMin = -35;
    public float clampMax = 35;

    // public float yClampMin = -90f;
    // public float yClampMax = 90f;

    //maybe randomize these speeds to increase difficulty.
    public float horizontalSpeed = 2.0F;
    public float verticalSpeed = 2.0F;

    float rotateY = 0;
    float rotateX = 0;
    float rotX;
    float rotY;

    public ParticleSystem part;
    public List<ParticleCollisionEvent> collisionEvents;

    // Start is called before the first frame update
    void Start()
    {
        part = GetComponent<ParticleSystem>();
        collisionEvents = new List<ParticleCollisionEvent>();
    }

    private void OnParticleCollision(GameObject other) {
        Debug.Log("hit by something");
        if (other.tag == "Particle"){
            Debug.Log("Hit by some peepee");
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
        mouseScreenPosition.y = -mouseScreenPosition.y;
        Vector3 mouseWorldSpace = Camera.main.ScreenToWorldPoint(mouseScreenPosition);
        transform.LookAt(mouseWorldSpace, upAxis);

        //zero out all rotations except the axis I want
        transform.eulerAngles = new Vector3(-transform.eulerAngles.x,-transform.eulerAngles.y,-transform.eulerAngles.z);

    }

}
