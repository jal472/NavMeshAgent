using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WaypointController : MonoBehaviour {

    public List<Transform> waypoints = new List<Transform>();
    public List<NavMeshAgent> soldiers = new List<NavMeshAgent>();
    public panicTrigger script;

    // Use this for initialization
    void Start () {
        GetWaypoints();
        GetSoldiers();
        script = GameObject.FindObjectOfType<panicTrigger>();
    }

    void GetWaypoints()
    {
        Transform[] wpList = this.transform.GetComponentsInChildren<Transform>();
        for (int i = 0; i < wpList.Length; i++)
        {
            if (wpList[i].tag == "waypoint")
            {
                waypoints.Add(wpList[i]);
            }
        }
    }

    void GetSoldiers()
    {
        NavMeshAgent[] soldierList = this.transform.GetComponentsInChildren<NavMeshAgent>();
        for (int i = 0; i < soldierList.Length; i++)
        {
            if (soldierList[i].tag == "soldier")
            {
                soldiers.Add(soldierList[i]);
            }
        }
    }

    public void panicDestinationSetter()
    {
        float shortestDistance = 2000f;
        int waypointIndex = 0;
        float soldierDistance = 0f;
        //move players to closest waypoint
        if (script.panicExists)
        {
            for(int i = 0; i < soldiers.Count; i++)
            {
                Debug.Log("looping over soldiers");
                for (int j = 0; j < waypoints.Count; j++)
                {
                    Debug.Log("Looping over waypoints");
                    Debug.Log(Vector3.Distance(soldiers[i].transform.position, waypoints[j].transform.position)+ " < " + shortestDistance);
                    soldierDistance = Vector3.Distance(soldiers[i].transform.position, waypoints[j].transform.position);
                    if (soldierDistance < shortestDistance)
                    {
                        Debug.Log("Setting waypoint index");
                        shortestDistance = soldierDistance;
                        waypointIndex = j;
                    }
                }
                soldiers[i].destination = waypoints[waypointIndex].transform.position;
            }
        }
        else
        {

        }
    }
}
