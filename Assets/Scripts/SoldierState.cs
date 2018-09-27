using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierState : MonoBehaviour {

    public bool panicState = false;
    public panicTrigger script;

    private void Start()
    {
        script = GameObject.FindObjectOfType<panicTrigger>();
    }

    // Update is called once per frame
    void Update () {
        if (script.panicExists)
        {
            panicState = true;
        }
        else
        {
            panicState = false;
        }
	}
}
