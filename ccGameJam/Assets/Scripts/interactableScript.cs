using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactableScript : MonoBehaviour {

    router rout;
    public bool placable;
    Collision col;

    // Use this for initialization
    void Start () {
        rout = GetComponent<router>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        
    }    

    

    public void getPickedUp(Vector3 position)
    {
        Destroy(GetComponent<Rigidbody>());
        transform.position = position;
    }

    public void activateRouter()
    {        
        rout.routerActive = true;
        //TODO switch to TopDown   

    }
    
    void OnCollisionEnter(Collision other)
    {
               
        if (other.gameObject.tag == "repeaterSocket" && transform.tag == "repeater")
        {
            
            Debug.Log("Rep funzt");
            Destroy(gameObject.GetComponent<Rigidbody>());
            transform.parent = other.transform.parent;
            transform.position = other.transform.position;
            transform.rotation = other.transform.rotation;            
        }
        if (other.gameObject.tag == "reflectableSocket" && transform.tag == "reflectable")
        {
            Debug.Log("Mirr funzt");
            Destroy(gameObject.GetComponent<Rigidbody>());
            transform.parent = other.transform.parent;
            transform.position = other.transform.position;
            transform.rotation = other.transform.rotation;
            placable = true;
        }
    }
}
