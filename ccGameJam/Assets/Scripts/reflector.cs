using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reflector : MonoBehaviour {



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
       


        if (GameObject.FindGameObjectWithTag("router").GetComponent<router>().routerActive)
        {
            GetComponent<interactableScript>().enabled = false;
            
                Rigidbody rigid = gameObject.AddComponent<Rigidbody>();
                rigid.useGravity = false;

                rigid.constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotation;
          

        }
    }

    
}
