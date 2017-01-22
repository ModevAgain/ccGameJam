using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactableScript : MonoBehaviour {

    router rout;
    public bool placable;
    Collision col;

    public bool reflectorSnapped;

    // Use this for initialization
    void Start () {
        rout = GameObject.FindGameObjectWithTag("router").GetComponent<router>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(reflectorSnapped)
        {
            Debug.Log("destroy");
            Destroy(GameObject.FindGameObjectWithTag("reflectableSocket").GetComponent<Rigidbody>());
        }

        if (GetComponent<repeater>().isSnapped)
        {
            Debug.Log("delete");
            Destroy(GameObject.FindGameObjectWithTag("repeaterSocket").GetComponent<Rigidbody>());
        }

        


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
               
        if (other.gameObject.tag == "repeaterSocket" && transform.tag == "repeater" && !rout.routerActive )
        {            
         
            Destroy(gameObject.GetComponent<Rigidbody>());
            //transform.parent = other.transform.parent;
            transform.position = other.transform.position;
            transform.rotation = other.transform.rotation;
            GetComponent<repeater>().isSnapped = true;
        }
        if (other.gameObject.tag == "reflectableSocket" && transform.tag == "reflectable")
        {
            Debug.Log("Mirr funzt");
            Destroy(gameObject.GetComponent<Rigidbody>());
            transform.rotation = new Quaternion(0, 0, 0, 0);
            //transform.parent = other.transform;
            transform.rotation = other.transform.rotation;
            transform.position = other.transform.position;
            reflectorSnapped = true;
            //placable = true;
        }
    }
}
