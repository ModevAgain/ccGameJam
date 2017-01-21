using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactableScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
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
        GetComponent<router>().routerActive = true;
        //TODO switch to TopDown

        

    }
}
