using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CarMovement : MonoBehaviour
{
    NavMeshAgent agent;
    public GameObject aim_point;

    public float walk_speed;

    public bool walk;

    public bool destermine_new_aim;
    
    public bool ready;
    public float distanceToPoint = 100f;
    
    public List<GameObject> way_points;

    public int waypointIdx = 0;

    void Start()
    {
        
        agent = GetComponent<NavMeshAgent>();

        // way_points.Clear();

        // GameObject[] waypointsFind = GameObject.FindGameObjectsWithTag("carwaypoint");
        foreach(GameObject g in way_points)
        {
            way_points.Add(g);
        }

    }


    void Update()
    {


        if(!ready)
        {
            return;
        }

     
        if(!destermine_new_aim)
        {
            int what_to_choose = 0; //todo maybe update this

            walk = false;

            if(what_to_choose == 0)
            {
                walk = true;

                aim_point = way_points[waypointIdx].gameObject;
                destermine_new_aim = true;
                
                waypointIdx++;
                if (waypointIdx >= way_points.Count){
                    waypointIdx = 0;
                }
            }
        }

        if (destermine_new_aim)
        {
            if (walk)
            {

                if (Vector3.Distance(transform.position,aim_point.transform.position) > distanceToPoint)
                {
                   
                    agent.speed = walk_speed;
                    agent.SetDestination(aim_point.transform.position);
                }

                if (Vector3.Distance(transform.position, aim_point.transform.position) <= distanceToPoint)
                {
                    agent.speed = 0;

                    destermine_new_aim = false;
                }

            }
        }
    }
}
