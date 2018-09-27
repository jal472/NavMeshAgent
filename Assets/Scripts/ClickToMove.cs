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
