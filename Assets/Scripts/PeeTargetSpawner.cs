using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeeTargetSpawner : MonoBehaviour
{

    // Start is called before the first frame update
    public float dimX;
    public float dimY;
    public GameObject flowerPrefab;
    public GameObject powerUpPrefab;
    public GameObject explodingFlowerPrefab;


    void Start () {
        Mesh _mesh = transform.GetComponent<MeshFilter>().mesh;
        dimX = _mesh.bounds.size.x-1f;
        dimY = _mesh.bounds.size.z-1f;//I assume here that the square is on x and z, otherwise replace for the correct plane axis

        SpawnObjectsInPlane(10);
    }

    //to test purpose, attach to default plane and set a gameobject on spawntest variable
    void Update(){
    }

    public void SpawnObjectsInPlane(int howMany = 1){

        for (int i = 0; i < howMany; i++)
        {
            int flowerChoiceNumber = Random.Range(0,100);

            Vector3 randpos = Vector3.zero;
            randpos.x = Random.Range(-dimX/2f, dimX/2f);//assume mesh of the plane is centered, view mesh.bounds.min.x and mesh.bounds.max.x if not centered
            randpos.y = 0f;//"level" how much up to the plane spawn the objects
            randpos.z = Random.Range(-dimY/2f, dimY/2f);

            Transform instance;

            switch (flowerChoiceNumber)
            {
                case int n when n < 33 : 
                    instance = Instantiate ( flowerPrefab, this.transform).transform;
                    instance.localPosition = randpos;
                    break;
                case int n when n < 66 : 
                    instance = Instantiate (powerUpPrefab, this.transform).transform;
                    instance.localPosition = randpos;
                    break;
                case int n when n < 100 :
                    instance = Instantiate (explodingFlowerPrefab, this.transform).transform;
                    instance.localPosition = randpos;
                    break;
                
                default:
                    break;
            }
            
        }

    }
}
