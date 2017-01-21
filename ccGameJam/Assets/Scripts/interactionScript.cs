using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactionScript : MonoBehaviour {

    [SerializeField]
    GameObject crosshairObject;
    [SerializeField]
    GameObject pickedUpHolder;

    GameObject pickedUpObject;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            checkForObject();
        }
	}
        
    void checkForObject()
    {
        RaycastHit hit;

        if(Physics.Raycast(crosshairObject.transform.position, crosshairObject.transform.forward,out hit))
        {
            if(hit.collider.tag == "pickable")
            {
                hit.transform.GetComponent<interactableScript>().getPickedUp(pickedUpHolder.transform.position);
                hit.transform.parent = pickedUpHolder.transform;
            }
            
            else if (hit.collider.tag == "router")
            {
                hit.transform.GetComponent<interactableScript>().activateRouter();                
            }
            
        }

    }
}
