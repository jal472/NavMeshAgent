using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ClickToMove : MonoBehaviour {
    private Animator animator;
    private NavMeshAgent navMeshAgent;
    private bool running = false;
    public panicTrigger script;

	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        script = GameObject.FindObjectOfType<panicTrigger>();
	}
	
	// Update is called once per frame
	void Update () {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //Ray ray2 = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;

  
        if (Input.GetMouseButtonDown(0))
        {
           if (Physics.Raycast(ray, out hit, 100))
           {
              navMeshAgent.destination = hit.point;
           }
        }

        if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
        {
            running = false;
        }
        else
        {
            running = true;
        }

        // the line below is what is causing the console errors
        // it has something to do with the inspector and instantiating the object but i coudlnt figure it out yet
        // once we can get the console message to not happen ADD THIS INSIDE OF THE IF STATEMENT :
                        //if (script.panicExists == true) {
                        //navMeshAgent.SetDestination(RandomNavmeshLocation(4f)); }
        // that line of code should make the soldier go to a random location on the map

        if (script.panicExists)
        {
            Debug.Log("ok we got here");
        }

        //RaycastHit hit2;


        animator.SetBool("running", running);
	}


    // navmeshagent random location generator
    public Vector3 RandomNavmeshLocation(float radius)
    {
        Vector3 randomDirection = Random.insideUnitSphere * radius;
        randomDirection += transform.position;
        NavMeshHit hit;
        Vector3 finalPosition = Vector3.zero;
        if (NavMesh.SamplePosition(randomDirection, out hit, radius, 1))
        {
            finalPosition = hit.position;
        }
        return finalPosition;
    }

       
}
