using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeeStreamController : MonoBehaviour
{

    public float horizontalSpeed = 2.0F;
    public float verticalSpeed = 2.0F;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MovePeeStream();
    }


    //todo: clamp the stream so it doesnt go out of bounds? or maybe keep it like this so if it goes out of bounds, player loses points or something.
    void MovePeeStream(){

        float h = horizontalSpeed * Input.GetAxis("Mouse X");
        float v = verticalSpeed * Input.GetAxis("Mouse Y");
        transform.Rotate(-v, h, 0);
    }

}
