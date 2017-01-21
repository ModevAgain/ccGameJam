using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactableScript : MonoBehaviour {

    router rout;

	// Use this for initialization
	void Start () {
        rout = GetComponent<router>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void getPickedUp(Vector3 position)
    {
        transform.position = position;
    }

    public void activateRouter()
    {
        
        rout.routerActive = true;
        //TODO switch to TopDown

        

    }
}
