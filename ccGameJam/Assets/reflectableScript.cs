using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reflectableScript : MonoBehaviour {
    
    GameObject TopDownCam;

	// Use this for initialization
	void Start () {
        TopDownCam = GameObject.FindGameObjectWithTag("TopDownCam");
	}
	
	// Update is called once per frame
	void Update () {
        if (GameObject.FindGameObjectWithTag("router").GetComponent<router>().routerActive)
        {
            gameObject.tag = "reflectable";
        }
        else
        {
            gameObject.tag = "pickable";
        }
	}
}
