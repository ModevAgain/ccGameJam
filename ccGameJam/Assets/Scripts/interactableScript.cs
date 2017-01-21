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
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            releaseObject();
        }       
    }    

    public void releaseObject()
    {
        transform.parent = null;
        gameObject.AddComponent<Rigidbody>();
        //GetComponent<Rigidbody>().useGravity = true;
        //GetComponent<Rigidbody>().isKinematic = false;
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

        
        if (other.gameObject.tag == "socket")
        {            
            Destroy(gameObject.GetComponent<Rigidbody>());
            transform.parent = other.transform.parent;
            transform.position = other.transform.position;
<<<<<<< HEAD
            gameObject.GetComponent<interactionScript>().ShowOutline(new Color(1, 0, 0, 0.5f), gameObject);
=======
            transform.rotation = other.transform.rotation;
>>>>>>> origin/moe_working
        }
    }
}
