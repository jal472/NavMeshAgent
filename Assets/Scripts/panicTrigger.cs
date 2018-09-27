using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class panicTrigger : MonoBehaviour {

    public static UnityAction trigerPanicAndRun;
    public static Transform objTransform;
    bool readyForPanic;
    public bool panicExists;
    public WaypointController waypointController;
    // Use this for initialization
    void Start () {
        objTransform = this.transform;
        waypointController = GameObject.FindObjectOfType<WaypointController>();
        // readyForPanic = false;
    }
	
	// Update is called once per frame
	void Update () {

        // allow the panic state to be activated while the p-key is being held down
        if (Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log("panic = true");
            readyForPanic = true;
        }

        // once the p-key is released, panic mode can no longer be activated by right click
        if (Input.GetKeyUp(KeyCode.P))
        {
            Debug.Log("panic = false");
            readyForPanic = false;
        }

        if (readyForPanic)
		    if (Input.GetMouseButton(1))
            {
                panicExists = true;
                waypointController.panicDestinationSetter();
                Debug.Log("Right mouse button has been clicked");
            }

        if (Input.GetMouseButton(0))
        {
            panicExists = false;
        }
	}
}
